using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el.localiza.reservas.mvc.netcore.Web.Models
{
    public class UsuarioViewModel
    {
        public string UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Perfil { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
