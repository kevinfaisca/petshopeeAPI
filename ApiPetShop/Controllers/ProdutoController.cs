using ApiPetShop.Generica;
using ApiPetShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiPetShop.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProdutoController : ApiController
    {

        public List<Produto> GetProdutos()
        {
            try
            {
                List<Produto> produtos = new List<Produto>();
                Produto produto;
                string strSql = "";
                Conexao conec = new Conexao();
                conec.conectar();
                SqlCommand cmd;

                try
                {
                    strSql = "SELECT * FROM TB_PRODUTO";
                    cmd = new SqlCommand(strSql, conec.conexao);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        produto = new Produto
                        {
                            Id = Convert.ToInt32(row["id_produto"]),
                            Marca = row["ds_marca"].ToString(),
                            Nome = row["ds_nome"].ToString(),
                            Preco = Convert.ToDouble(row["ds_preco"]),
                            Quantidade = Convert.ToInt32(row["nr_quantidade"])
                        };

                        produtos.Add(produto);

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

                return produtos;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public Produto GetProduto(int id)
        {
            try
            {
                Produto produto = new Produto();
                string strSql = "";
                Conexao conec = new Conexao();
                conec.conectar();
                SqlCommand cmd;

                try
                {
                    strSql = "SELECT * FROM TB_PRODUTO WHERE id_produto = " + id.ToString();
                    cmd = new SqlCommand(strSql, conec.conexao);

                    SqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                    if (dataReader.Read())
                    {
                        produto.Id = Convert.ToInt32(dataReader[("id_produto")]);
                        produto.Marca = dataReader[("ds_marca")].ToString();
                        produto.Nome = dataReader["ds_nome"].ToString();
                        produto.Preco = Convert.ToDouble(dataReader[("ds_preco")]);
                        produto.Quantidade = Convert.ToInt32(dataReader[("nr_quantidade")]);
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


                return produto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Produto Post(Produto produto)
        {
            Conexao conec = new Conexao();
            try
            {
                conec.conectar();
                SqlCommand cmd;

                cmd = new SqlCommand("sp_produto", conec.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vstr_tipoOper", "INS").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@vint_numOper", "1").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_nome", produto.Nome).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@nr_quantidade", produto.Quantidade).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_preco", produto.Preco).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_marca", produto.Marca).Direction = ParameterDirection.Input;
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
            return produto;
        }

        public Produto PatchProduto(Produto produto)
        {
            Conexao conec = new Conexao();
            try
            {
                conec.conectar();
                SqlCommand cmd;

                cmd = new SqlCommand("sp_produto", conec.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vstr_tipoOper", "UPD").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@vint_numOper", "1").Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@id_produto", produto.Id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_nome", produto.Nome).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@nr_quantidade", produto.Quantidade).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_preco", produto.Preco).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@ds_marca", produto.Marca).Direction = ParameterDirection.Input;
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
            return produto;
        }

        public bool DeleteProduto(int id)
        {
            bool achouProduto = false;
            try
            {
                Produto produto = new Produto();
                string strSql = "";
                Conexao conec = new Conexao();
                conec.conectar();
                SqlCommand cmd;

                try
                {
                    strSql = "DELETE FROM TB_PRODUTO WHERE id_produto = " + id.ToString();
                    cmd = new SqlCommand(strSql, conec.conexao);

                    // se retornar maior que 0, significa que achou algo no banco e conseguiu deletar,
                    // caso contrario retorna false pois o produto não foi encontrado
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        achouProduto = true;

                    }
                    else
                    {
                         achouProduto = false;

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

                return achouProduto;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
