using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using jsonApp.Models;

namespace jsonApp.Models
{
    public class autoModel
    {
        private string _id_auto;
        private string _marca;
        private string _modello;
        private string _costo;
        private string _categoria;
        private string _alimentazione;
        private datiTecnici datiTec;

        public string Id_auto { get => _id_auto; set => _id_auto = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modello { get => _modello; set => _modello = value; }
        public string Costo { get => _costo; set => _costo = value; }
        public string Categoria { get => _categoria; set => _categoria = value; }
        public string Alimentazione { get => _alimentazione; set => _alimentazione = value; }
        public datiTecnici DatiTec { get => datiTec; set => datiTec = value; }
    }
}