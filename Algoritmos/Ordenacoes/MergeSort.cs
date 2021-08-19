namespace Algoritmos.Ordenacoes
{
    public class MergeSort : Order
    {
        private readonly Produto[] Produtos;

        public MergeSort(Produto[] pProdutos)
        {
            Produtos = pProdutos;
            NomeRotinaOrdenacao = "MergeSort";
        }

        protected override Produto[] RecuperarProdutos() => Produtos;

        public override void Ordenar()
        {
            OrdenacaoMergeSort(Produtos, 0, Produtos.Length);
        }

        /// <summary>
        /// MergeSort:
        /// - Método recursivo, após a primeira chamada fica em recursão sempre para a metade dos itens (enquanto a quantidade de itens maior que 1);
        /// - Como nosso intercala é bom com poucos itens a recursividade vai diminuir os itens a serem intercalados até que toda ordenação seja feita;
        /// </summary>
        /// <param name="pProdutos">Itens</param>
        /// <param name="pInicio">Inicio da coleção</param>
        /// <param name="pTermino">Fim da coleção</param>
        private void OrdenacaoMergeSort(Produto[] pProdutos, int pInicio, int pTermino)
        {
            int quantidade = pTermino - pInicio;
            if (quantidade > 1)
            {
                int meio = (pInicio + pTermino) / 2;
                OrdenacaoMergeSort(pProdutos, pInicio, meio);
                OrdenacaoMergeSort(pProdutos, meio, pTermino);
                Intercalar(pProdutos, pInicio, meio, pTermino);
            }
        }

        /// <summary>
        /// Intercala elementos já ordenados, funciona bem com 1 elemento, 2 elementos fora de ordem ou 2 elementos na ordem,
        /// ou seja, é possível ordenar coleções inteiras com esse método, desde que em pequenas partes
        /// </summary>
        /// <param name="pProdutos">Itens</param>
        /// <param name="pInicio">Inicio (primeiro grupo)</param>
        /// <param name="pMeio">Meio (fom do primeiro grupo e inicio do segundo</param>
        /// <param name="pTermino">Fim do segundo grupo</param>
        private void Intercalar(Produto[] pProdutos, int pInicio, int pMeio, int pTermino)
        {
            var resultado = new Produto[pTermino - pInicio];

            int atual = 0; // Contador para o array resultado
            int atual1 = pInicio; // Contador para a primeira parte do array 
            int atual2 = pMeio; // Contador para a segunda parte do array

            // troca os itens de posição, menores a esquerda
            while (atual1 < pMeio && atual2 < pTermino)
            {
                var produto1 = pProdutos[atual1];
                var produto2 = pProdutos[atual2];

                if (produto1.Valor < produto2.Valor)
                {
                    resultado[atual] = produto1;
                    atual1++;
                }
                else
                {
                    resultado[atual] = produto2;
                    atual2++;
                }

                atual++;
            }

            // caso sobrem itens no grupo 1 os coloca na coleção final
            while (atual1 < pMeio)
            {
                resultado[atual] = pProdutos[atual1];
                atual1++;
                atual++;
            }

            // caso sobrem itens no grupo 2 os coloca na coleção final
            while (atual2 < pTermino)
            {
                resultado[atual] = pProdutos[atual2];
                atual2++;
                atual++;
            }

            for (int contador = 0; contador < atual; contador++)
            {
                pProdutos[pInicio + contador] = resultado[contador];
            }
        }
    }
}
