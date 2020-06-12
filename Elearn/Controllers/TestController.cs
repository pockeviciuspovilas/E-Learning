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
    public class TestController : Controller
    {
        aspnetElearnContext context = new aspnetElearnContext();

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