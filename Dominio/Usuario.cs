using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public bool TipoUsuario { get; set; }

        public Usuario(string email, string pass, bool admin) //constructor
        {
           Email = email;
           Pass = pass;
           TipoUsuario = admin;
        }
    }
}
