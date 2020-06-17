using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.Editora.Web.Controllers
{
    public class InicioController : Controller
    {
        //Por default todos os métodos do controller respondem pelo verbo GT do Http
        //[HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}