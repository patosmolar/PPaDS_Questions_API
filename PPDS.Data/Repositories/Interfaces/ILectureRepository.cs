using PPDS.Core;
using PPDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Data.Repositories.Interfaces
{
    public interface ILectureRepository : IBaseRepository<Lecture>
    {
        public Task<IEnumerable<Lecture>> GetAllByLectureType(LectureType lectureType);
        public Task<IEnumerable<Lecture>> GetLectureByDateAndType(DateTime dateFrom, DateTime dateTo, LectureType lectureType);
    }
}
