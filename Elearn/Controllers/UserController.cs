using Elearn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Elearn.Controllers
{
    public class UserController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public IActionResult GetUsers()
        {
            List<AspNetUsers> users = context.AspNetUsers.Include(x => x.AspNetUserRoles).ThenInclude(a => a.Role).Include(x => x.Unit).Include(x => x.Category).ToList();
            foreach (var user in users.ToList())
            {
                if (user.AspNetUserRoles.Count > 0)
                {
                    foreach (var role in user.AspNetUserRoles)
                    {
                        if (role.Role.Name == "SuperAdmin")
                        {
                            users.Remove(user);
                        }
                    }
                }
            }

            return Json(users);
        }

        public IActionResult GetAspRoles()
        {
            return Json(context.AspNetRoles.ToList());
        }

        public IActionResult EditUnitCategory(string name, int id)
        {
            UnitCategory category = context.UnitCategory.Where(x => x.Id == id).First();
            foreach (var cat in context.UnitCategory.ToList())
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

        public IActionResult RemoveUnitCategory(int id)
        {
            UnitCategory category = context.UnitCategory.Where(x => x.Id == id).First();
            context.UnitCategory.Remove(category);
            context.SaveChanges();
            return Json("OK");
        }

        public IActionResult CreateUnitCategory(string name)
        {
            string username = this.User.FindFirstValue(ClaimTypes.Name);

            AspNetUsers user = context.AspNetUsers.Where(x => x.UserName == username).Include(x => x.Unit).Include(x=>x.Category).First();

            UnitCategory testCategory = new UnitCategory();

            testCategory.Name = name;
            testCategory.UnitId = user.Unit.First().Id;

            var categories = context.UnitCategory.Where(x => x.UnitId == testCategory.UnitId).ToList();
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
                context.UnitCategory.Add(testCategory);
                context.SaveChanges();
            }


            return Json("OK");
        }

        public IActionResult GetUnitCategories()
        {
            string username = this.User.FindFirstValue(ClaimTypes.Name);
            AspNetUsers user = context.AspNetUsers.Where(x => x.UserName == username).Include(x => x.Unit).Include(x=>x.Category).First();
            Unit unit = context.Unit.Where(x => x.UserId == user.Id).First();
            var categories = context.UnitCategory.Where(x => x.UnitId == unit.Id).ToList();
            return Json(categories);
        }

        public IActionResult GetAvailableUsers()
        {
            List<AspNetUsers> users = context.AspNetUsers.Include(x => x.AspNetUserRoles).ThenInclude(a => a.Role).Include(x => x.Unit).Include(x => x.Category).ToList();
            foreach (var user in users.ToList())
            {
                if (user.AspNetUserRoles.Count > 0)
                {
                    foreach (var role in user.AspNetUserRoles)
                    {
                        if (role.Role.Name == "SuperAdmin")
                        {
                            users.Remove(user);
                        }
                    }
                }
                if (user.Unit.Count > 0)
                {

                    users.Remove(user);

                }
            }

            return Json(users);
        }



        public IActionResult RemoveUser(string postUser)
        {
            AspNetUsers parsedUser = JsonConvert.DeserializeObject<AspNetUsers>(postUser);
            if (context.AspNetUsers.AsNoTracking().Where(x => x == parsedUser).ToList().Count > 0)
            {
                context.AspNetUsers.Remove(parsedUser);
                context.SaveChanges();
                return Json("OK");
            }
            else
            {
                return Json("BAD");
            }

        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateUser(string userId, string roleId, int unitId)
        {
            AspNetUsers user = context.AspNetUsers.Where(x => x.Id == userId).Include(x => x.AspNetUserRoles).Include(x => x.Unit).First();
            user.CategoryId = unitId;
            context.SaveChanges();
            if (user.AspNetUserRoles.Count() > 0)
            {
                user.AspNetUserRoles.Remove(user.AspNetUserRoles.First());
            }

      
            AspNetUserRoles role = new AspNetUserRoles();
          
            role.RoleId = roleId;
            role.UserId = userId;
            context.AspNetUserRoles.Add(role);
            context.SaveChanges();

            return Json("OK");
        }

        public IActionResult Form()
        {
            return View();
        }
    }
}