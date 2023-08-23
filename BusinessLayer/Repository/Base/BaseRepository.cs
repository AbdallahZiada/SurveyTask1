using BusinessLayer.Common.Enums;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Base
{
    public abstract class BaseRepoitory<T> : IBaseRepository<T> where T : class
    {
        public AutomatedSurveysContext AppDbContext { get; }
        internal BaseRepoitory(AutomatedSurveysContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public bool Commit()
        {
            return AppDbContext.SaveChanges() > 0;
        }
    }
}
