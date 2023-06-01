using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPetShop.Models
{
    public class Produto
    {
        private int id;
        private int quantidade;
        private double preco;
        private string marca;
        private string nome;
        private string imagem;
        public int Id { get => id; set => id = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double Preco { get => preco; set => preco = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Nome { get => nome; set => nome = value; }

        public string Imagem { get => imagem; set => imagem = value; }
    }

}