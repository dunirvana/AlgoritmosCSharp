using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos.Buscas
{
    public abstract class Search
    {
        protected string NomeRotinaBusca { get; set; }
        protected double ValorProcurado { get; set; }
        protected int IndiceDoProdutoProcurado { get; set; }

        public abstract void Buscar();

        protected abstract Produto[] RecuperarProdutos();

        public void ImprimirDadosAntesDaBusca()
        {
            Util.ImprimirProdutos(string.Format("{0}: Dados Antes Da Busca", NomeRotinaBusca), RecuperarProdutos());
        }

        public void SolicitarValorParaBusca()
        {
            Console.WriteLine("\n--> Informe o valor procurado:");
            ValorProcurado = -1;

            if (double.TryParse(Console.ReadLine(), out double valor))
                ValorProcurado = valor;
            else
                Console.WriteLine("Valor inválido!");
        }

        public void ImprimirDadosAposBusca()
        {
            var produtoEncontrado = RecuperarProdutos()[IndiceDoProdutoProcurado];
            if (produtoEncontrado == null)
                Console.WriteLine("Produto não encontrado!");

            Util.ImprimirProdutos(string.Format("{0}: Dados Apos Busca", NomeRotinaBusca), new Produto[]{ produtoEncontrado });
        }

    }
}
