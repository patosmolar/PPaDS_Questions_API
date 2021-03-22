using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Parser.Models
{
    public sealed class RawQuestionMap : ClassMap<RawQuestionData>
    {
        public RawQuestionMap()
        {
            Map(m => m.Date).Name("Časová pečiatka");
            Map(m => m.Email).Name("E-mailová adresa");
            Map(m => m.Author).Name("Meno");
            Map(m => m.QuestionContext).Name("Znenie otázky");
        }
       

    }
}
