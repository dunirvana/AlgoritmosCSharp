using System;

namespace Algoritmos
{
    public static class Util
    {
        public static void ImprimirProdutos(string pMensagem, Produto[] pProdutos)
        {
            Console.WriteLine(string.Format("\n### {0} ###\n ", pMensagem));

            if (pProdutos == null || pProdutos.Length <= 0)
            {
                Console.WriteLine("Nenhum produto encontrado");
                return;
            }

            var mensagem = string.Empty;
            var totalProdutosPorLinha = 4;
            var totalProdutos = 0;

            for (int i = 0; i < pProdutos.Length; i++)
            {
                mensagem += string.Format("[{0}] {1} custa {2},  ", i + 1, pProdutos[i].Nome, pProdutos[i].Valor);
                totalProdutos++;

                if (totalProdutos == totalProdutosPorLinha)
                {
                    Console.WriteLine(mensagem);

                    totalProdutos = 0;
                    mensagem = string.Empty;
                }
            }

            if (totalProdutos > 0)
                Console.WriteLine(mensagem);

        }
    }
}
