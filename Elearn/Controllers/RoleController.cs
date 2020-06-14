using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elearn.Controllers
{
    public class RoleController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public IActionResult GetAspRoles()
        {
            return Json(context.AspNetRoles.ToList());
        }
        public IActionResult GetUnitCategories(string userId)
        {
            var user = context.AspNetUsers.Where(x => x.Id == userId).Include(x=>x.Unit).First();
            if (user.Unit.Count > 0)
            {
                return Json(context.UnitCategory.Where(x => x.UnitId == user.Unit.First().Id).ToList());
            }
            else
            {
                return Json(new List<int>());
            }
            
        }
    }
}