//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.Json.Serialization;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using TrainingCenters.Interfaces;
//using TrainingCenters.Models;
//using Newtonsoft.Json;
//using TrainingCenters.Models.ModelView;

//namespace TrainingCenters.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class AcademicScoreController(IUnitOfWork unit) : Controller
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public AcademicScoreController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        public IActionResult Index()
//        {
//            TempData["menu"] = "AcademicScore";
//            return View();
//        }
//        public IActionResult LoadingData(string search)
//        {
//            var skip = Request.Form["start"];
//            var length = Request.Form["length"];
//            object dataList;
//            if (search == null)
//            {
//                AcademicScore academicScore1 = new AcademicScore();
//                dataList = _unitOfWork.AcademicScore.LoadingDataTableView(academicScore1, Convert.ToInt32(skip), Convert.ToInt32(length));
//                return Ok(dataList);
//            }
//            //AcademicScore academicScore = new AcademicScore();
//            AcademicScore academicScore = new AcademicScore();
//            academicScore = JsonConvert.DeserializeObject<AcademicScore>(search);
//            dataList = _unitOfWork.AcademicScore.LoadingDataTableView(academicScore, Convert.ToInt32(skip), Convert.ToInt32(length));
//            return Ok(dataList);
//        }
//        public async Task<IActionResult> GetById(int id)
//        {
//            if (id == null) {
//                string json1 = JsonConvert.SerializeObject(new AcademicScore());
//                return Content(json1, "application/json");
//            }
//            var item = _unitOfWork.AcademicScore.GetById(Convert.ToInt32(id));
//            string json="";
//            if (item != null)
//            {
//                json = JsonConvert.SerializeObject(item);
//            }
//            return Content(json, "application/json");
//        }
//        public async Task<IActionResult> Create(string academicScore)
//        {
//            if (academicScore == null) { return Ok(false); }

//            AcademicScore academicScore1 = new AcademicScore();
//            academicScore1 = JsonConvert.DeserializeObject<AcademicScore>(academicScore);

//            bool item = _unitOfWork.AcademicScore.Create(academicScore1);
//            var a = item;
//            return Ok(item);
//        }
//        public async Task<IActionResult> Update(string academicScore)
//        {
//            if (academicScore == null) { return Ok(false); }

//            AcademicScore academicScore1 = new AcademicScore();
//            academicScore1 = JsonConvert.DeserializeObject<AcademicScore>(academicScore);

//            bool item = _unitOfWork.AcademicScore.Update(academicScore1);
//            var a = item;
//            return Ok(item);
//        }
//        public async Task<IActionResult> GetAcademicScoretView(int id)
//        {
//            if (id == null || id == 0)
//            {
//                return Ok(new AcademicScoreView());
//            }
//            var item = _unitOfWork.AcademicScore.GetAcademicScoreView(Convert.ToInt32(id));
//            return Ok(item);
//        }
//        public async Task<IActionResult> CheckIdAcademicScore(int id)
//        {
//            return Ok(_unitOfWork.AcademicScore.CheckId(id));
//        }
//        public async Task<IActionResult> Delete(int[]? ids)
//        {
//            //Danh sách id cần xóa không rỗng
//            bool dl = false;
//            foreach (int id in ids)
//            {
//                AcademicScore d = _unitOfWork.AcademicScore.GetById(id);
//                dl = _unitOfWork.AcademicScore.Delete(d);
//            }
//            return Ok(dl);
//        }
//    }
//}

