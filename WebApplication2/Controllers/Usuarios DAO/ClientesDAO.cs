using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Usuarios_DAO
{
    public class ClientesDAO : Controller
    {
        public List<Clientes> List()
        {
            List<Clientes> lista = new List<Clientes>();
            try
            {
                DataTable objDataTable = null;
                //Se quiser personalizar a busca
                string strSQL = "select idClientes, userClientes, senhaClientes from clientes";
                objDataTable = DAO.AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count <= 0)

                {
                    return lista;
                }

                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Clientes objNovoCliente = new Clientes();
                    objNovoCliente.Id = objLinha["idClientes"] != DBNull.Value ? Convert.ToInt32(objLinha["idClientes"]) : 0;
                    objNovoCliente.userClientes = objLinha["userClientes"] != DBNull.Value ? Convert.ToString(objLinha["userClientes"]) : "";
                    objNovoCliente.senhaClientes = objLinha["senhaClientes"] != DBNull.Value ? Convert.ToString(objLinha["senhaClientes"]) : "";
                   
                    lista.Add(objNovoCliente);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }

        public bool Create(Clientes clientes)
        {
            try
            {
                //LIMPA LISTA
                DAO.AcessoDadosMySQL.LimparParametros();

                //CRIANDO RETORNO
                object objRetorno = null;

                //SE NAO FOR NULLO, ADICIONA PARAMETRO
                if (clientes != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@userClientes", clientes.userClientes);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@senhaClientes", clientes.senhaClientes);

                    string strSQL = "insert into clientes (userClientes, senhaClientes) values ( @userClientes, @senhaClientes); SELECT LAST_INSERT_idClientes();";

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
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Clientes clientes)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (clientes != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idClientes", clientes.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@userClientes", clientes.userClientes);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@senhaClientes", clientes.senhaClientes);
                   

                    string strSQL = "update clientes set idClientes = @idClientes, userClientes = @userClientes, senhaClientes = @senhaClientes where idClientes = @idClientes; select @idClientes;";
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

        public bool Delete(Clientes clientes)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (clientes != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idClientes", clientes.Id);

                    string strSQL = "delete from Clientes where idClientes = @idClientes; select @idClientes;";
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