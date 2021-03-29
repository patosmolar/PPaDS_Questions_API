using Microsoft.EntityFrameworkCore;
using PPDS.Core;
using PPDS.Core.Models;
using PPDS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Data.Repositories
{
    public class LectrueRepository : BaseRepository<Lecture>, ILectureRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LectrueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Lecture>> GetAllByLectureType(LectureType lectureType)
        {

            return await _dbContext.Lectures
                .Where(x => x.LectureTypeId == lectureType.Id)
                .Include(x => x.Questions)
                .ThenInclude(x => x.ChoosableAnswers)
                .Include(x => x.Questions)
                .ThenInclude(x => x.MainMatchingAnswers)
                .ThenInclude(x => x.RightMatches)
                .Include(x => x.Questions)
                .ThenInclude(x => x.RightOrderAnswers)
                .ToListAsync();
            

        }

        public async Task<IEnumerable<Lecture>> GetLectureByDateAndType(DateTime dateFrom, DateTime dateTo, LectureType lectureType)
        {
            throw new NotImplementedException();
        }
    }
}
