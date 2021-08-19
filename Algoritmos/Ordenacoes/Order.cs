using System;

namespace Algoritmos.Ordenacoes
{
    public abstract class Order
    {        
        protected string NomeRotinaOrdenacao { get; set; }

        public abstract void Ordenar();

        protected abstract Produto[] RecuperarProdutos();

        public void ImprimirDadosAntesDaOrdenacao()
        {
            Imprimir(string.Format("{0}: Dados Antes Da Ordenacao", NomeRotinaOrdenacao));
        }

        public void ImprimirDadosAposOrdenacao()
        {
            Imprimir(string.Format("{0}: Dados Apos Ordenacao", NomeRotinaOrdenacao));
        }


        protected void TrocarProdutosDePosicao(Produto[] pProdutos, int pPrimeiro, int pSegundo)
        {
            Produto primeiroProduto = pProdutos[pPrimeiro];
            Produto segundoProduto = pProdutos[pSegundo];

            pProdutos[pPrimeiro] = segundoProduto;
            pProdutos[pSegundo] = primeiroProduto;
        }

        private void Imprimir(string pMensagem)
        {
            Console.WriteLine(string.Format("\n### {0} ###\n ", pMensagem));

            var produtos = RecuperarProdutos();
            if (produtos == null || produtos.Length <= 0)
            {
                Console.WriteLine("Nenhum produto encontrado");
                return;
            }

            var mensagem = string.Empty;
            var totalProdutosPorLinha = 4;
            var totalProdutos = 0;

            for (int i = 0; i < produtos.Length; i++)
            {
                mensagem += string.Format("[{0}] {1} custa {2},  ", i+1, produtos[i].Nome, produtos[i].Valor);
                totalProdutos++;

                if (totalProdutos == totalProdutosPorLinha)
                {
                    Console.WriteLine(mensagem);

                    totalProdutos = 0;
                    mensagem = string.Empty;
                }                
            }

            if (totalProdutos >0)
                Console.WriteLine(mensagem);

        }

    }
}
