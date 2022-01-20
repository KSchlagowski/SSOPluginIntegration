using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PluginIntegrationMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PluginIntegrationMVC.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SSO()
        {
            //secret - key = hex - decode("001ac5d3c197c4d7493f561f5a696c149b925a07d8bedcee993745f15eb53ac6")

            //def handle-GET:
            //  token = query - param("token")
            //  hmac = hex - decode(query - param("hmac"))

            //  expected - hmac = hmac - sha256(hex - decode(token), secret - key)
            //  if hmac != expected - hmac:
            //    discard and terminate

            //  email, name, link, photo = authenticate()

            //  payload - json = {
            //    "token": token,
            //    "email": email,
            //    "name":  name,
            //    "link":  link,
            //    "photo": photo,
            //  }

            //            hmac = hex - encode(hmac - sha256(payload - json, secret - key))
            //  payload - hex = hex - encode(payload - json)

            //  302 - redirect("https://commento.io/api/oauth/sso/callback?payload=" + payload - hex + "&hmac=" + hmac)
            return new JsonResult(1);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
