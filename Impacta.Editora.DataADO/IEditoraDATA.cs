using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.Editora.DataADO
{
    interface IEditoraDATA
    {
        bool Save(Model.EditoraMOD editora);

        Model.EditoraMOD GetEditora(int id);

        List<Model.EditoraMOD> GetList();

        bool Delete(int id);


    }
}
