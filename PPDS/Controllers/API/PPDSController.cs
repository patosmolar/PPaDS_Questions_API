using Microsoft.AspNetCore.Mvc;
using PPDS.Core.Parser.LectureBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPDS.Controllers
{
    [Route("/api")]
    [ApiController]
    public class PPDSController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post()
        {


            return Ok();
        }



    }
}
