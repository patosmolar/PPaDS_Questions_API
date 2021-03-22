using PPDS.Core.Models;
using PPDS.Core.Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Parser.LectureBuilder
{
    public interface ILectureBuilder
    {
        public Lecture BuildLectureFromString(string data, DateTime date, LectureType lectureType);
    }
}
