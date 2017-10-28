using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Usuarios_DAO
{
    public class AvaliacaoDAO
    {
        public List<Avaliacao> List()
        {
            List<Avaliacao> lista = new List<Avaliacao>();
            try
            {
                DataTable objDataTable = null;
                //Se quiser personalizar a busca
                string strSQL = "select idAvaliacao, nome, email, mensagem from avaliacao";
                objDataTable = DAO.AcessoDadosMySQL.ExecutaConsultar(System.Data.CommandType.Text, strSQL);
                if (objDataTable.Rows.Count <= 0)

                {
                    return lista;
                }

                foreach (DataRow objLinha in objDataTable.Rows)
                {
                    Avaliacao objNovaAvaliacao = new Avaliacao();
                    objNovaAvaliacao.idAvaliacao = objLinha["idAvaliacao"] != DBNull.Value ? Convert.ToInt32(objLinha["idAvaliacao"]) : 0;
                    objNovaAvaliacao.nome = objLinha["nome"] != DBNull.Value ? Convert.ToString(objLinha["nome"]) : "";
                    objNovaAvaliacao.email = objLinha["email"] != DBNull.Value ? Convert.ToString(objLinha["email"]) : "";
                    objNovaAvaliacao.mensagem = objLinha["mensagem"] != DBNull.Value ? Convert.ToString(objLinha["mensagem"]) : "";

                    lista.Add(objNovaAvaliacao);
                }
                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
        }

        public bool Avaliacao(Avaliacao avaliacao)
        {
            try
            {
                //LIMPA LISTA
                DAO.AcessoDadosMySQL.LimparParametros();

                //CRIANDO RETORNO
                object objRetorno = null;

                //SE NAO FOR NULLO, ADICIONA PARAMETRO
                if (avaliacao != null)
                {
                    DAO.AcessoDadosMySQL.AdicionarParametros("@idAvaliacao", avaliacao.idAvaliacao);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@nome", avaliacao.nome);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@email", avaliacao.email);
                    DAO.AcessoDadosMySQL.AdicionarParametros("@mensagem", avaliacao.mensagem);
                    


                    string strSQL = "insert into avaliacao (idAvaliacao, nome, email, mensagem) values (@idAvaliacao, @nome,@email,@mensagem); SELECT LAST_INSERT_idAvaliacao();";

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