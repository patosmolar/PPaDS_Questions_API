using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Models
{
    public class MatchingAnswerMain
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }

    
        public ICollection<MatchingAnswerSecondary> RightMatches { get; set; }
           



        public int QuestionId { get; set; }
    }
}
