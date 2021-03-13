﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyHR_Web.Models;
using MyHR_Web.ViewModel;
using prjCoreDemo.ViewModel;

namespace MyHR_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BulletInList()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Login()
        {
            //if (string.IsNullOrEmpty(HttpContext.Session.GetString(CDictionary.LOGIN_AUTHTICATION_CODE)))
            //{
            //    Random rm = new Random();
            //    string code = rm.Next(0, 10).ToString() + rm.Next(0, 10).ToString()
            //        + rm.Next(0, 10).ToString() + rm.Next(0, 10).ToString();

            //    HttpContext.Session.SetString(CDictionary.LOGIN_AUTHTICATION_CODE, code);
            //}


            return PartialView();

        }


        [HttpPost]
        public IActionResult Login(CLoginViewModel p)
        {
            //if (!p.txtCode.Equals(HttpContext.Session.GetString(CDictionary.LOGIN_AUTHTICATION_CODE)))
            //{
            //    ViewData[CDictionary.LOGIN_AUTHTICATION_CODE] = HttpContext.Session.GetString(CDictionary.LOGIN_AUTHTICATION_CODE);
            //    return View();
            //}

            ViewData[CDictionary.LOGIN_AUTHTICATION_CODE] = HttpContext.Session.GetString(CDictionary.LOGIN_AUTHTICATION_CODE);


            TUser user = (new dbMyCompanyContext()).TUsers.FirstOrDefault(c =>
            c.CEmployeeId.Equals(p.txtAccount) && c.CPassWord.Equals(p.txtPassword));

            if (user != null)
            {
                HttpContext.Session.SetString(CDictionary.CURRENT_LOGINED_USERNAME, user.CEmployeeName);
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Calendar()
        {
            ViewData["events"] = new[]
            {
                new CalendarEvent{ Id=1, Title="hang out with Jack", StartDate="2021-03-07"},
                new CalendarEvent{ Id=2, Title="zoom meeting(TSMC project)", StartDate= "2021-03-25"}
            };
            return View();
        }
        public IActionResult ToDoList()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}