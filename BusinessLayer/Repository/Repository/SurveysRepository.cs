using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Repository.Repository
{
    public class SurveysRespository : IRepository<DataAccessLayer.Models.Survey>
    {
        private readonly AutomatedSurveysContext _context = new AutomatedSurveysContext();

        public void Create(DataAccessLayer.Models.Survey entity)
        {
            throw new NotImplementedException();
        }

        public DataAccessLayer.Models.Survey FirstOrDefault(Func<DataAccessLayer.Models.Survey, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public DataAccessLayer.Models.Survey FirstOrDefault()
        {
            return _context.Surveys.FirstOrDefault();
        }

        public DataAccessLayer.Models.Survey Find(int id)
        {
            return _context.Surveys.Find(id);
        }

        public IEnumerable<DataAccessLayer.Models.Survey> All()
        {
            throw new NotImplementedException();
        }
    }
}