namespace Algoritmos.Ordenacoes
{
    public class QuickSort : Order
    {
        private readonly Produto[] Produtos;

        public QuickSort(Produto[] pProdutos)
        {
            Produtos = pProdutos;
            NomeRotinaOrdenacao = "QuickSort";
        }

        protected override Produto[] RecuperarProdutos() => Produtos;

        public override void Ordenar()
        {
            OrdenacaoQuickSort(Produtos, 0, Produtos.Length);
        }

        /// <summary>
        /// QuickSort:
        /// - Método recursivo, após a primeira chamada fica em recursão dividindo a coleção com base no pivô (enquanto a quantidade de itens maior que 1);
        /// - Coloca o pivô na posição correta, os menores a esquerda e os maiores a direita;
        /// </summary>
        /// <param name="pProdutos"></param>
        /// <param name="pDe"></param>
        /// <param name="pAte"></param>
        private void OrdenacaoQuickSort(Produto[] pProdutos, int pDe, int pAte)
        {
            int elementos = pAte - pDe;
            if (elementos > 1)
            {
                int posicaoDoPivo = QuebrarNoPivo(pProdutos, pAte);
                OrdenacaoQuickSort(pProdutos, pDe, posicaoDoPivo);
                OrdenacaoQuickSort(pProdutos, posicaoDoPivo + 1, pAte);
            }
        }

        /// <summary>
        /// Dado um pivô (termino - 1), coloca o mesmo em sua posição correta, onde os menores ficam a esquerda e os maiores a direita:
        /// - Percorre todos os produtos até o pivô (termino - 1);
        /// - Para cada produto verifica se o atual é menor que o pivô, se for troca os dois de posição;
        /// - Após o laço troca de posição o pivô com o menor;
        /// </summary>
        /// <param name="pProdutos">Itens</param>
        /// <param name="pTermino">Indice final</param>
        /// <returns>Retorna a posição atual do pivô</returns>
        private int QuebrarNoPivo(Produto[] pProdutos, int pTermino)
        {
            Produto pivo = pProdutos[pTermino - 1];
            int menores = 0;
            for (int analise = 0; analise < pTermino - 1; analise++)
            {
                Produto atual = pProdutos[analise];
                if (atual.Valor < pivo.Valor)
                {
                    TrocarProdutoDePosicao(pProdutos, analise, menores);
                    menores++;
                }
            }
            TrocarProdutoDePosicao(pProdutos, pTermino - 1, menores);
            return menores;
        }

        private void TrocarProdutoDePosicao(Produto[] pProdutos, int pDe, int pPara)
        {
            Produto produto1 = pProdutos[pDe];
            Produto produto2 = pProdutos[pPara];
            pProdutos[pDe] = produto2;
            pProdutos[pPara] = produto1;
        }
    }
}
