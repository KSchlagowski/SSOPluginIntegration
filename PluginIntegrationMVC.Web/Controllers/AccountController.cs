using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult SSOAuthentication(string hmac, string token)
        {
            if (!User.Identity.IsAuthenticated)
            {
                throw new UnauthorizedAccessException();
            }

            //VARIFY HMAC HERE
            var decodedHmac = _decodingService.DecodeHexToString(hmac);

            var userName = User.Identity.Name;
            var payload = new Payload()
            {
                token = token,
                email = "sample@mail.com",
                name = userName,
                link = "http://example.com/profile/user",
                photo = "http://example.com/photo/user.jpg"
            };

            string jsonPayload = JsonSerializer.Serialize(payload);

            var jsonPayloadEncoded = _decodingService.EncodeStringToHex(jsonPayload);
            var hmacEncoded = _decodingService.EncodeStringToHex(hmac);
            //hmacEncoded = hex-encode(hmac-sha256(payload-json, secret-key)) METHOD LIKE THIS SHOULD BE HERE INSTEAD

            Response.Redirect("http://commento.io/api/oauth/sso/callback?payload="+ jsonPayloadEncoded + "&hmac=" + hmacEncoded);
            
            return new JsonResult(1);
        }

        public IActionResult Index() 
        {
            return View();
        }
    }
}