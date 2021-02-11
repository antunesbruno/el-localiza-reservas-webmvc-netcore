using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Web.Models
{
    public class ModeloViewModel
    {
        public string ModeloId { get; set; }
        public string Nome { get; set; }
        public string MarcaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ImagePath { get; set; }
        public MarcaViewModel Marca { get; set; }
    }
}
