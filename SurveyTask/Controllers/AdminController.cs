using BusinessLayer.Dtos.Enums;
using BusinessLayer.Dtos;
using BusinessLayer.Survey;
using Microsoft.Owin.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;

namespace SurveyTask.Controllers
{
    public class AdminController : Controller
    {

        public AdminController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public async Task<JsonResult> GetQuestionsGridData(string questionBody, string jtSorting = "Id DESC", int jtStartIndex = 0, int jtPageSize = 10)
        {
            try
            {
                SurveyAppService _surveyAppService = new SurveyAppService();
                (List<QuestionDTO> ListQuestion, int TotalCount) questionList = await _surveyAppService.GetQuestionsList(questionBody, jtSorting, jtStartIndex, jtPageSize);
                return Json(new { Result = "OK", Records = questionList.ListQuestion, TotalRecordCount = questionList.TotalCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<JsonResult> AddQuestion(QuestionRequestDTO request)
        {
            JsonResult returnedResult = Json(new { Result = "Error", Message = "Failed To Add The Question" });
            try
            {
                SurveyAppService _surveyAppService = new SurveyAppService();
                ResponseViewModel response = await _surveyAppService.ValidatingAddingQuestion(request.Body);
                if (response.Status == ResponseStatusEnum.Error)
                {
                    returnedResult = Json(new { Result = "Error", Message = response.Message });
                    return returnedResult;
                }
                ResponseViewModel addNewQuestion = await _surveyAppService.AddNewQuestion(request.Body);
                if (addNewQuestion.Status == ResponseStatusEnum.Success)
                {
                    returnedResult = Json(new { Result = "Ok", Message = addNewQuestion.Message });
                }
            }
            catch (Exception ex)
            {
            }
            return returnedResult;
        }
        [HttpPost]
        public async Task<JsonResult> EditQuestion(QuestionDTO request)
        {
            JsonResult returnedResult = Json(new { Result = "Error", Message = "Failed To Edit The Question" });
            try
            {
                SurveyAppService _surveyAppService = new SurveyAppService();
                ResponseViewModel response = await _surveyAppService.ValidatingEditingQuestion(request);
                if (response.Status == ResponseStatusEnum.Error)
                {
                    returnedResult = Json(new { Result = "Error", Message = response.Message });
                    return returnedResult;
                }
                ResponseViewModel editQuestion = await _surveyAppService.EditQuestion(request);
                if (editQuestion.Status == ResponseStatusEnum.Success)
                {
                    returnedResult = Json(new { Result = "Ok", Message = editQuestion.Message });
                }
            }
            catch (Exception ex)
            {
            }
            return returnedResult;
        }
        [HttpPost]
        public async Task<JsonResult> DeleteQuestion(int id)
        {
            JsonResult returnedResult = Json(new { Result = "Error", Message = "Failed To Delete The Question" });
            try
            {
                SurveyAppService _surveyAppService = new SurveyAppService();
                ResponseViewModel response = await _surveyAppService.ValidatingDeletingQuestion(id);
                if (response.Status == ResponseStatusEnum.Error)
                {
                    returnedResult = Json(new { Result = "Error", Message = response.Message });
                    return returnedResult;
                }
                ResponseViewModel deleteQuestion = await _surveyAppService.DeleteQuestion(id);
                if (deleteQuestion.Status == ResponseStatusEnum.Success)
                {
                    returnedResult = Json(new { Result = "Ok", Message = deleteQuestion.Message });
                }
            }
            catch (Exception ex)
            {
            }
            return returnedResult;
        }

    }
}