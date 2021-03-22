using CsvHelper;
using PPDS.Core.Parser.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Parser.PPDSParser
{

    public class PPDSDatasheetParser : IPPDSDatasheetParser
    {
       
        public IEnumerable<RawQuestionData> ParseCSVToRawData(string data)
        {

            using (var reader = new StringReader(data))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<RawQuestionMap>();
                return csv.GetRecords<RawQuestionData>().ToList();
            }



        }
    }
}
