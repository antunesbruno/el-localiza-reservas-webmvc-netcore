using AutoMapper;
using el.localiza.reservas.mvc.netcore.Core.Interfaces;
using el.localiza.reservas.mvc.netcore.Shared.Models;
using el.localiza.reservas.mvc.netcore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Web.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ILogger<ReservaController> _logger;
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;

        private ReservaViewModel _reservaViewModel { get; set; }

        public ReservaController(IMapper mapper, ILogger<ReservaController> logger, IVeiculoService veiculoService)
        {
            _mapper = mapper;
            _logger = logger;
            _veiculoService = veiculoService;
        }

        public async Task<IActionResult> Index(string idVeiculo)
        {
            if(_reservaViewModel == null)
                _reservaViewModel = new ReservaViewModel();

            //recupera o tempdata
            _reservaViewModel.Veiculo = await ObterVeiculoPorId(idVeiculo);

            return View(_reservaViewModel);
        }

        public async Task<IActionResult> ConfirmarReserva(ReservaViewModel model)
        {
            return View();
        }
            

        private async Task<VeiculoViewModel> ObterVeiculoPorId(string idVeiculo)
        {
            try
            {
                var veiculo = await _veiculoService.ObterVeiculoPorIdAsync(idVeiculo);
                return _mapper.Map<VeiculoModel, VeiculoViewModel>(veiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
