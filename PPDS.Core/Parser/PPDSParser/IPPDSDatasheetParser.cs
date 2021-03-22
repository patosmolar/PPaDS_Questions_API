using PPDS.Core.Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Parser.PPDSParser
{
    public interface IPPDSDatasheetParser
    {
        public IEnumerable<RawQuestionData> ParseCSVToRawData(string data);
    }
}
