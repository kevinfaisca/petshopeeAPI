using ApiPetShop.Generica;
using ApiPetShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace ApiPetShop.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        public List<Usuario> GetUsuarios()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                Usuario usuario;
                string strSql = "";
                Conexao conec = new Conexao();
                conec.conectar();
                SqlCommand cmd;

                try
                {
                    strSql = "SELECT * FROM TB_USUARIO";
                    cmd = new SqlCommand(strSql, conec.conexao);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        usuario = new Usuario
                        {
                            Id = Convert.ToInt32(row["id_usuario"]),
                            Nome = row["ds_nome"].ToString(),
                            Cpf = row["nr_cpf"].ToString(),
                            Email = row["ds_email"].ToString(),
                        };

                        usuarios.Add(usuario);

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

                return usuarios;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public Usuario GetUsuario(int id)
        {
            try
            {
                Usuario usuario = new Usuario();
                string strSql = "";
                Conexao conec = new Conexao();
                conec.conectar();
                SqlCommand cmd;

                try
                {
                    strSql = "SELECT * FROM TB_USUARIO WHERE id_usuario = " + id.ToString();
                    cmd = new SqlCommand(strSql, conec.conexao);

                    SqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                    if (dataReader.Read())
                    {
                        usuario.Id = Convert.ToInt32(dataReader[("id_usuario")]);
                        usuario.Nome = dataReader[("ds_nome")].ToString();
                        usuario.Cpf = dataReader["nr_cpf"].ToString();
                        usuario.Email = dataReader["ds_email"].ToString();

                    }
                    else
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
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


                return usuario;

            }
            catch (Exception)
            {

                throw;
            }
        }
            public Usuario Post(Usuario usuario)
        {
            Conexao conec = new Conexao();
            try
            {
                conec.conectar();
                SqlCommand cmd;

                cmd = new SqlCommand("sp_usuario", conec.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vstr_tipoOper", "INS").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@vint_numOper", "1").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_nome", usuario.Nome).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@nr_cpf", usuario.Cpf).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_email", usuario.Email).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_login", usuario.Email).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_senha", usuario.Cpf).Direction = ParameterDirection.Input;
                cmd.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch (Exception ex)
            {

                throw;
            }

            finally
            {
                conec.desconectar();
            }
            return usuario;
        }

        public Usuario PatchUsuario(Usuario usuario)
        {
            Conexao conec = new Conexao();
            try
            {
                conec.conectar();
                SqlCommand cmd;

                cmd = new SqlCommand("sp_usuario", conec.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vstr_tipoOper", "UPD").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@vint_numOper", "1").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@id_usuario", usuario.Id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_nome", usuario.Nome).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@nr_cpf", usuario.Cpf).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_email", usuario.Email).Direction = ParameterDirection.Input;
                cmd.ExecuteReader(CommandBehavior.SingleRow);
            }
            catch (Exception ex)
            {

                throw;
            }

            finally
            {
                conec.desconectar();
            }
            return usuario;
        }


    }
}