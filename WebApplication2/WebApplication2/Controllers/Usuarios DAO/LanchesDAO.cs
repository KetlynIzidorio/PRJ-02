using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Usuarios_DAO
{
    public class LanchesDAO
    {
        public List<Lanches> List()
        {
            List<Lanches> lista = new List<Lanches>();
            try
            {
                DataTable objDataTable = null;
                //Se quiser personalizar a busca
                string strSQL = "select idLanches, nome, pao, molho, recheio, queijo, salada from lanches";
                objDataTable = DAO.AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count <= 0)

                {
                    return lista;
                }

                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Lanches objNovoLanche = new Lanches();
                    objNovoLanche.Id = objLinha["idLanches"] != DBNull.Value ? Convert.ToInt32(objLinha["idLanches"]) : 0;
                    objNovoLanche.Nome = objLinha["nome"] != DBNull.Value ? Convert.ToString(objLinha["nome"]) : "";
                    objNovoLanche.Pao = objLinha["pao"] != DBNull.Value ? Convert.ToString(objLinha["pao"]) : "";
                    objNovoLanche.Id = objLinha["molho"] != DBNull.Value ? Convert.ToInt32(objLinha["molho"]) : 0;
                    objNovoLanche.Nome = objLinha["recheio"] != DBNull.Value ? Convert.ToString(objLinha["recheio"]) : "";
                    objNovoLanche.Pao = objLinha["queijo"] != DBNull.Value ? Convert.ToString(objLinha["queijo"]) : "";
                    objNovoLanche.Pao = objLinha["salada"] != DBNull.Value ? Convert.ToString(objLinha["salada"]) : "";

                    lista.Add(objNovoLanche);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }

        public bool Create(Lanches lanches)
        {
            try
            {
                //LIMPA LISTA
                DAO.AcessoDadosMySQL.LimparParametros();

                //CRIANDO RETORNO
                object objRetorno = null;

                //SE NAO FOR NULLO, ADICIONA PARAMETRO
                if (lanches != null)
                {

                    DAO.AcessoDadosMySQL.AdicionarParametros("@idLanches", lanches.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@nome", lanches.Nome);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@pao", lanches.Pao);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@molho", lanches.Molho);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@recheio", lanches.Recheio);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@queijo", lanches.Queijo);


                    string strSQL = "insert into lanches (idLanches, nome, pao, molho, recheio, queijo) values (@idClientes, @nome, @pao, @molho, @recheio, @queijo); SELECT LAST_INSERT_idLanches();";

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

        public bool Edit(Lanches lanches)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (lanches != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idClientes", lanches.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@pao", lanches.Nome);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@molho", lanches.Molho);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@recheio", lanches.Recheio);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@queijo", lanches.Queijo);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@salada", lanches.Salada);


                    string strSQL = "update clientes set idLanches = @idLanches, pao = @pao, molho = @molho, recheio = @recheio, queijo = @queijo, salada = @salada where idLanches = @idLanches; select @idLanches;";
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

        public bool Delete(Lanches lanches)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (lanches != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idLanches", lanches.Id);

                    string strSQL = "delete from Lanches where idLanches = @idLanches; select @idLanches;";
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
