using AutoMapper;
using el.localiza.reservas.mvc.netcore.Core.Interfaces;
using el.localiza.reservas.mvc.netcore.Shared.Enums;
using el.localiza.reservas.mvc.netcore.Shared.Models;
using el.localiza.reservas.mvc.netcore.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Web.Controllers
{
    public class UsuarioController : Controller
    { 
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        private List<UsuarioViewModel> _listaUsuario { get; set; }

        public UsuarioController(IMapper mapper, ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _mapper = mapper;
            _logger = logger;
            _usuarioService = usuarioService;
        }

        // GET: UsuarioController
        public async Task<ActionResult> Index()
        {       

            //preenche a lista
            if(_listaUsuario == null)
                _listaUsuario = await ObterTodosUsuariosPorPerfil(0);


            return View(_listaUsuario);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UsuarioViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var created = await CriaNovoUsuario(collection);

                    if(created != null)
                        return RedirectToAction(nameof(Index));

                    return View(collection);
                }

                return View(collection);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<List<UsuarioViewModel>> ObterTodosUsuariosPorPerfil(int perfil)
        {
            try
            {
                var usuarios = await _usuarioService.ObterTodosUsuariosPorPerfil(perfil);
                return _mapper.Map<IList<UsuarioModel>, IList<UsuarioViewModel>>(usuarios).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<UsuarioViewModel> CriaNovoUsuario(UsuarioViewModel usuario)
        {
            try
            {
                //verifica o tipo de usuario
                if (usuario.Login.Length == 11)
                {
                    usuario.Perfil = (int)PerfilUsuarioEnum.Cliente;
                    usuario.Cpf = usuario.Login;
                }
                else
                {
                    usuario.Perfil = (int)PerfilUsuarioEnum.Operador;
                    usuario.Matricula = usuario.Login;
                }

                //converte os modelos
                var usuarioModel = _mapper.Map<UsuarioViewModel, UsuarioModel>(usuario);

                //insere no banco
                return _mapper.Map<UsuarioModel, UsuarioViewModel>(await _usuarioService.CriarNovoUsuario(usuarioModel));                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
