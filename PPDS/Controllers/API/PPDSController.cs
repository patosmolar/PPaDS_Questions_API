using Microsoft.AspNetCore.Mvc;
using PPDS.Core.Parser.LectureBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPDS.Core.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using PPDS.Core.Parser.PPDSParser;
using System.Net;
using System.Net.Http.Headers;
using PPDS.Data.Repositories.Interfaces;

namespace PPDS.Controllers
{
    [Route("/api")]
    [ApiController]
    public class PPDSController : ControllerBase
    {
        private readonly ILectureBuilder _lectureParser;
        private readonly ILectureRepository _repository;

        public PPDSController(ILectureBuilder lectureParser, ILectureRepository repository)
        {
            this._lectureParser = lectureParser;
            this._repository = repository;
        }


        [Route("lecture")]
        [HttpPost]
        public async Task<IActionResult> AddLecture(IFormFile data, [FromHeader] DateTime date)
        {

            try
            {
                string content;
                using (var dataS = data.OpenReadStream())
                using (var reader = new StreamReader(dataS))
                {
                    content = reader.ReadToEnd();
                }
                var lectureToSave = _lectureParser.BuildLectureFromString(content, date, LectureType.Lecture);

                await _repository.InsertAsync(lectureToSave);
                return Ok(lectureToSave);
            }
            catch (Exception e)
            {
                return BadRequest();
            }


        }

        [Route("practise")]
        [HttpPost]
        public async Task<IActionResult> AddPractise(IFormFile data, [FromHeader] DateTime date)
        {
            string content;
            using (var dataS = data.OpenReadStream())
            using (var reader = new StreamReader(dataS))
            {
                content = reader.ReadToEnd();
            }

            var lectureToSave = _lectureParser.BuildLectureFromString(content, date, LectureType.Practise);
            await _repository.InsertAsync(lectureToSave);
            return Ok();
        }

        [Route("lecture")]
        [HttpGet]
        public async Task<IEnumerable<Lecture>> GetLectureByDate(DateTime? dateFrom, DateTime? dateTo)
        {

            return await _repository.GetLectureByDateAndType(dateFrom ?? DateTime.MinValue, dateTo ?? DateTime.MaxValue, LectureType.Lecture);
            

        }

    }
}
