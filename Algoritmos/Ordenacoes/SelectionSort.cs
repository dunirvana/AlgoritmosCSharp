namespace Algoritmos.Ordenacoes
{
    public class SelectionSort : Order
    {
        private readonly Produto[] Produtos;

        public SelectionSort(Produto[] pProdutos)
        {
            Produtos = pProdutos;
            NomeRotinaOrdenacao = "SelectionSort";
        }

        protected override Produto[] RecuperarProdutos() => Produtos;

        public override void Ordenar()
        {
            OrdenacaoSelectionSort(Produtos, Produtos.Length);
        }

        /// <summary>
        /// SelectionSort:
        /// - Passa por todos os itens da coleção (loop 1);
        /// - Para cada item verifica, a partir dele, qual é o menor da coleção (nova busca na coleção) e ai troca o atual pelo menor;
        /// -- A ideia é sempre buscar o menor a "direita" do item atual, se o menor a direita for menor que o atual então troca os dois de posição;
        /// </summary>
        /// <param name="pProdutos">Itens</param>
        /// <param name="pQuantidadeDeElementos">Total de itens</param>
        private void OrdenacaoSelectionSort(Produto[] pProdutos, int pQuantidadeDeElementos)
        {            
            for (int atual = 0; atual < pQuantidadeDeElementos - 1; atual++)
            {
                int menor = RecuperarIndiceDoMenorProduto(pProdutos, atual, pQuantidadeDeElementos - 1);
                TrocarProdutosDePosicao(pProdutos, atual, menor);
            }
        }

        /// <summary>
        /// Percorre os itens dentro dos limites indicados retornando o indice do menor
        /// </summary>
        /// <param name="pProdutos">Itens</param>
        /// <param name="pInicio">Inicio da busca</param>
        /// <param name="pTermino">Fim da busca</param>
        /// <returns>Indice do menor item</returns>
        private int RecuperarIndiceDoMenorProduto(Produto[] pProdutos, int pInicio, int pTermino)
        {
            int maisBarato = pInicio;
            for (int atual = pInicio; atual <= pTermino; atual++)
            {
                if (pProdutos[atual].Valor < pProdutos[maisBarato].Valor)
                {
                    maisBarato = atual;
                }
            }
            return maisBarato;
        }
    }
}
