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

namespace Elearn.Controllers
{
    public class ReportController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        public ReportController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserReport(string userId)
        {

            
            userId = userId !=null? userId : HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewData["User"] = context.AspNetUsers.Where(x => x.Id == userId).SingleOrDefault().UserName;
            var assignWithResults = context.Asign.Include(x => x.Result).Include(y => y.Test).Include(z=> z.Applicant);
            var query = (from asigns in assignWithResults
                        where asigns.ApplicantId == userId
                        select asigns).ToList();
                    
            return View(query);
        }
    }
}
