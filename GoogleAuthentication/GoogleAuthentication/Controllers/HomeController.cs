using Google.Authenticator;
using GoogleAuthentication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            if (User.Identity.IsAuthenticated) {
                var id = User.Identity.GetUserId();
                TwoFactorAuthenticator autenticador = new TwoFactorAuthenticator();
                var setupInfo = autenticador.GenerateSetupCode("GoogleAuthentication", User.Identity.Name, id, 300, 300);

                ViewBag.qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;
                ViewBag.manualEntrySetupCode = setupInfo.ManualEntryKey;

                bool pinCorrecto = autenticador.ValidateTwoFactorPIN(id, "123456");


                // ApplicationDbContext db = new ApplicationDbContext();


            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}