using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Elearn.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Elearn.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public ReportController()
        {
            
        }

        public IActionResult Index()
        {
            var currentUser = context.AspNetUsers.Where(x => x.Id == HttpContext.User
                                                .FindFirst(ClaimTypes.NameIdentifier).Value)
                                                .Include("Unit")
                                                .SingleOrDefault();
                                                
            var unitUsers = context.AspNetUsers.Where(x => x.Unit.SingleOrDefault().Id == currentUser.Unit.FirstOrDefault().Id).ToList();
            var unitTestCaterogries = context.TestCategory.Where(x => x.UnitId == currentUser.Unit.SingleOrDefault().Id).ToList();
            ViewData["TestCategory"] = new SelectList(unitTestCaterogries, "Id", "Name");
            return View(unitUsers);
        }
        public IActionResult UserReport(string userId)
        {
            userId = userId !=null? userId : HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewData["User"] = context.AspNetUsers.Where(x => x.Id == userId).SingleOrDefault().UserName;
            var assignWithResults = context.Asign.Include(x => x.Result).Include(y => y.Test).Include(z=> z.Applicant);
            var query = (from asigns in assignWithResults
                        where asigns.ApplicantId == userId
                        select asigns).ToList();
                    
            return View(query);
        }
        public IActionResult TimeReport()
        {
            
            if(Request.Form.ContainsKey("Begin")&&Request.Form.ContainsKey("End"))
            {
                DateTime begin = DateTime.Parse(Request.Form["Begin"]);
                DateTime end = DateTime.Parse(Request.Form["End"]);
                ViewData["begin"] = begin.ToString();
                ViewData["end"] = end.ToString();
            

            var assignWithResults = context.Asign.Include(x => x.Result).Include(y => y.Test).Include(z=> z.Applicant);

            var query = (from asign in assignWithResults
                        where (asign.AsignerId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value && asign.InsertTime >= begin && asign.InsertTime <= end)
                        select asign).ToList();
                    
            if(Request.Form.Keys.Contains("showReport"))
                {
                    return View(query);
                }
                if(Request.Form.Keys.Contains("downloadReport"))
                {   
                    return new ViewAsPdf("TimeReport", query, ViewData) { FileName = "TimeReport.pdf" };
                }
            }
            return View();

        }
        public IActionResult CategoryReport()
        {
            int categoryId; 
            if(int.TryParse(Request.Form["TestCategory"], out categoryId))
            {
                    var completedCountList = new List<int>();
                    var averageList = new List<double>();
                    var participantCountList = new List<int>();
                    var tests = context.Test.Where(x => categoryId == x.CategoryId).ToList();
                    foreach (var test in tests)
                    {
                        var assigns = context.Asign.Where(x => test.Id == x.TestId).Include("Result").ToList();
                        participantCountList.Add(assigns.Count);
                        var completedCount = assigns.Where(x => x.Result.Count != 0 && x.Result.SingleOrDefault().Mark>=0).Count();
                        completedCountList.Add(completedCount);
                        var average = assigns.Where(x => x.Result.Count != 0 && x.Result.SingleOrDefault().Mark>=0).Select(y => y.Result.SingleOrDefault().Mark).Sum() / completedCount;
                        averageList.Add(average);
                    }

                    ViewData["completedCount"] = completedCountList;
                    ViewData["averageList"] = averageList;
                    ViewData["participantCountList"] = participantCountList;
                if(Request.Form.Keys.Contains("showReport"))
                {
                    return View(tests);
                }
                if(Request.Form.Keys.Contains("downloadReport"))
                {   
                    return new ViewAsPdf("CategoryReport", tests, ViewData) { FileName = "CategoryReport.pdf" };
                }
            }
            return RedirectToAction("Index","Report");

        }


        public IActionResult SaveAsPdfCategoryReport(string userId)
        {

            userId = userId !=null? userId : HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewData["User"] = context.AspNetUsers.Where(x => x.Id == userId).SingleOrDefault().UserName;
            var assignWithResults = context.Asign.Include(x => x.Result).Include(y => y.Test).Include(z=> z.Applicant);
            var query = (from asigns in assignWithResults
                        where asigns.ApplicantId == userId
                        select asigns).ToList();
                    


            return new ViewAsPdf("CategoryReport", query,ViewData) { FileName = "CategoryReport.pdf" };
        }


        public IActionResult SaveAsPdfUserReport(string userId)
        {

            userId = userId !=null? userId : HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewData["User"] = context.AspNetUsers.Where(x => x.Id == userId).SingleOrDefault().UserName;
            var assignWithResults = context.Asign.Include(x => x.Result).Include(y => y.Test).Include(z=> z.Applicant);
            var query = (from asigns in assignWithResults
                        where asigns.ApplicantId == userId
                        select asigns).ToList();
                    


            return new ViewAsPdf("UserReport", query,ViewData) { FileName = "UserReport.pdf" };
        }
    }
}
