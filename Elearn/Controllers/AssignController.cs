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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Elearn.Controllers
{
    public class AssignController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public AssignController()
        {

        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult AssignedTests()
        {

            var assignWithResults = context.Asign.Include(x => x.Result).Include(y => y.Test).Include(z=> z.Applicant);

            var query = (from asign in assignWithResults
                        where asign.AsignerId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select asign).ToList();
                    
            return View(query);
        }
        public IActionResult Delete(int id)
        {
            var assignToRemove = context.Asign.Where(x => x.Id == id).SingleOrDefault();
            context.Asign.Remove(assignToRemove);
            context.SaveChanges();

            return RedirectToAction("AssignedTests", "Assign");
        }
        public IActionResult AssignNew()
        {
            var currentUser = context.AspNetUsers.Where(x => x.Id == HttpContext.User
                                                .FindFirst(ClaimTypes.NameIdentifier).Value)
                                                .Include("Unit")
                                                .SingleOrDefault();
                                                
            var unitUsers = context.AspNetUsers.Where(x => x.Unit.SingleOrDefault().Id == currentUser.Unit.FirstOrDefault().Id).ToList();
            var fullTests = context.Test.Include("Category").Where(x => x.Category.Id == currentUser.Unit.FirstOrDefault().Id).ToList();

            ViewData["TestId"] = new SelectList(fullTests, "Id", "Name");
            return View(unitUsers);
        }
        public IActionResult AddNewAssigns()
        {
            int test = int.Parse(Request.Form["Test"]);

            var currentUser = context.AspNetUsers.Where(x => x.Id == HttpContext.User
                                                .FindFirst(ClaimTypes.NameIdentifier).Value)
                                                .Include("Unit")
                                                .SingleOrDefault();

            List<string> userIds = Request.Form.Keys.ToList();
            for(int i=1;i<userIds.Count-1;i++)
            {
                
                Asign newAsign = new Asign()
                {
                    ApplicantId = userIds[i],
                    AsignerId = currentUser.Id,
                    InsertTime = DateTime.UtcNow,
                    TestId = test,
                    ExpireDate = DateTime.UtcNow,

                };
                context.Asign.Add(newAsign);


                Result newResult = new Result()
                {
                    Asign = newAsign,
                    Mark = -1,
                    CompleteTime = DateTime.Parse("01/01/2000 00:00:00"),
                    StartTime = DateTime.Parse("01/01/2000 00:00:00"),
                    Json = "Placeholder"

                };
                context.Result.Add(newResult);

                

                ICollection<Result> resultCol = new List<Result>() {newResult};
                newAsign.Result = resultCol;
                
                
            }
            context.SaveChanges();
            return RedirectToAction("AssignNew", "Assign");
        }

        
    }
}