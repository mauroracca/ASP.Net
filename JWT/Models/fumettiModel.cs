using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsRest.Models
{
    public class fumettiModel
    {
        private int _id;
        private string _title;
        private string _casaEd;

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string CasaEd { get => _casaEd; set => _casaEd = value; }
    }
}