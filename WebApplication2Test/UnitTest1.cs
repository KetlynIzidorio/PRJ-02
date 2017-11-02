//using System;
//using WebApplication2.Models;
//using WebApplication2.HtmlHelpers;
//using Microsoft.VisualStudio.TestTools.UnitTesting;


//namespace WebApplication2Test
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
//        {
//            //Arrange
//            HtmlHelper html = null;

//            Paginacao paginacao = new Paginacao
//            {
//                PaginaAtual = 2,
//                ItensPorPagina = 10,
//                ItensTotal = 28
//            };
//            //Insere a função dando como paremetro no nome da url wainteron/pagina1 
//            Func<int, string> paginaUrl = i => "Pagina" + i;
//            //Act
//            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);
//            //Assert
//            Assert.AreEqual(

//                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
//                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
//                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()

//                );
//        }
//    }
//}
