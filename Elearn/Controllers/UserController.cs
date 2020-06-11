using Elearn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Elearn.Controllers
{
    public class UserController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public IActionResult GetUsers()
        {
            List<AspNetUsers> users = context.AspNetUsers.Include(x => x.AspNetUserRoles).ThenInclude(a => a.Role).Include(x => x.Unit).Include(x=>x.Category).ToList();
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

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}