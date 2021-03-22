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
        public LectrueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
