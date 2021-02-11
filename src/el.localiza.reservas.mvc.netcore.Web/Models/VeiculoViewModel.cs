using el.localiza.reservas.mvc.netcore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Web.Models
{
    public class VeiculoViewModel
    {
        public string IdVeiculo { get; set; }
        public string Placa { get; set; }
        public string MarcaId { get; set; }
        public string ModeloId { get; set; }
        public int Ano { get; set; }
        public double ValorHora { get; set; }
        public CombustivelEnum Combustivel { get; set; }
        public int LimitePortaMalas { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public DateTime DataCriacao { get; set; }
        public MarcaViewModel Marca { get; set; }
        public ModeloViewModel Modelo { get; set; }

        public string ValorHoraFormatado { get { return $"R${this.ValorHora} P/ Hora"; } }
        public string CombustivelDescricao { get { return DescricaoCombustivel.ToDescriptionString(Combustivel); } }
        public string CategoriaDescricao { get { return DescricaoCategoria.ToDescriptionString(Categoria); } }
    }
}
