using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PPDS.Core;
using PPDS.Data.Repositories.Interfaces;
using PPDS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PPDS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILectureRepository lectureRepository;

        public HomeController(ILogger<HomeController> logger, ILectureRepository lectureRepository)
        {
            _logger = logger;
            this.lectureRepository = lectureRepository;
        }

        public async Task<IActionResult> Index()
        {
            var test = new Lecture()
            {
                Date = new DateTime(),
                LectureTypeId = LectureType.Lecture.Id,
                Questions = new List<Question>() {
                                                new Question()
                                                    {
                                                        Author = "Patrik Smolarr",
                                                        Content = "Je patrik super?",
                                                        QuestionTypeId = QuestionType.Choosable.Id,
                                                        ChoosableAnswers = new List<ChoosableAnswer>()
                                                            {
                                                                new ChoosableAnswer()
                                                                {
                                                                  Content = "nie",
                                                                  IsRight = false
                                                                },
                                                                new ChoosableAnswer()
                                                                {
                                                                  Content = "ano",
                                                                  IsRight = false
                                                                }

                                                            }
                                                    }

                                       }
            };
            // await lectureRepository.InsertAsync(test);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
