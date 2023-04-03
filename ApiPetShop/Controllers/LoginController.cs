using ApiPetShop.Generica;
using ApiPetShop.Models;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace ApiPetShop.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        public int PostLogin(Login login )
        {
            try
            {
                int idUsuario = 0;
                string strSql = "";
                Conexao conec = new Conexao();
                conec.conectar();
                SqlCommand cmd;

                try
                {
                    strSql = "SELECT ID_USUARIO,DS_LOGIN,DS_SENHA FROM TB_USUARIO WHERE ds_login = '" + login.Email.ToString() + "' and ds_Senha = '" + login.Senha.ToString() + "'";
                    cmd = new SqlCommand(strSql, conec.conexao);

                    SqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                    if (dataReader.Read())
                    {
                        idUsuario = Convert.ToInt32(dataReader[("id_usuario")]);
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }

                finally
                {
                    conec.desconectar();
                }


                return idUsuario;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}