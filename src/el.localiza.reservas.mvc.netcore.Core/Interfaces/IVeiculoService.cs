using el.localiza.reservas.mvc.netcore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Core.Interfaces
{
    public interface IVeiculoService
    {
        Task<IList<VeiculoModel>> ObterDadosVeiculoPorCategoriaAsync(int categoria);
        Task<VeiculoModel> ObterVeiculoPorIdAsync(string idVeiculo);
    }
}
