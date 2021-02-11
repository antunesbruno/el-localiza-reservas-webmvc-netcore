using System;
using System.Collections.Generic;
using System.Text;

namespace el.localiza.reservas.mvc.netcore.Shared.Models
{
    public class UsuarioModel
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
