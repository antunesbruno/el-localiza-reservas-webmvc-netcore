using el.localiza.reservas.mvc.netcore.Shared.Models;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.DataSource.Requests
{
    public interface IRefitReservasApi
    {
        #region Veiculo

        [Get("/veiculos")]
        Task<HttpResponseMessage> ObterDadosVeiculosCategoriaAsync(int categoria);

        [Get("/veiculos/{idVeiculo}")]
        Task<HttpResponseMessage> ObterVeiculoIdAsync(string idVeiculo);        

        [Post("/veiculos/criar")]
        Task<HttpResponseMessage> CriarVeiculo([Body] VeiculoModel veiculoModel);

        [Post("/veiculos/atualizar")]
        Task<HttpResponseMessage> AtualizarVeiculo([Body] VeiculoModel veiculoModel);

        [Delete("/veiculos")]
        Task<HttpResponseMessage> ExcluirVeiculo(Guid veiculoId);

        #endregion

        #region Usuario

        [Get("/usuarios")]
        Task<HttpResponseMessage> ObterTodosUsuariosPorPerfil(int perfil);

        [Post("/usuarios/criar")]
        Task<HttpResponseMessage> CriarUsuario([Body(BodySerializationMethod.Serialized)] UsuarioModel usuarioModel);

        [Post("/usuarios/atualizar")]
        Task<HttpResponseMessage> AtualizarUsuario([Body] UsuarioModel usuarioModel);

        [Delete("/usuarios")]
        Task<HttpResponseMessage> ExcluirUsuario(Guid usuarioId);

        #endregion

        #region Modelo

        [Post("/modelos/criar")]
        Task<HttpResponseMessage> CriarModelo([Body] ModeloModel modeloModel);

        [Post("/modelos/atualizar")]
        Task<HttpResponseMessage> AtualizarModelo([Body] ModeloModel modeloModel);

        [Delete("/modelos")]
        Task<HttpResponseMessage> ExcluirModelo(Guid modeloId);

        #endregion

        #region Marca

        [Post("/marcas/criar")]
        Task<HttpResponseMessage> CriarMarca([Body] MarcaModel marcaModel);

        [Post("/marcas/atualizar")]
        Task<HttpResponseMessage> AtualizarMarca([Body] MarcaModel marcaModel);

        [Delete("/marcas")]
        Task<HttpResponseMessage> ExcluirMarca(Guid marcaId);

        #endregion

        #region Clientes

        [Post("/clientes/criar")]
        Task<HttpResponseMessage> CriarCliente([Body] ClienteModel clienteModel);

        [Post("/clientes/atualizar")]
        Task<HttpResponseMessage> AtualizarCliente([Body] ClienteModel clienteModel);

        [Delete("/clientes")]
        Task<HttpResponseMessage> ExcluirCliente(Guid clienteId);

        #endregion
    }
}
