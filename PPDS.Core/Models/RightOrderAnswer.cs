using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Models
{
    public class RightOrderAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public bool IsRight { get; set; }


        public int QuestionId { get; set; }
    }
}
