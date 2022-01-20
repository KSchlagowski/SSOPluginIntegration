using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PluginIntegrationMVC.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace PluginIntegrationMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IDecodingService _decodingService;

        public AccountController(IDecodingService decodingService)
        {
            _decodingService = decodingService;
        }

        public IActionResult TestMethod(string hmac, string token)
        {
            var decodedHex = _decodingService.DecodeHexToString(hmac);
            //VARIFY HMAC
            if (!User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException();
            }
            //    someLabel.Text = Membership.GetUser().Email;

            var us = User;
            var userName = User.Identity.Name;
            var payload = new Payload()
            {
                token = token,
                email = "sample@mail.com",
                name = userName,
                link = "http://example.com/profile/user",
                photo = "http://example.com/photo/user.jpg"
            };

            string jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload);

            var hexPayloadTest = _decodingService.EncodeStringToHex(jsonPayload);
            hmac = _decodingService.EncodeStringToHex(hmac);

            Response.Redirect("http://commento.io/api/oauth/sso/callback?payload="+ hexPayloadTest + "&hmac=" + hmac);
            
            return new JsonResult(1);



            //var user = _userManager.GetUserAsync(HttpContext.User);
            //var userMail = _userManager.GetUserAsync(HttpContext.User)?.Email;
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext()

            //string payload =
            //    "{
            //      "token": "TOKEN",
            //      "email": "user@example.com",
            //      "name":  "User",
            //      "link":  "http://example.com/profile/user",
            //      "photo": "http://example.com/photo/user.jpg",
            //    }";
        }

        

        public IActionResult Index() 
        {
            //var json = GetCurrentUserAsync();
            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            //var user = UserManager.FindById(User.Identity.GetUserId());
            //string mail = (await _userManager.GetUserAsync(HttpContext.User))?.Email
            //var user = await GetCurrentUserAsync();
            //var userId = user.Id;
            return new JsonResult("json");
        }
    }
}