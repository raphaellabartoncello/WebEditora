using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.Editora.Web.Controllers
{
    public class EditoraController : Controller
    {
        // GET: Editora
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarEditora()
        {
            return View();
        }
    }
}