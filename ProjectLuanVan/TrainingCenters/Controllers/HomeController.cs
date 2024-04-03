using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TrainingCenters.Controllers
{
    public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("{demo}")]
        //public IActionResult Search(string demo)
        //{
        //    AcademicScore score = new AcademicScore();
        //    score.EmployeeId = 2;
        //    score.ScoreName = "Final";
        //    //AcademicScore  = JsonConvert.DeserializeObject<AcademicScore>(demo);
        //    return Ok(_unitOfWork.AcademicScore.Search(score));
        //}
        public IActionResult Privacy()
        {
            return View();
        }
    }
}