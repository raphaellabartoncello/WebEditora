using Impacta.Editora.Business;
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

        [HttpPost]
        public ActionResult CadastrarEditora(Model.Editora editora)
        {
            //objeto BUS
            EditoraBUS editoraBUS = new EditoraBUS();

            if (!editoraBUS.Cadastrar(editora))
            {
                //A ViewBag é uma estrutura dinâmica para criação de propriedades, assim é possível enviar informações da Controller para View - A ViewBag se mantém na memória durante no máximo um POST
                ViewBag.ResultadoCadastro = "O cadastro da editora não foi realizado.";

                return View(editora);
            }

            ViewBag.ResultadoCadastroSucesso = "O cadastro da editora foi realizado com sucesso.";

            //ViewData[string key] é uma estrutura dinâmica mas ao invés de criar propriedade (como a ViewBag) ela fornece m identificador, chamados de chave (key) para armazenar o valor - A ViewData se mantém na memória durante no máximo um POST (um redirecionamento)
            ViewData["ResultadoCadastro"] = "Cadastro realizado com sucesso";

            //TempData consegue se manter na memória por mais de um redirecionamento
            TempData["NovaMensagem"] = "Você incluiu um novo cadastro!";

            return View();

        }
    }
}