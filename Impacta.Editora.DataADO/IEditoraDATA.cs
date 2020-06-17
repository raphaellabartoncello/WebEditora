using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.Editora.DataADO
{
    interface IEditoraDATA
    {
        bool Save(Model.Editora editora);

        Model.Editora GetEditora(int id);

        List<Model.Editora> GetList();

        bool Delete(int id);


    }
}
