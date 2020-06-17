using Impacta.Editora.Business;
using Impacta.Editora.DataADO;
using Impacta.Editora.Model;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using System.Linq;
using System.Net;

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
        public ActionResult CadastrarEditora(Model.EditoraMOD editora)
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

        public ActionResult ListarEditoras()
        {
            List<EditoraMOD> listaEditoras = null;

            EditoraDATA data = new EditoraDATA();

            try
            {
                //Preencher a lista com a consulta ao banco
                listaEditoras = data.ReadAll();

            }
            catch (Exception ex)
            {

                ViewBag.Falha = "O cadastro da tarefa não foi realizado";

                return RedirectToAction("Index");
            }

            return View(listaEditoras);
        }
    }
}