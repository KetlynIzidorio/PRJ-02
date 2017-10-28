using System;
using System.Text;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
       //Total de Paginas = 3 
       // Monta 3vz o H
        public static MvcHtmlString PageLinks (this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            StringBuilder resultado = new StringBuilder();
            for (int i = 1; i <= paginacao.TotalPagina; i++)
            {
                //Classe TagBuilder monta a tag
                TagBuilder tag = new TagBuilder("a");
                //Adiciono atributo href
                tag.MergeAttribute("href", paginaUrl(i));
                tag.InnerHtml = i.ToString();

                //Adicionando cor ao botão que esta na pagina atual - Btn-primary é o css que faz o botão ficar com a cor diferente   

                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                resultado.Append(tag);
            }
            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}