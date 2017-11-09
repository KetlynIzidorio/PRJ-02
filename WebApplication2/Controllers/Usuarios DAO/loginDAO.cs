using System;
using System.Collections.Generic;
using System.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Usuarios_DAO
{
    public class loginDAO
    {
        public List<Login> List(string usuario, string senha)
        {
            List<Login> lista = new List<Login>();
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
                    Login objNovoAdministrador = new Login();
                    objNovoAdministrador.Id = objLinha["idAdministrador"] != DBNull.Value ? Convert.ToInt32(objLinha["idAdministrador"]) : 0;
                    objNovoAdministrador.nomeUsuario= objLinha["nomeAdministrador"] != DBNull.Value ? Convert.ToString(objLinha["nomeAdministrador"]) : "";
                    objNovoAdministrador.emailUsuario = objLinha["emailAdministrador"] != DBNull.Value ? Convert.ToString(objLinha["emailAdministrador"]) : "";
                    objNovoAdministrador.user= objLinha["userAdministrador"] != DBNull.Value ? Convert.ToString(objLinha["userAdministrador"]) : "";
                    objNovoAdministrador.senhaUsuario = objLinha["senhaAdministrador"] != DBNull.Value ? Convert.ToString(objLinha["senhaAdministrador"]) : "";


                    lista.Add(objNovoAdministrador);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }
    }
}