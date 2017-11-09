using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class GlobalController : Controller
    {
        #region PROPRIEDADES E CONSTANTES

        /// <summary>
        /// Nome da sessão que possui o usuario logado.
        /// </summary>
        private const string _nmSessionUsuario = "Usuario";

        /// <summary>
        /// Propriedade do usuario logado.
        /// </summary>
        protected Login UsuarioLogado
        {
            get
            {
                return (Login)Session[_nmSessionUsuario];
            }
            set
            {
                Session[_nmSessionUsuario] = value;
            }
        }

        #endregion PROPRIEDADES E CONSTANTES

        #region MENSAGENS

        protected void MostrarSumarioValidacao(string mensagem)
        {
            MostrarSumarioValidacao(string.Empty, mensagem);
        }

        protected void MostrarSumarioValidacao(params string[] mensagens)
        {
            MostrarSumarioValidacao(string.Empty, mensagens);
        }

        protected void MostrarSumarioValidacao(string key = "", params string[] mensagens)
        {
            foreach (var msg in mensagens)
                ModelState.AddModelError(key, msg);

            TempData["SumarioDeValidacao"] = true;
        }

        #endregion

        #region UTEIS

        /// <summary>
        /// Metodo que gera um IEnumerable<SelectListItem> para a construção de combos
        /// </summary>
        /// <typeparam name="T">Tipo da lista</typeparam>
        /// <param name="lista">IEnumerable do tipo T para monstar os SelectListItem</param>
        /// <param name="funcValor">função para recuperar o valor da option</param>
        /// <param name="funcTexto">função para recuperar o texto da option</param>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GerarCombo<T>(IEnumerable<T> lista, Func<T, object> funcValor, Func<T, object> funcTexto)
        {
            return GerarCombo<T>(lista, funcValor, funcTexto, string.Empty, false);
        }

        /// <summary>
        /// Metodo que gera um IEnumerable<SelectListItem> para a construção de combos
        /// </summary>
        /// <typeparam name="T">Tipo da lista</typeparam>
        /// <param name="lista">IEnumerable do tipo T para monstar os SelectListItem</param>
        /// <param name="funcValor">função para recuperar o valor da option</param>
        /// <param name="funcTexto">função para recuperar o texto da option</param>
        /// <param name="idSelecionado">Identificador do item selecionado</param>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GerarCombo<T>(IEnumerable<T> lista, Func<T, object> funcValor, Func<T, object> funcTexto, string idSelecionado)
        {
            return GerarCombo<T>(lista, funcValor, funcTexto, idSelecionado, false);
        }

        /// <summary>
        /// Metodo que gera um IEnumerable<SelectListItem> para a construção de combos
        /// </summary>
        /// <typeparam name="T">Tipo da lista</typeparam>
        /// <param name="lista">IEnumerable do tipo T para monstar os SelectListItem</param>
        /// <param name="funcValor">função para recuperar o valor da option</param>
        /// <param name="funcTexto">função para recuperar o texto da option</param>
        /// <param name="eliminarSelecione">Valida se a lista possui apenas um elemento, não colocar o selecione</param>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GerarCombo<T>(IEnumerable<T> lista, Func<T, object> funcValor, Func<T, object> funcTexto, bool eliminarSelecione)
        {
            return GerarCombo<T>(lista, funcValor, funcTexto, string.Empty, eliminarSelecione);
        }

        /// <summary>
        /// Metodo que gera um IEnumerable<SelectListItem> para a construção de combos
        /// </summary>
        /// <typeparam name="T">Tipo da lista</typeparam>
        /// <param name="lista">IEnumerable do tipo T para monstar os SelectListItem</param>
        /// <param name="funcValor">função para recuperar o valor da option</param>
        /// <param name="funcTexto">função para recuperar o texto da option</param>
        /// <param name="idSelecionado">Identificador do item selecionado</param>
        /// <param name="eliminarSelecione">Valida se a lista possui apenas um elemento, não colocar o selecione</param>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GerarCombo<T>(IEnumerable<T> lista, Func<T, object> funcValor, Func<T, object> funcTexto, bool eliminarSelecione = false, string idSelecionado = "")
        {
            return GerarCombo<T>(lista, funcValor, funcTexto, idSelecionado, eliminarSelecione);
        }

        /// <summary>
        /// Metodo que gera um IEnumerable<SelectListItem> para a construção de combos
        /// </summary>
        /// <typeparam name="T">Tipo da lista</typeparam>
        /// <param name="lista">IEnumerable do tipo T para monstar os SelectListItem</param>
        /// <param name="funcValor">função para recuperar o valor da option</param>
        /// <param name="funcTexto">função para recuperar o texto da option</param>
        /// <param name="idSelecionado">Identificador do item selecionado</param>
        /// <param name="eliminarSelecione">Valida se a lista possui apenas um elemento, não colocar o selecione</param>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GerarCombo<T>(IEnumerable<T> lista, Func<T, object> funcValor, Func<T, object> funcTexto, string idSelecionado = "", bool eliminarSelecione = false)
        {
            List<SelectListItem> combo = new List<SelectListItem>();

            if (!eliminarSelecione)
            {
                combo.Add(new SelectListItem
                {
                    Value = string.Empty,
                    Text = "Selecione",
                    Selected = string.IsNullOrEmpty(idSelecionado)
                });
            }
            else
            {
                if (lista == null || lista.Count() == 0)
                {
                    combo.Add(new SelectListItem
                    {
                        Value = string.Empty,
                        Text = "Selecione",
                        Selected = string.IsNullOrEmpty(idSelecionado)
                    });
                }
            }

            combo.AddRange(lista.Select(item => new SelectListItem
            {
                Value = funcValor(item).ToString(),
                Text = funcTexto(item).ToString(),
                Selected = idSelecionado.Equals(funcValor(item).ToString())
            }));

            return combo;
        }

        #endregion UTEIS
    }
}