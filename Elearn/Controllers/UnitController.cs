using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Elearn.Controllers
{
    public class UnitController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public IActionResult GetUnits()
        {
            List<Unit> units = context.Unit.Include(x => x.User).ToList();
            return Json(units);
        }

        public IActionResult RemoveUnit(string postUnit)
        {
            Unit parsedUnit = JsonConvert.DeserializeObject<Unit>(postUnit);
            if (context.Unit.AsNoTracking().Where(x => x == parsedUnit).ToList().Count > 0)
            {
                context.Unit.Remove(parsedUnit);
                context.SaveChanges();
                return Json("OK");
            }
            else
            {
                return Json("BAD");
            }

        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Edit()
        {
            return View();
        }
    }
}