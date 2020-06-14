using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

using System.Collections.Generic;
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

        public IActionResult RemoveTestCategory(int id)
        {
            TestCategory category = context.TestCategory.Where(x => x.Id == id).First();
            context.TestCategory.Remove(category);
            context.SaveChanges();
            return Json("OK");
        }

        public IActionResult GetTests()
        {
            List<Test> tests = new List<Test>();
            string username = this.User.FindFirstValue(ClaimTypes.Name);
            AspNetUsers user = context.AspNetUsers.Where(x => x.UserName == username).Include(x => x.Unit).First();
            Unit unit = context.Unit.Where(x => x.UserId == user.Id).First();
          
            return Json(tests);
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
            test.CategoryId = categoryId;

            context.Test.Add(test);
            context.SaveChanges();

            return Json("OK");
        }


        public IActionResult Create()
        {
            return View();
        }

    }
}