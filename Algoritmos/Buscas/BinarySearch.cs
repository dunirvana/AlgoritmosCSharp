using Algoritmos.Ordenacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos.Buscas
{
    public class BinarySearch : Search
    {
        private readonly Produto[] Produtos;

        public BinarySearch(Produto[] pProdutos)
        {
            Produtos = pProdutos;
            NomeRotinaBusca = "BinarySearch";
        }

        protected override Produto[] RecuperarProdutos() => Produtos;

        public override void Buscar()
        {
            // Primeiro ordenamos nossos produtos
            var sort = new QuickSort(Produtos);
            sort.Ordenar();

            IndiceDoProdutoProcurado = BuscaBinarySearch(Produtos, 0, Produtos.Length, ValorProcurado);
        }

        /// <summary>
        /// BinarySearch:
        /// - Partindo do principio que as informações já estão ordenadas:
        /// -- Primeiro verificamos se o elemento do "meio" da coleção é o que desejamos, se for encerra processo e retorna;
        /// -- Se o elemento do "meio" NÃO é o que desejamos então precisamos ver qual "metade" da coleção iremos "desconsiderar":
        /// ---- Se o que estamos buscando é "menor" que o encontrado no "meio" então descartamos tudo o que é "maior" (lado direito);
        /// ---- Se o que estamos buscando é "maior" que o encontrado no "meio" então descartamos tudo o que é "menor" (lado esquerdo);
        /// -- Esse processo de "divisão" dos dados segue até que o elemento desejado seja encontrado ou não existam mais elementos a serem verificados;
        /// </summary>
        /// <param name="pProdutos">Coleção</param>
        /// <param name="pDe">Inicio da buscao</param>
        /// <param name="pAte">Término da basca</param>
        /// <param name="pBuscando">Valor buscado</param>
        /// <returns>Posição do valor sendo buscado ou "-1" caso o mesmo não seja encontrado</returns>
        private int BuscaBinarySearch(Produto[] pProdutos, int pDe, int pAte, double pBuscando)
        {
            if (pDe > pAte)
                return -1;

            int meio = (pDe + pAte) / 2;
            Produto produto = pProdutos[meio];


            if (pBuscando == produto.Valor)
                return meio;
            

            if (pBuscando < produto.Valor)
                return BuscaBinarySearch(pProdutos, pDe, meio - 1, pBuscando);


            return BuscaBinarySearch(pProdutos, meio + 1, pAte, pBuscando);
        }
    }
}
