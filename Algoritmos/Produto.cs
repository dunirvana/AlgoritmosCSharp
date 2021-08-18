namespace Algoritmos
{
    public class Produto
    {
        public string Nome { get; set; }

        public double Valor { get; set; }

        public Produto(string pNome, double pValor)
        {
            Nome = pNome;
            Valor = pValor;
        }
    }
}
