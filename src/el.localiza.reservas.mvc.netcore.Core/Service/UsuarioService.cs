using el.localiza.reservas.mvc.netcore.Core.Interfaces;
using el.localiza.reservas.mvc.netcore.DataSource.Requests;
using el.localiza.reservas.mvc.netcore.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Core.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRefitReservasApi _httpClientApi;

        public UsuarioService(IRefitReservasApi httpClientApi)
        {
            _httpClientApi = httpClientApi;
        }
     
        public async Task<IList<UsuarioModel>> ObterTodosUsuariosPorPerfil(int perfil)
        {
            var result = await _httpClientApi.ObterTodosUsuariosPorPerfil(perfil);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<UsuarioModel>>(response);
            }

            return null;
        }

        public async Task<UsuarioModel> CriarNovoUsuario(UsuarioModel model)
        {
            var result = await _httpClientApi.CriarUsuario(model);

            if (result.StatusCode.Equals(HttpStatusCode.Created))
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UsuarioModel>(response);
            }

            return null;
        }
        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel model)
        {
            var result = await _httpClientApi.AtualizarUsuario(model);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UsuarioModel>(response);
            }

            return null;
        }

        public async Task<string> AtualizarUsuario(string id)
        {
            var result = await _httpClientApi.ExcluirUsuario(Guid.Parse(id));

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<string>(response);
            }

            return string.Empty;
        }

    }
}
