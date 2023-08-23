using BusinessLayer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Survey
{
    public interface ISurveyAppService
    {
        Task<(List<QuestionDTO> ListQuestion, int TotalCount)> GetQuestionsList(string questionBody, string jtSorting, int jtStartIndex, int jtPageSize);
        Task<(List<QuestionDTO> ListQuestion, int TotalCount)> GetQuestionsJTableList(JTableSearchDTO<QuestionDTO> jTableSearch);
        Task<ResponseViewModel> AddNewQuestion(string questionBody);
        Task<ResponseViewModel> EditQuestion(QuestionDTO question);
        Task<ResponseViewModel> DeleteQuestion(int questionId);
        Task<ResponseViewModel> ValidatingAddingQuestion(string questionBody);
        Task<ResponseViewModel> ValidatingEditingQuestion(QuestionDTO question);
        Task<ResponseViewModel> ValidatingDeletingQuestion(int questionId);
    }
}
