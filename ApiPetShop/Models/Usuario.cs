using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPetShop.Models
{
    public class Usuario
    {
        private int id;
        private string nome;
        private string cpf;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }

    }
}