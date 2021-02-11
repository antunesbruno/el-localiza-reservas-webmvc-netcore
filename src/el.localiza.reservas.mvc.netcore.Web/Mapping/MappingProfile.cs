using AutoMapper;
using el.localiza.reservas.mvc.netcore.Shared.Models;
using el.localiza.reservas.mvc.netcore.Web.Models;

namespace el.localiza.reservas.mvc.netcore.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VeiculoModel, VeiculoViewModel>();
            CreateMap<MarcaModel, MarcaViewModel>();
            CreateMap<ModeloModel, ModeloViewModel>();
            CreateMap<UsuarioModel, UsuarioViewModel>();
            CreateMap<ClienteModel, ClienteViewModel>();

            CreateMap<VeiculoViewModel, VeiculoModel>();
            CreateMap<MarcaViewModel, MarcaModel>();
            CreateMap<ModeloViewModel, ModeloModel>();
            CreateMap<UsuarioViewModel, UsuarioModel>();
            CreateMap<ClienteViewModel, ClienteModel>();
        }
    }
}

