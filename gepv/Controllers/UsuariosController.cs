using gepv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gepv.Controllers
{
    public class UsuariosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Usuarios
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        [Authorize]
        public ActionResult NivelAcesso()
        {
            return View(db.Users.ToList());
        }
    }
}