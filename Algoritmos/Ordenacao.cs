using Algoritmos.Ordenacoes;
using System;
using System.Collections.Generic;

namespace Algoritmos
{
    public class Ordenacao : Algoritmo
    {
        private readonly Order Order;
        private readonly string Algoritmo;

        public Ordenacao(string pTipoOrdenacao)
        {
            Algoritmo = pTipoOrdenacao;

            var tiposOrdenacoes = CarregarTiposOrdenacoes();

            if (!tiposOrdenacoes.ContainsKey(pTipoOrdenacao))
                return;

            
            Order = tiposOrdenacoes[pTipoOrdenacao];
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


        public override void Executar()
        {
            if (Order == null)
                return;

            Order.ImprimirDadosAntesDaOrdenacao();

            Order.Ordenar();

            Order.ImprimirDadosAposOrdenacao();
        }

        public override string ToString()
        {
            return Algoritmo;
        }

    }
}
