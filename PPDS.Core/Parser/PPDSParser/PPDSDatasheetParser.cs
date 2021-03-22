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
            var result = new Question()
            {
                ChoosableAnswers = new List<ChoosableAnswer>(),
                Content = ""
            };
            result.QuestionTypeId = QuestionType.Choosable.Id;


            if (questionContext.IsFirstSpecial())
            {
                result.ChoosableAnswers.Add(new ChoosableAnswer()
                {
                    Content = "NIE",
                    IsRight = questionContext.IsFirstMinus()
                });
                result.ChoosableAnswers.Add(new ChoosableAnswer()
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

                    if (line.IsFirstSpecial())
                    {
                        result.ChoosableAnswers.Add(new ChoosableAnswer()
                        {
                            Content = line.Substring(1),
                            IsRight = !line.IsFirstMinus()
                        });
                    }
                    else
                    {
                        result.Content += line + Environment.NewLine;
                    }
                }
            }

        
            return result;
        }


}
}








