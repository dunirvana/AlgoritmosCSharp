using Algoritmos.Ordenacoes;
using System;
using System.Collections.Generic;

namespace Algoritmos
{
    public class Ordenacao
    {
        public Ordenacao(string pTipoOrdenacao)
        {
            var tiposOrdenacoes = CarregarTiposOrdenacoes();

            if (!tiposOrdenacoes.ContainsKey(pTipoOrdenacao))
            {
                Console.WriteLine(string.Format("\n### Tipo de ordenação '{0}' não identificado! ###\n ", pTipoOrdenacao));
                return;
            }

            var tipoOrdenacao = tiposOrdenacoes[pTipoOrdenacao];

            tipoOrdenacao.ImprimirDadosAntesDaOrdenacao();

            tipoOrdenacao.Ordenar();

            tipoOrdenacao.ImprimirDadosAposOrdenacao();
        }

        private Dictionary<string, Order> CarregarTiposOrdenacoes()
        {
            var produtos = CarregarDados();

            return new Dictionary<string, Order>
            {
                { "SelectionSort", new SelectionSort(produtos) },
                { "InsertionSort", new InsertionSort(produtos) },
                { "MergeSort", new MergeSort(produtos) },
                { "QuickSort", new QuickSort(produtos) },                
            };
        }

        public Produto[] CarregarDados()
        {
            return new Produto[11]
            {
                new Produto("Palio", 10000),
                new Produto("Corsa", 8000),
                new Produto("Fusca", 14000),
                new Produto("Corsel", 17000),
                new Produto("Fiat 147", 3000),
                new Produto("Opala", 23000),
                new Produto("Brasilia", 2900),
                new Produto("Uno", 11000),
                new Produto("Variant", 2950.90),
                new Produto("Del Rey", 15200.90),
                new Produto("Gol", 14000)
            };
        }

    }
}
