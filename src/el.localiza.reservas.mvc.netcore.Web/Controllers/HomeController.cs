using AutoMapper;
using el.localiza.reservas.mvc.netcore.Core.Interfaces;
using el.localiza.reservas.mvc.netcore.Shared.Enums;
using el.localiza.reservas.mvc.netcore.Shared.Models;
using el.localiza.reservas.mvc.netcore.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;
        

        private SelectList _listaCategorias { get; set; }
        private List<VeiculoViewModel> _listaVeiculos { get; set; }

        public HomeController(IMapper mapper, ILogger<HomeController> logger, IVeiculoService veiculoService)
        {
            _mapper = mapper;
            _logger = logger;
            _veiculoService = veiculoService;

            //preenche o dropdown de categorias
            PreencheDropDownCategorias();
        }

        #region Actions       

        public async Task<IActionResult> Index(int id)
        {
            //preenche a view bag
            ViewBag.Categorias = _listaCategorias;

            //preenche o model
            _listaVeiculos = await ObtemListaVeiculosCategoria(id >= 0 ? id : 0);

            return View(_listaVeiculos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult EfetuaReserva(string id)
        {
            return RedirectToAction("Index", "Reserva", new { idVeiculo = id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Preenche o dropdown de categorias
        /// </summary>
        private void PreencheDropDownCategorias()
        {
            _listaCategorias = new SelectList(new[]
                {
                    new { id = ((int)CategoriaEnum.Basico).ToString(), name = "Basico" },
                    new { id = ((int)CategoriaEnum.Completo).ToString(), name = "Completo" },
                    new { id = ((int)CategoriaEnum.Luxo).ToString(), name = "Luxo" },
                }, "id", "name");
        }

        /// <summary>
        /// Obtem os veiculos por categoria na API
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        private async Task<List<VeiculoViewModel>> ObtemListaVeiculosCategoria(int categoria)
        {
            try
            {
                var veiculos = await _veiculoService.ObterDadosVeiculoPorCategoriaAsync(categoria);
                return _mapper.Map<IList<VeiculoModel>, IList<VeiculoViewModel>>(veiculos).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}
