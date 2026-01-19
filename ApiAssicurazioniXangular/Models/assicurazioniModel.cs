using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiFumetti22.Models
{
    public class assicurazioniModel
    {
        private string codSede;
        private string nomeSede;
        private string responsabileSede;
        private string cittaSede;
        private string codTipoAssicurazione;

        public string CodSede { get => codSede; set => codSede = value; }
        public string NomeSede { get => nomeSede; set => nomeSede = value; }
        public string ResponsabileSede { get => responsabileSede; set => responsabileSede = value; }
        public string CittaSede { get => cittaSede; set => cittaSede = value; }
        public string CodTipoAssicurazione { get => codTipoAssicurazione; set => codTipoAssicurazione = value; }
    }
}