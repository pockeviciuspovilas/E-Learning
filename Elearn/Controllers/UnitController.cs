using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Elearn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Elearn.DTO;
using System.Security.Cryptography;

namespace Elearn.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
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
            if (context.Unit.Include(x => x.TestCategory).Include(x => x.Subscription).Include(x => x.Design).Include(x => x.User).AsNoTracking().Where(x => x == parsedUnit).ToList().Count > 0)
            {
                Unit contUnit = context.Unit.Include(x => x.TestCategory).ThenInclude(x=>x.Test).ThenInclude(x=>x.Asign)
                    .Include(x => x.Subscription)
                    .Include(x => x.Design)
                    .Include(x => x.User)
                
                    .Where(x => x == parsedUnit)
                    .First();


                context.Unit.Remove(contUnit);
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


        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Design()
        {
            return View();
        }

        public IActionResult CreateUnitDesign(int id, string backgroundColor, string navColor, string navbarImage, string theadColor, string tbodyColor)
        {
            Designer designer = new Designer();
            designer.Id = id;
            designer.BackgroundColor = backgroundColor;
            designer.NavColor = navColor;
            designer.NavbarImage = navbarImage;
            designer.TheadColor = theadColor;
            designer.TbodyColor = tbodyColor;

            Unit unit = context.Unit.Where(x => x.Id == id).Include(x => x.Design).First();
            Design design = new Design();
            design.Json = JsonConvert.SerializeObject(designer, Formatting.None);
            unit.Design = design;


            context.SaveChanges();

            return Json("OK");
        }

        public IActionResult GetUnitCategories(int unitId)
        {

            return Json("");
        }
        public IActionResult GetUnit(int unitId)
        {
            return Json(context.Unit.Where(x => x.Id == unitId).Include(x => x.User).First());
        }

        public IActionResult UpdateUnit(string name, string description, string user, int id)
        {
            AspNetUsers parsedUser = JsonConvert.DeserializeObject<AspNetUsers>(user);

            Unit unit = context.Unit.Where(x => x.Id == id).First();
            unit.Name = name;
            unit.Description = description;
            unit.CreateTime = DateTime.Now;
            unit.UserId = parsedUser.Id;
            context.SaveChanges();

            return Json("OK");
        }

        public IActionResult InsertUnit(string name, string description, string user)
        {
            AspNetUsers parsedUser = JsonConvert.DeserializeObject<AspNetUsers>(user);

            Unit unit = new Unit();
            unit.Name = name;
            unit.Description = description;
            unit.CreateTime = DateTime.Now;
            unit.UserId = parsedUser.Id;

            context.Unit.Add(unit);

            context.SaveChanges();

            return Json("OK");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}