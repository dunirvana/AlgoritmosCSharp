using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmos
{
    public abstract class Algoritmo
    {
        public abstract void Executar();

        protected Produto[] CarregarDados()
        {
            return new Produto[11]
            {
                new Produto("Palio", 10000),
                new Produto("Corsa", 8000),
                new Produto("Fusca", 14000),
                new Produto("Corsel", 17000),
                new Produto("Fiat 147", 3000),
                new Produto("Opala", 23000),
                new Produto("Brasilia", 2900),
                new Produto("Uno", 11000),
                new Produto("Variant", 2950.90),
                new Produto("Del Rey", 15200.90),
                new Produto("Gol", 14500)
            };
        }
    }
}
