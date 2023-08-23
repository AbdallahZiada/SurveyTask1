using BusinessLayer.Common.Enums;
using BusinessLayer.Dtos;
using BusinessLayer.Dtos.Enums;
using BusinessLayer.Repository.Repository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Survey
{
    public class SurveyAppService : ISurveyAppService
    {

        public async Task<(List<QuestionDTO> ListQuestion, int TotalCount)> GetQuestionsList(string questionBody, string jtSorting, int jtStartIndex, int jtPageSize)
        {
            (List<QuestionDTO> ListQuestion, int TotalCount) result = (null, 0);
            try
            {
                #region Sorting Direction
                string[] sortingName = jtSorting.Split(' ');
                string columnName = sortingName[0];
                string sortingDirection = sortingName[1];
                SortDirectionEnum sortingDir = SortDirectionEnum.Ascending;
                switch (sortingDirection)
                {
                    case "ASC":
                        sortingDir = SortDirectionEnum.Ascending;
                        break;
                    case "DESC":
                        sortingDir = SortDirectionEnum.Descending;
                        break;
                    default:
                        break;
                }
                #endregion
                JTableSearchDTO<QuestionDTO> jtableSearchDTO = new JTableSearchDTO<QuestionDTO>()
                {
                    jTableStartIndex = jtStartIndex,
                    jTablePageSize = jtPageSize,
                    sortDirection = sortingDir,
                    sortingField = columnName,

                };
                result = await GetQuestionsJTableList(jtableSearchDTO);
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<(List<QuestionDTO> ListQuestion, int TotalCount)> GetQuestionsJTableList(JTableSearchDTO<QuestionDTO> jTableSearch)
        {
            (List<QuestionDTO> ListQuestion, int TotalCount) result = (null, 0);
            try
            {
                QuestionsRepository _questionsRepository = new QuestionsRepository(new AutomatedSurveysContext());
                result = await _questionsRepository.GetQuestionsList(jTableSearch);
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public async Task<ResponseViewModel> AddNewQuestion(string questionBody)
        {
            ResponseViewModel response = new ResponseViewModel { Status = ResponseStatusEnum.Error, Message = "Faild" };
            try
            {
                QuestionsRepository _questionsRepository = new QuestionsRepository(new AutomatedSurveysContext());
                Question question = new Question() 
                { 
                    Body = questionBody,
                    IsDeleted = false
                }; 
                _questionsRepository.Create(question);
                response.Status = ResponseStatusEnum.Success;
                response.Message = "Servies Is Added Successfully";
                return response;
            }
            catch (Exception ex)
            {
                return response;
            }
        }

        public async Task<ResponseViewModel> EditQuestion(QuestionDTO questionDto)
        {
            ResponseViewModel response = new ResponseViewModel { Status = ResponseStatusEnum.Error, Message = "Faild To Edit This Question" };
            try
            {
                QuestionsRepository _questionsRepository = new QuestionsRepository(new AutomatedSurveysContext());
                Question question = _questionsRepository.Find(questionDto.Id);
                question.Body = questionDto.Body;
                if (!_questionsRepository.Commit())
                {
                    return response;
                }
                response.Status = ResponseStatusEnum.Success;
                response.Message = "Servies Is Updated Successfully";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                return response;
            }
        }

        public async Task<ResponseViewModel> DeleteQuestion(int questionid)
        {
            ResponseViewModel response = new ResponseViewModel { Status = ResponseStatusEnum.Error, Message = "Faild To Delete This Question" };
            try
            {
                QuestionsRepository _questionsRepository = new QuestionsRepository(new AutomatedSurveysContext());
                Question question = _questionsRepository.Find(questionid);
                question.IsDeleted = true;
                if (!_questionsRepository.Commit())
                {
                    return response;
                }
                response.Status = ResponseStatusEnum.Success;
                response.Message = "Servies Is Deleted Successfully";
                return response;
            }
            catch (Exception ex)
            {
            }
            return response;
        }

        public async Task<ResponseViewModel> ValidatingAddingQuestion(string questionBody)
        {
            ResponseViewModel response = new ResponseViewModel { Status = ResponseStatusEnum.Error, Message = "Faild" };
            try
            {
                if(!string.IsNullOrWhiteSpace(questionBody))
                {
                    response.Status = ResponseStatusEnum.Success;
                }
            }
            catch (Exception ex)
            {
            }
            return response;
        }

        public async Task<ResponseViewModel> ValidatingEditingQuestion(QuestionDTO question)
        {
            ResponseViewModel response = new ResponseViewModel { Status = ResponseStatusEnum.Error, Message = "Faild to edit this question" };
            try
            {
                if(question.Id == null)
                {
                    return response;
                }
                if (string.IsNullOrWhiteSpace(question.Body))
                {
                    return response;
                }
                response.Status = ResponseStatusEnum.Success;
            }
            catch (Exception ex)
            {
            }
            return response;
        }

        public async Task<ResponseViewModel> ValidatingDeletingQuestion(int questionid)
        {
            ResponseViewModel response = new ResponseViewModel { Status = ResponseStatusEnum.Error, Message = "Faild to delete this question" };
            try
            {
                if(questionid <= 0)
                {
                    return response;
                }
                response.Status = ResponseStatusEnum.Success;
            }
            catch (Exception ex)
            {
            }
            return response;
        }
    }

}
