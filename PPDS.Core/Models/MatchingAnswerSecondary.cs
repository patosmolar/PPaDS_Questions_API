﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Models
{
    public class MatchingAnswerSecondary
    {
        public int Id { get; set; }
        public string Content { get; set; }    

        public int MatchingAnswerMainReference { get; set; }
    }
}
