using CsvHelper;
using PPDS.Core.Extensions;
using PPDS.Core.Models;
using PPDS.Core.Parser.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Parser.PPDSParser
{

    public class PPDSDatasheetParser : IPPDSDatasheetParser
    {

        public IEnumerable<RawQuestionData> ParseCSVToRawData(string data)
        {

            using (var reader = new StringReader(data))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<RawQuestionMap>();
                return csv.GetRecords<RawQuestionData>().ToList();
            }



        }

        public Question ParseRawQuestionContextToQuestion(RawQuestionData questionData)
        {
            var question = ParseQuestionContext(questionData.QuestionContext);
            question.Author = questionData.Author;
            return question;
        }

        private Question ParseQuestionContext(string questionContext)
        {
            var resultQuestion = new Question()
            {
                ChoosableAnswers = new List<ChoosableAnswer>(),
                RightOrderAnswers = new List<RightOrderAnswer>(),
                MainMatchingAnswers = new List<MatchingAnswerMain>(),
                Content = ""
            };
            var qType = GetQuestionType(questionContext);
            resultQuestion.QuestionTypeId = qType.Id;


            if (questionContext.IsFirstPlusOrMinus() && qType == QuestionType.Choosable)
            {
                resultQuestion.ChoosableAnswers.Add(new ChoosableAnswer()
                {
                    Content = "NIE",
                    IsRight = questionContext.IsFirstMinus()
                });
                resultQuestion.ChoosableAnswers.Add(new ChoosableAnswer()
                {
                    Content = "ANO",
                    IsRight = questionContext.IsFirstPlus()
                });
                questionContext = questionContext.Substring(1);
            }
            using (StringReader reader = new StringReader(questionContext))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;

                    if (line.IsFirstPlusOrMinus() && qType == QuestionType.Choosable)
                    {
                        resultQuestion.ChoosableAnswers.Add(new ChoosableAnswer()
                        {
                            Content = line.Substring(1),
                            IsRight = !line.IsFirstMinus()
                        });
                    }
                    else if (line.IsFirstSquareBracket() && qType == QuestionType.RightOrder)
                    {

                        resultQuestion.RightOrderAnswers.Add(new RightOrderAnswer()
                        {
                            Order = line.GetNumberAfterSquareBracket(),
                            IsRight = line.Substring(line.IndexOf(']') + 1).IsFirstPlus(),
                            Content = line.Substring(line.IndexOf(']') + 1).Trim().Substring(1),
                        });
                    }
                    else if (line.IsFirstSquareBracket() && qType == QuestionType.Matching)
                    {
                        var notMain = line.Substring(line.IndexOf(']') + 1).IsFirstPlusOrMinus();
                        if (notMain)
                        {
                            resultQuestion.MainMatchingAnswers
                                .FirstOrDefault(x => x.Order == line.GetNumberAfterSquareBracket())
                                .RightMatches.Add(new MatchingAnswerSecondary()
                                {
                                    Content = line.Substring(line.IndexOf(']') + 1).Trim().Substring(1),
                                });
                        }
                        else
                        {
                            resultQuestion.MainMatchingAnswers.Add(new MatchingAnswerMain()
                            {
                                Content = line.Substring(line.IndexOf(']') + 1),
                                RightMatches = new List<MatchingAnswerSecondary>(),
                                Order = line.GetNumberAfterSquareBracket()
                            });
                        }

                    }
                    else
                    {
                        resultQuestion.Content += line + Environment.NewLine;
                    }
                }
            }


            return resultQuestion;
        }

        private QuestionType GetQuestionType(string context)
        {
            if (context.Contains("$$POLE"))
            {
                return QuestionType.RightOrder;
            }
            else if (IsMatchingType(context))
            {
                return QuestionType.Matching;
            }
            else
            {
                return QuestionType.Choosable;
            }
        }

        private bool IsMatchingType(string context)
        {
            bool res = false;
            using (StringReader reader = new StringReader(context))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;

                    if (line.IsFirstSquareBracket())
                    {
                        res = true;
                    }

                }
            }
            return res;
        }


    }
}








