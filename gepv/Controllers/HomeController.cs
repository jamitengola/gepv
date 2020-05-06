using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gepv.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult Entrar(string nome, string senha)
        {
            if (nome == "Teste" && senha == "Teste") {
               return  RedirectToAction("Index", "Home");
            }
            else{
                ViewBag.Erro = "Verifique suas credenciais";
                return RedirectToAction("Login","Account", new { returnUrl = "Verifique suas credenciais" });
            }
          
        }
    }
}