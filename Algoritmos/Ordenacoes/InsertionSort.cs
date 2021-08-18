namespace Algoritmos.Ordenacoes
{
    public class InsertionSort : Order
    {
        private readonly Produto[] Produtos;

        public InsertionSort(Produto[] pProdutos)
        {
            Produtos = pProdutos;
            NomeRotinaOrdenacao = "InsertionSort";
        }

        public override Produto[] RecuperarProdutos() => Produtos;

        public override void Ordenar()
        {
            OrdenacaoInsertionSort(Produtos, Produtos.Length);
        }

        /// <summary>
        /// InsertionSort:
        /// - Passa por todos os itens da coleção (loop 1);
        /// - Para cada item, percorre todos os itens a "esquerda" enquanto o atual (loop 1) for menor que o anterior (loop 2), enquanto isso troca de posição o anterior com o atual;
        /// -- A ideia é deslocar para a esquerda (começo do array) os menores itens, analisando de 2 em 2 itens;
        /// </summary>
        /// <param name="produtos">Itens</param>
        /// <param name="quantidadeDeElementos">Total de itens</param>
        private void OrdenacaoInsertionSort(Produto[] pProdutos, int pQuantidadeDeElementos)
        {
            for (int atual = 1; atual < pQuantidadeDeElementos; atual++)
            {
                int analise = atual;
                while (analise > 0 && pProdutos[analise].Valor < pProdutos[analise - 1].Valor)
                {
                    TrocarProdutosDePosicao(pProdutos, analise, analise - 1);

                    analise--;
                }
            }
        }
    }
}
