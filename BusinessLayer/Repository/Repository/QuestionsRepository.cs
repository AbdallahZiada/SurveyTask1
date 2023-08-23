using BusinessLayer.Common.Enums;
using BusinessLayer.Dtos;
using BusinessLayer.Repository.Base;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Repository
{
    public class QuestionsRepository : BaseRepoitory<Question>, IRepository<Question>
    {
        public QuestionsRepository(AutomatedSurveysContext _context) : base(_context)
        {            
        }
        
        public async Task<(List<QuestionDTO> ListQuestion, int TotalCount)> GetQuestionsList(JTableSearchDTO<QuestionDTO> jTableSearch)
        {
            var ListQuestion = await GetPageAsync(jTableSearch.jTableStartIndex,
                                            jTableSearch.jTablePageSize,
                                            sortItemBy => sortItemBy.Id,
                                            jTableSearch.sortDirection, "");
            var ListQuestionMapped = ListQuestion.resultList.Select(p => new QuestionDTO { Id = p.Id, Body = p.Body }).ToList();
            return (ListQuestionMapped, ListQuestion.totalCount);
        }

        public void Create(Question question)
        {
            AppDbContext.Questions.Add(question);
            AppDbContext.SaveChanges();
        }

        public Question FirstOrDefault(Func<Question, bool> predicate)
        {
            return AppDbContext.Questions.FirstOrDefault(predicate);
        }

        public Question FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public Question Find(int id)
        {
            return AppDbContext.Questions.Find(id);
        }

        public IEnumerable<Question> All()
        {
            return AppDbContext.Questions.ToList();
        }
        private async Task<(List<Question> resultList, int totalCount)> GetPageAsync<TKey>(int skipCount, int takeCount, Expression<Func<Question, TKey>> sortingExpression, SortDirectionEnum sortDir = SortDirectionEnum.Ascending, string includeProperties = "")
        {
            int totalCount = default;
            List<Question> resultList = new List<Question>();
            try
            {
                IQueryable<Question> query = AppDbContext.Questions.Where(q => q.IsDeleted == false);

               
                totalCount = AppDbContext.Questions.Count();
                query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

                switch (sortDir)
                {
                    case SortDirectionEnum.Ascending:
                        if (skipCount == 0)
                            query = query.OrderBy(sortingExpression).Take(takeCount);
                        else
                            query = query.OrderBy(sortingExpression).Skip(skipCount).Take(takeCount);
                        break;
                    case SortDirectionEnum.Descending:
                        if (skipCount == 0)
                            query = query.OrderByDescending(sortingExpression).Take(takeCount);
                        else
                            query = query.OrderByDescending(sortingExpression).Skip(skipCount).Take(takeCount);
                        break;
                    default:
                        break;
                }
                resultList = query.ToList();
            }
            catch (Exception ex)
            {

            }
            return (resultList, totalCount);

        }

    }
}