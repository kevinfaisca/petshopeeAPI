using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPetShop.Models
{
    public class Login
    {
        private int id;
        private string email;
        private string senha;

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }

    }
}