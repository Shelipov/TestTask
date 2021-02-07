using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Helpers;
using TestTask.Models;
using TestTask.Models.DataTransferObjects.Interfaces;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAddData _data;
        public HomeController(IAddData data)
        {
            _data = data;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.SortByMessageID = Message.SortByMessageID;
            ViewBag.SortByLastChangedOn = Message.SortByLastChangedOn;
            return View(await _data.Execute());
        }

        public IActionResult About()
        {
            ViewData["Message"] = Message.About;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = Message.Contact;

            return View();
        }

        public async Task<IActionResult> Check(bool MessageID,bool LastChangedOn)
        {
            await _data.Execute(MessageID, LastChangedOn);
            return Redirect("~/Home/Index");
        }

        public async Task<IActionResult> CreateMessage(string userName,string message)
        {

            await _data.Execute(userName, message, this.HttpContext.Session.Id);
            return Redirect("~/Home/Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
