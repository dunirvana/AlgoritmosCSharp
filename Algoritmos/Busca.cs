using Algoritmos.Buscas;
using Algoritmos.Ordenacoes;
using System;
using System.Collections.Generic;

namespace Algoritmos
{
    public class Busca : Algoritmo
    {
        private readonly Search Search;
        private readonly string Algoritmo;

        public Busca(string pTipoBusca)
        {
            Algoritmo = pTipoBusca;

            var tiposBuscas = CarregarTiposBuscas();

            if (!tiposBuscas.ContainsKey(pTipoBusca))
                return;

            
            Search = tiposBuscas[pTipoBusca];
        }

        private Dictionary<string, Search> CarregarTiposBuscas()
        {
            var produtos = CarregarDados();

            return new Dictionary<string, Search>
            {
                { "LinearSearch", new LinearSearch(produtos) },
                { "BinarySearch", new BinarySearch(produtos) }
            };
        }


        public override void Executar()
        {
            if (Search == null)
                return;

            Search.ImprimirDadosAntesDaBusca();

            Search.SolicitarValorParaBusca();

            Search.Buscar();

            Search.ImprimirDadosAposBusca();
        }

        public override string ToString()
        {
            return Algoritmo;
        }

    }
}
