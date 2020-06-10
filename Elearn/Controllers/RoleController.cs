using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;

namespace Elearn.Controllers
{
    public class RoleController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public IActionResult GetAspRoles()
        {
            return Json(context.AspNetRoles.ToList());
        }
    }
}