using PPDS.Core.Models;
using PPDS.Core.Parser.Models;
using PPDS.Core.Parser.PPDSParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Parser.LectureBuilder
{
    public class LectureBuilder : ILectureBuilder
    {
        private readonly IPPDSDatasheetParser _pPDSDatasheetParser;

        public LectureBuilder(IPPDSDatasheetParser pPDSDatasheetParser)
        {
            this._pPDSDatasheetParser = pPDSDatasheetParser;
        }


        public Question ParseRawQuestionContentToQuestion(RawQuestionData rawQuestionContent)
        {
            var question = new Question()
            {
                Author = rawQuestionContent.Author,
                QuestionTypeId = 1
            };

            var firstSymbol = rawQuestionContent.QuestionContext.FirstOrDefault(c => !char.IsWhiteSpace(c));

            if (firstSymbol == '+' || firstSymbol == '-')
            {
               
            }
            else
            {

            }


            if (firstSymbol == '-')
            {
                question.ChoosableAnswers.Add(new ChoosableAnswer()
                {
                    Content = "NIE",
                    IsRight = true
                });
                question.ChoosableAnswers.Add(new ChoosableAnswer()
                {
                    Content = "ANO",
                    IsRight = false
                });
            }
            else if (firstSymbol == '+')
            {
                question.ChoosableAnswers.Add(new ChoosableAnswer()
                {
                    Content = "NIE",
                    IsRight = false
                });
                question.ChoosableAnswers.Add(new ChoosableAnswer()
                {
                    Content = "ANO",
                    IsRight = true
                });

            }
            else
            {

            }



            return question;

        }


        public Lecture BuildLectureFromString(string data)
        {
            var stoj = _pPDSDatasheetParser.ParseCSVToRawData(data);

            var resultLecture = new Lecture();
            resultLecture.Date = new DateTime();
            resultLecture.LectureTypeId = 1;

            var Questions = new List<Question>();
            foreach (var rawQuestionContent in stoj)
            {
                Questions.Add(ParseRawQuestionContentToQuestion(rawQuestionContent));
            }



            return resultLecture;
        }
    }
}
