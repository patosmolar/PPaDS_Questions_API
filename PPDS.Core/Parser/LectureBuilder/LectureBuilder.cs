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


            

        public Lecture BuildLectureFromString(string data, DateTime date, LectureType lectureType)
        {
            var rawData = _pPDSDatasheetParser.ParseCSVToRawData(data);

            var lecture = new Lecture()
            {
                Date = date,
                LectureTypeId = lectureType.Id
            };

            lecture.Questions = new List<Question>();
            foreach (var rawQuestionData in rawData)
            {
                lecture.Questions.Add(_pPDSDatasheetParser.ParseRawQuestionContextToQuestion(rawQuestionData));
            }
            return lecture;
        }
       
    }
}
