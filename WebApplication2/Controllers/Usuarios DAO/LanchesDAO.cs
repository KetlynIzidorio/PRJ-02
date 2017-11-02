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
                    objNovoLanche.Nome = objLinha["Nome"] != DBNull.Value ? Convert.ToString(objLinha["Nome"]) : "";
                    objNovoLanche.Pao = objLinha["Pao"] != DBNull.Value ? Convert.ToString(objLinha["Pao"]) : "";
                    objNovoLanche.Molho = objLinha["Molho"] != DBNull.Value ? Convert.ToString(objLinha["Molho"]) : "";
                    objNovoLanche.Recheio = objLinha["Recheio"] != DBNull.Value ? Convert.ToString(objLinha["Recheio"]) : "";
                    objNovoLanche.Queijo = objLinha["Queijo"] != DBNull.Value ? Convert.ToString(objLinha["Queijo"]) : "";
                    objNovoLanche.Salada = objLinha["Salada"] != DBNull.Value ? Convert.ToString(objLinha["Salada"]) : "";

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
            {   //LIMPA LISTA
                DAO.AcessoDadosMySQL.LimparParametros();
                //CRIANDO RETORNO
                object objRetorno = null;
                //SE NAO FOR NULLO, ADICIONA PARAMETRO
                if (lanches != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idLanches", lanches.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Nome", lanches.Nome);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Pao", lanches.Pao);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Molho", lanches.Molho);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Recheio", lanches.Recheio);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Queijo", lanches.Queijo);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Salada", lanches.Salada);
                

                    string strSQL = "insert into Lanches (idLanches,Nome,Pao,Molho,Recheio,Queijo,Salada) values ( @idLanches,@Nome,@Pao,@Molho,@Recheio,@Queijo,@Salada); SELECT LAST_INSERT_idLanches();";
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
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idLanches", lanches.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Nome", lanches.Nome);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Pao", lanches.Pao);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Molho", lanches.Molho);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Recheio", lanches.Recheio);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Queijo", lanches.Queijo);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@Salada", lanches.Salada);


                    string strSQL = "update Lanches set Nome = @Nome, Pao = @Pao, Molho = @Molho, Recheio = @Recheio, Queijo = @Queijo, Salada = @Salada where idLanches = @idLanches; select @idLanches;";
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