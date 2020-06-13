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
    public class TestController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();
        string userId;
        public TestController()
        {

        }

        public IActionResult Index()
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
