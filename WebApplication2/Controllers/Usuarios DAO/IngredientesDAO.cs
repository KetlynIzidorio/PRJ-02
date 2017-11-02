using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Usuarios_DAO
{
    public class IngredientesDAO
    {
        public List<Ingredientes> List()
        {
            List<Ingredientes> lista = new List<Ingredientes>();
            try
            {
                DataTable objDataTable = null;
                //Se quiser personalizar a busca
                string strSQL = "select idIngredientes, tipo, nome from ingredientes";
                objDataTable = DAO.AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count <= 0)

                {
                    return lista;
                }

                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Ingredientes objNovoIngrediente = new Ingredientes();
                    objNovoIngrediente.Id = objLinha["idIngredientes"] != DBNull.Value ? Convert.ToInt32(objLinha["idIngredientes"]) : 0;
                    objNovoIngrediente.tipo = objLinha["tipo"] != DBNull.Value ? Convert.ToString(objLinha["tipo"]) : "";
                    objNovoIngrediente.nome = objLinha["nome"] != DBNull.Value ? Convert.ToString(objLinha["nome"]) : "";
                   

                    lista.Add(objNovoIngrediente);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }

        public bool Create(Ingredientes ingredientes)
        {
            try
            {   //LIMPA LISTA
                DAO.AcessoDadosMySQL.LimparParametros();
                //CRIANDO RETORNO
                object objRetorno = null;
                //SE NAO FOR NULLO, ADICIONA PARAMETRO
                if (ingredientes != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idIngredientes", ingredientes.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@tipo", ingredientes.tipo);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@nome", ingredientes.nome);
                   
                    string strSQL = "insert into Ingredientes (idIngredientes,tipo,nome) values ( @idIngredientes,@tipo,@nome); SELECT LAST_INSERT_idIngredientes();";
                    objRetorno = DAO.AcessoDadosMySQL.ExecutarManipulacao(CommandType.Text, strSQL);
                }

                int intResultado = 0;
                if (objRetorno != null)
                {
                    if (int.TryParse(objRetorno.ToString(), out intResultado))
                        return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Ingredientes ingredientes)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (ingredientes != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idIngredientes", ingredientes.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@tipo", ingredientes.tipo);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@nome", ingredientes.nome);
              
                    string strSQL = "update Ingredientes set tipo = @tipo, nome = @nome where idIngredientes = @idIngredientes; select @idIngredientes;";
                    objRetorno = DAO.AcessoDadosMySQL.ExecutarManipulacao(CommandType.Text, strSQL);
                }

                int intResultado = 0;
                if (objRetorno != null)
                {
                    if (int.TryParse(objRetorno.ToString(), out intResultado))
                        return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Ingredientes ingredientes)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (ingredientes != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idIngredientes", ingredientes.Id);

                    string strSQL = "delete from Ingredientes where idIngredientes = @idIngredientes; select @idIngredientes;";
                    objRetorno = DAO.AcessoDadosMySQL.ExecutarManipulacao(CommandType.Text, strSQL);
                }

                int intResultado = 0;
                if (objRetorno != null)
                {
                    if (int.TryParse(objRetorno.ToString(), out intResultado))
                        return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}