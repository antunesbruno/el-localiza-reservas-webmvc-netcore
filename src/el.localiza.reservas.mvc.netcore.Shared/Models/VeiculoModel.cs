using el.localiza.reservas.mvc.netcore.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.mvc.netcore.Shared.Models
{
    public class VeiculoModel
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
        public MarcaModel Marca { get; set; }
        public ModeloModel Modelo { get; set; }
    }
}
