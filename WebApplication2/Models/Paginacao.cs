using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Paginacao
    {
        //Quantos itens tenho no banco
        public int ItensTotal { get; set; }

        //Quantos itens de lanches por página
        public int ItensPorPagina { get; set; }

        //Pagina exibida no momento
        public int PaginaAtual { get; set; }

        //Quantas paginas vou ter 
        public int TotalPagina
        {
               get { return (int)Math.Ceiling((decimal)ItensTotal / ItensPorPagina); }
        }
    }
}