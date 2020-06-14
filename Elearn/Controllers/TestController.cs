using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Controllers
{
    public class TestController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SaveResults(int assignId, string json, double mark, int usedTime) {
            string username = this.User.FindFirstValue(ClaimTypes.Name);
            AspNetUsers user = context.AspNetUsers.Where(x => x.UserName == username).First();
            Result result = context.Result.Where(x => x.AsignId == assignId).First();

            result.CompleteTime = DateTime.Now;
            result.Json = json;
            result.Mark = mark;
            result.StartTime = result.CompleteTime.AddSeconds(-usedTime);
            context.SaveChanges();

            return Json("OK");
        }

        public IActionResult RemoveTestCategory(int id)
        {
            TestCategory category = context.TestCategory.Where(x => x.Id == id).First();
            context.TestCategory.Remove(category);
            context.SaveChanges();
            return Json("OK");
        }

        public IActionResult Window()
        {
            return View();
        }

        public IActionResult GetTests()
        {
            List<Test> tests = new List<Test>();
            string username = this.User.FindFirstValue(ClaimTypes.Name);
            AspNetUsers user = context.AspNetUsers.Where(x => x.UserName == username).Include(x => x.Unit).Include(x => x.Category).First();
            Unit unit = context.Unit.Where(x => x.UserId == user.Id).First();
          
            return Json(context.Test.ToList());
        }

        public IActionResult GetTest(int assignId)
        {
            Asign asign = new Asign();
            asign = context.Asign.Where(x => x.Id == assignId).Include(x => x.Test).First();
          
            return Json(asign);
        }

        public IActionResult GetTestCategories()
        {
            string username = this.User.FindFirstValue(ClaimTypes.Name);
            AspNetUsers user = context.AspNetUsers.Where(x => x.UserName == username).Include(x => x.Unit).First();
            Unit unit = context.Unit.Where(x => x.UserId == user.Id).First();
            return Json(context.TestCategory.Where(x => x.UnitId == unit.Id).ToList());
        }

        public IActionResult EditTestCategory(string name, int id)
        {
            TestCategory category = context.TestCategory.Where(x => x.Id == id).First();
            foreach (var cat in context.TestCategory.ToList())
            {
                if (cat.Name == name)
                {
                    return Json("OK");
                }
            }

            category.Name = name;
            context.SaveChanges();
            return Json("OK");
        }


        public IActionResult CreateTestCategory(string name)
        {
            string username = this.User.FindFirstValue(ClaimTypes.Name);

            AspNetUsers user = context.AspNetUsers.Where(x => x.UserName == username).Include(x => x.Unit).First();

            TestCategory testCategory = new TestCategory();

            testCategory.Name = name;
            testCategory.UnitId = user.Unit.First().Id;

            var categories = context.TestCategory.Where(x => x.UnitId == testCategory.UnitId).ToList();
            bool isExists = false;
            foreach (var cat in categories)
            {
                if (cat.Name == name)
                {
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                context.TestCategory.Add(testCategory);
                context.SaveChanges();
            }


            return Json("OK");
        }

        public IActionResult CreateTest(string name, int categoryId, int duration, string json)
        {
            var username = this.User.FindFirstValue(ClaimTypes.Name);

            AspNetUsers user = context.AspNetUsers.Where(x => x.UserName == username).First();

            Test test = new Test();
            test.InsertTime = DateTime.Now;
            test.Json = json;
            test.UserId = user.Id;
            test.Name = name;
            test.CategoryId = categoryId;

            context.Test.Add(test);
            context.SaveChanges();

            return Json("OK");
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult MyTests()
        {
            var assignWithResults = context.Asign.Include(x => x.Result).Include(y => y.Test).Include(z=> z.Applicant);
            var query = (from asigns in assignWithResults
                        where asigns.ApplicantId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                        select asigns).ToList();
                    
            return View(query);
        }
    }
}
