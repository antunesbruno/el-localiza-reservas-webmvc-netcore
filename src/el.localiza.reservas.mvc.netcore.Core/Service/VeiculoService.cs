using el.localiza.reservas.mvc.netcore.Core.Interfaces;
using el.localiza.reservas.mvc.netcore.DataSource.Requests;
using el.localiza.reservas.mvc.netcore.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Core.Service
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IRefitReservasApi _httpClientApi;

        public VeiculoService(IRefitReservasApi httpClientApi)
        {
            _httpClientApi = httpClientApi;
        }

        /// <summary>
        /// Obtem os veiculos por categoria na API
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public async Task<IList<VeiculoModel>> ObterDadosVeiculoPorCategoriaAsync(int categoria)
        {
            var result = await _httpClientApi.ObterDadosVeiculosCategoriaAsync(categoria);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<VeiculoModel>>(response);
            }

            return null;
        }

        /// <summary>
        /// Obter veiculo pelo Id
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <returns></returns>
        public async Task<VeiculoModel> ObterVeiculoPorIdAsync(string idVeiculo)
        {
            var result = await _httpClientApi.ObterVeiculoIdAsync(idVeiculo);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<VeiculoModel>(response);
            }

            return null;
        }

    }
}
