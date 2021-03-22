using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Models
{
    public class LectureType
    {
        public static LectureType Lecture = new LectureType() { Id = 1, Description = nameof(Lecture) };
        public static LectureType Practise = new LectureType() { Id = 2, Description = nameof(Practise) };

        public int Id { get; set; }
        public string Description { get; set; }

    }
}
