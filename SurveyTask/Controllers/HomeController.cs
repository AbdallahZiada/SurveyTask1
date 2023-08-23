using BusinessLayer.Survey;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SurveyTask.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
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
                var questionList = await _surveyAppService.GetQuestionsList(questionBody, jtSorting, jtStartIndex, jtPageSize);
                return Json(new { Result = "OK", Records = questionList.ListQuestion, TotalRecordCount = questionList.TotalCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}