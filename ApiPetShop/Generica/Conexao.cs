using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ApiPetShop.Generica
{
    public class Conexao
    {
        public SqlConnection conexao = new SqlConnection();

        public void conectar()
        {
            conexao.ConnectionString = "Server=KEVINFAISCA\\SQLEXPRESS; Database=db_petshop; Trusted_Connection=True";
            conexao.Open();
        }
        public void desconectar()
        {
            conexao.Close();
        }
    }
}