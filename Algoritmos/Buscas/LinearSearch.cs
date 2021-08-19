namespace Algoritmos.Buscas
{
    public class LinearSearch : Search
    {
        private readonly Produto[] Produtos;

        public LinearSearch(Produto[] pProdutos)
        {
            Produtos = pProdutos;
            NomeRotinaBusca = "LinearSearch";
        }

        protected override Produto[] RecuperarProdutos() => Produtos;

        public override void Buscar()
        {
            IndiceDoProdutoProcurado = BuscaLinearSearch(Produtos, 0, Produtos.Length, ValorProcurado);
        }

        /// <summary>
        /// BuscaLinearSearch:
        /// - Percorre todos os elementos da lista, se o item não existir toda lista é percorrida;
        /// -- Ao encontrar retorna o indice;
        /// -- Se não encontrar retorna -1;
        /// </summary>
        /// <param name="pProdutos"></param>
        /// <param name="pDe"></param>
        /// <param name="pAte"></param>
        /// <param name="pBuscando"></param>
        /// <returns></returns>
        private int BuscaLinearSearch(Produto[] pProdutos, int pDe, int pAte, double pBuscando)
        {
            for (int atual = pDe; atual < pAte; atual++)
            {
                if (pProdutos[atual].Valor == pBuscando)
                {
                    return atual;
                }
            }

            return -1;
        }
    }
}
