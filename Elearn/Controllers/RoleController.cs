using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Elearn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public IActionResult GetAspRoles()
        {
            string username = this.User.FindFirstValue(ClaimTypes.Name);

            AspNetUsers user = context.AspNetUsers.Where(x => x.UserName == username).Include(x => x.AspNetUserRoles).First();
            if (user.AspNetUserRoles.First().RoleId == context.AspNetRoles.Where(x=>x.Name == "Admin").First().Id)
            {
                return Json(context.AspNetRoles.Where(x=>x.Name != "SuperAdmin").ToList());
            }

            return Json(context.AspNetRoles.ToList());
        }
        public IActionResult GetUnitCategories(string userId)
        {
            var user = context.AspNetUsers.Where(x => x.Id == userId).Include(x=>x.Unit).Include(x=>x.Category).First();
            if (user.Unit.Count > 0)
            {
                return Json(context.UnitCategory.Where(x => x.UnitId == user.Unit.First().Id).ToList());
            }
            else
            {
                return Json(context.UnitCategory.Where(x => x.UnitId == user.Category.UnitId).ToList());
            }
            
        }
    }
}