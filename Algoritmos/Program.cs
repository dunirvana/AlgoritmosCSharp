using System;
using System.Collections.Generic;

namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            var opcoes = new Dictionary<string, Algoritmo>
            {
                { "#", new Ordenacao("\n### Ordenação ###\n") },
                { "1", new Ordenacao("SelectionSort") },
                { "2", new Ordenacao("InsertionSort") },
                { "3", new Ordenacao("MergeSort") },
                { "4", new Ordenacao("QuickSort") },

                { "##", new Ordenacao("\n### Busca ###\n") },
                { "5", new Busca("LinearSearch") },

                { "####", new Ordenacao("\n-------------") },
                { "0", new Ordenacao("Sair") }
            };

            MontarMenu(opcoes);
        }

        static void MontarMenu(Dictionary<string, Algoritmo> pOpcoes)
        {
            Console.Clear();
            foreach (var item in pOpcoes)
            {
                var inicio = "[{0}]-";

                Console.WriteLine(string.Format("{0}{1}", (item.Key.Contains("#") ? "" : (string.Format(inicio, item.Key))), item.Value.ToString()));
            }

            Console.WriteLine("Escolha uma das opções:");
            Console.WriteLine("-------------\n");
            var digitado = Console.ReadLine();
            if (digitado == "0")
                return;

            if (!pOpcoes.ContainsKey(digitado))
            {
                Console.WriteLine(string.Format("Opção inválida: '{0}'. Pressione uma tecla para continuar!", digitado));
                Console.ReadKey();
            }
            else
                ExecutarOperacao(pOpcoes[digitado]);


            MontarMenu(pOpcoes);
        }

        static void ExecutarOperacao(Algoritmo pAlgoritmo)
        {
            Console.Clear();

            pAlgoritmo.Executar();
            NotificarTerminoOperacaoESolicitarDigitacao(pAlgoritmo.ToString());
        }

        static void NotificarTerminoOperacaoESolicitarDigitacao(string pOperacao)
        {           
            Console.WriteLine("\n\n********************************************************");
            Console.WriteLine(string.Format("Operação '{0}' encerrada. Pressione uma tecla para continuar!", pOperacao));
            Console.WriteLine("********************************************************\n\n");
            Console.ReadKey();

            Console.Clear();
        }
    }
}
