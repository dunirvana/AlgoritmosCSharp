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
            Util.ImprimirProdutos(string.Format("{0}: Dados Antes Da Ordenacao", NomeRotinaOrdenacao), RecuperarProdutos());
        }

        public void ImprimirDadosAposOrdenacao()
        {
            Util.ImprimirProdutos(string.Format("{0}: Dados Apos Ordenacao", NomeRotinaOrdenacao), RecuperarProdutos());
        }


        protected void TrocarProdutosDePosicao(Produto[] pProdutos, int pPrimeiro, int pSegundo)
        {
            Produto primeiroProduto = pProdutos[pPrimeiro];
            Produto segundoProduto = pProdutos[pSegundo];

            pProdutos[pPrimeiro] = segundoProduto;
            pProdutos[pSegundo] = primeiroProduto;
        }

    }
}
