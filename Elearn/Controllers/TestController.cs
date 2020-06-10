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
            var query = from asigns in context.Asign
                        where asigns.ApplicantId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                        let results = asigns.Result
                        let test = asigns.Test
                        from result in results
                        select new Tuple<Result,Test>(result,test);
                    
            var list = query.ToList();
            return View(list);
        }

    }
}
