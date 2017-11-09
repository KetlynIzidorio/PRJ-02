using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using DAO;

namespace WebApplication2.Controllers.Usuarios_DAO
{
    public class AdministradorDAO
    {
        public List<Administrador> List()
        {
            List<Administrador> lista = new List<Administrador>();
            try
            {
                DataTable objDataTable = null;
                //Se quiser personalizar a busca
                string strSQL = "select idAdministrador, nomeAdministrador, emailAdministrador, userAdministrador, senhaAdministrador from administrador";
                objDataTable = DAO.AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count <= 0)

                {
                    return lista;
                }

                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Administrador objNovoAdministrador = new Administrador();
                    objNovoAdministrador.Id = objLinha["idAdministrador"] != DBNull.Value ? Convert.ToInt32(objLinha["idAdministrador"]) : 0;
                    objNovoAdministrador.nomeAdministrador = objLinha["nomeAdministrador"] != DBNull.Value ? Convert.ToString(objLinha["nomeAdministrador"]) : "";
                    objNovoAdministrador.emailAdministrador = objLinha["emailAdministrador"] != DBNull.Value ? Convert.ToString(objLinha["emailAdministrador"]) : "";
                    objNovoAdministrador.userAdministrador = objLinha["userAdministrador"] != DBNull.Value ? Convert.ToString(objLinha["userAdministrador"]) : "";
                    objNovoAdministrador.senhaAdministrador = objLinha["senhaAdministrador"] != DBNull.Value ? Convert.ToString(objLinha["senhaAdministrador"]) : "";
                    

                    lista.Add(objNovoAdministrador);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }

        public bool Create(Administrador administrador)
        {
            try
            {
                //LIMPA LISTA
                DAO.AcessoDadosMySQL.LimparParametros();

                //CRIANDO RETORNO
                object objRetorno = null;

                //SE NAO FOR NULLO, ADICIONA PARAMETRO
                if (administrador != null)
                {

                    DAO.AcessoDadosMySQL.AdicionarParametros("@nomeAdministrador", administrador.nomeAdministrador);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@emailAdministrador", administrador.emailAdministrador);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@userAdministrador", administrador.userAdministrador);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@senhaAdministrador", administrador.senhaAdministrador);
                   

                    string strSQL = "insert into administrador (nomeAdministrador, emailAdministrador, userAdministrador, senhaAdministrador) values ( @nomeAdministrador,@emailAdministrador,@userAdministrador,@senhaAdministrador); SELECT LAST_INSERT_idAdministrador();";

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
            catch (Exception ex )
            {
                return false;
            }
        }

        public bool Edit(Administrador administrador)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (administrador != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idAdministrador", administrador.Id);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@nomeAdministrador", administrador.nomeAdministrador);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@emailAdministrador", administrador.emailAdministrador);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@userAdministrador", administrador.userAdministrador);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@senhaAdministrador", administrador.senhaAdministrador);


                    string strSQL = "update administrador set nomeAdministrador = @nomeAdministrador, emailAdministrador = @emailAdministrador, userAdministrador = @userAdministrador, senhaAdministrador = @senhaAdministrador where idAdministrador = @idAdministrador; select @idAdministrador;";
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

        public bool Delete(Administrador administrador)
        {
            try
            {
                DAO.AcessoDadosMySQL.LimparParametros();

                object objRetorno = null;
                if (administrador != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idAdministrador", administrador.Id);

                    string strSQL = "delete from Administrador where idAdministrador = @idAdministrador; select @idAdministrador;";
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