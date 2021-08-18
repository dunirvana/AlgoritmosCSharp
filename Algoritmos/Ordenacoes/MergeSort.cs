using System;
using System.Collections.Generic;
using System.Text;

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

        public override Produto[] RecuperarProdutos() => Produtos;

        public override void Ordenar()
        {
            OrdenacaoMergeSort(Produtos, 0, Produtos.Length);
        }

        /// <summary>
        /// MergeSort:
        /// - Método recursivo, após a primeira chamada fica em recursão sempre para a metade dos itens (enquanto a quantidade de itens maior que 1);
        /// - Como nosso intercala é bom com poucos itens a recursividade vai diminuir os itens a serem intercalados até que toda ordenação seja feita;
        /// </summary>
        /// <param name="produtos">Itens</param>
        /// <param name="inicio">Inicio da coleção</param>
        /// <param name="termino">Fim da coleção</param>
        private void OrdenacaoMergeSort(Produto[] produtos, int inicio, int termino)
        {
            Console.WriteLine(string.Format("OrdenacaoMergeSort - inicio:{0}, termino:{1}", inicio, termino));

            int quantidade = termino - inicio;
            if (quantidade > 1)
            {
                int meio = (inicio + termino) / 2;
                OrdenacaoMergeSort(produtos, inicio, meio);
                OrdenacaoMergeSort(produtos, meio, termino);
                Intercala(produtos, inicio, meio, termino);
            }
            else
                Console.WriteLine("saiu!");
        }

        /// <summary>
        /// Intercala elementos já ordenados, funciona bem com 1 elemento, 2 elementos fora de ordem ou 2 elementos na ordem,
        /// ou seja, é possível ordenar coleções inteiras com esse método, desde que em pequenas partes
        /// </summary>
        /// <param name="produtos">Itens</param>
        /// <param name="inicio">Inicio (primeiro grupo)</param>
        /// <param name="meio">Meio (fom do primeiro grupo e inicio do segundo</param>
        /// <param name="termino">Fim do segundo grupo</param>
        private void Intercala(Produto[] produtos, int inicio, int meio, int termino)
        {
            Console.WriteLine(string.Format("---> Intercala - [inicio:{0}, meio:{1}, termino:{2}]", inicio, meio, termino));

            var resultado = new Produto[termino - inicio];

            int atual = 0; // Contador para o array resultado
            int atual1 = inicio; // Contador para a primeira parte do array 
            int atual2 = meio; // Contador para a segunda parte do array

            // troca os itens de posição, menores a esquerda
            while (atual1 < meio && atual2 < termino)
            {
                var nota1 = produtos[atual1];
                var nota2 = produtos[atual2];

                if (nota1.Valor < nota2.Valor)
                {
                    resultado[atual] = nota1;
                    atual1++;
                }
                else
                {
                    resultado[atual] = nota2;
                    atual2++;
                }

                atual++;
            }

            // caso sobrem itens no grupo 1 os coloca na coleção final
            while (atual1 < meio)
            {
                resultado[atual] = produtos[atual1];
                atual1++;
                atual++;
            }

            // caso sobrem itens no grupo 2 os coloca na coleção final
            while (atual2 < termino)
            {
                resultado[atual] = produtos[atual2];
                atual2++;
                atual++;
            }

            for (int contador = 0; contador < atual; contador++)
            {
                produtos[inicio + contador] = resultado[contador];
            }
        }
    }
}
