using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Web.Models
{
    public class ReservaViewModel
    {
        public VeiculoViewModel Veiculo { get; set; }

        public int TotalDiasLocacao { get; set; }
        public double ValorTotalLocacao { get; set; }
        public string IdVeiculo { get; set; }
    }
}
