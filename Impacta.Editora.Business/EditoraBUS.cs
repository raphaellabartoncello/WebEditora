using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Impacta.Editora.DataADO;

namespace Impacta.Editora.Business
{
    public class EditoraBUS
    {
        EditoraDATA objDataADO = null;

        public bool Cadastrar(Model.Editora editora)
        {
            objDataADO = new EditoraDATA();

            return objDataADO.Save(editora);
        }


    }
}