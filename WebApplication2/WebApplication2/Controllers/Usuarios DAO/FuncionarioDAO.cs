using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FuncionarioDAO
    {
        public List<Funcionario> List()
        {
            List<Funcionario> lista = new List<Funcionario>();
            try
            {
                DataTable objDataTable = null;
                //Se quiser personalizar a busca
                string strSQL = "select idFuncionario, nomeFuncionario, cargoFuncionario, userFuncionario, senhaFuncionario from funcionario";
                objDataTable = DAO.AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count <= 0)

                {
                    return lista;
                }

                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Funcionario objNovoFunc = new Funcionario();
                    objNovoFunc.Id = objLinha["idFuncionario"] != DBNull.Value ? Convert.ToInt32(objLinha["idFuncionario"]) : 0;
                    objNovoFunc.nomeFuncionario = objLinha["nomeFuncionario"] != DBNull.Value ? Convert.ToString(objLinha["nomeFuncionario"]) : "";
                    objNovoFunc.cargoFuncionario = objLinha["cargoFuncionario"] != DBNull.Value ? Convert.ToString(objLinha["cargoFuncionario"]) : "";
                    objNovoFunc.userFuncionario = objLinha["userFuncionario"] != DBNull.Value ? Convert.ToString(objLinha["userFuncionario"]) : "";
                    objNovoFunc.senhaFuncionario = objLinha["senhaFuncionario"] != DBNull.Value ? Convert.ToString(objLinha["senhaFuncionario"]) : "";
                   

                    lista.Add(objNovoFunc);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }


        public bool Create(Funcionario funcionario)
        {
            try
            {   //LIMPA LISTA
                DAO.AcessoDadosMySQL.LimparParametros();
                //CRIANDO RETORNO
                object objRetorno = null;
                //SE NAO FOR NULLO, ADICIONA PARAMETRO
                if (funcionario != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idFuncionario", funcionario.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@nomeFuncionario", funcionario.nomeFuncionario);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@cargoFuncionario", funcionario.cargoFuncionario);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@userFuncionario", funcionario.userFuncionario);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@senhaFuncionario", funcionario.senhaFuncionario);

                    string strSQL = "insert into Funcionario (idFuncionario,nomeFuncionario,cargoFuncionario,userFuncionario,senhaFuncionario) values ( @idFuncionario,@nomeFuncionario,@cargoFuncionario,@userFuncionario,@senhaFuncionario); SELECT LAST_INSERT_idFuncionario();";
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

        public bool Edit(Funcionario funcionario)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (funcionario != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idFuncionario", funcionario.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@nomeFuncionario", funcionario.nomeFuncionario);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@cargoFuncionario", funcionario.cargoFuncionario);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@userFuncionario", funcionario.userFuncionario);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@senhaFuncionario", funcionario.senhaFuncionario);


                    string strSQL = "update funcionario set nomeFuncionario = @nomeFuncionario, cargoFuncionario = @cargoFuncionario, userFuncionario = @userFuncionario, senhaFuncionario = @senhaFuncionario where idFuncionario = @idFuncionario; select @idFuncionario;";
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

        public bool Delete(Funcionario funcionario)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (funcionario != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idfuncionario", funcionario.Id);

                    string strSQL = "delete from Funcionario where idfuncionario = @idfuncionario; select @idfuncionario;";
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