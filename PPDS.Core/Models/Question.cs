using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType{ get; set; }
        public ICollection<ChoosableAnswer> ChoosableAnswers{ get; set; }
        public string Author{ get; set; }
        public int LectureId { get; set; }



    }
}
