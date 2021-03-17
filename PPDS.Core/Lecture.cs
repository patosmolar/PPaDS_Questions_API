using System;
using System.Collections.Generic;

namespace PPDS.Core
{
    public class Lecture
    {
        public int Id { get; set; }
        public DateTime Date{ get; set; }
        public int LectureTypeId { get; set; }
        public LectureType LectureType { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}
