using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.mvc.netcore.Shared.Models
{
    public class ModeloModel
    {
        public string ModeloId { get; set; }
        public string Nome { get; set; }
        public string MarcaId { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ImagePath { get; set; }
        public MarcaModel Marca { get; set; }
    }
}
