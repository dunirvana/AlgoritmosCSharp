using System;

namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            new Ordenacao("SelectionSort");
            NotificarTerminoOperacaoESolicitarDigitacao("ordenação SelectionSort");

            new Ordenacao("InsertionSort");
            NotificarTerminoOperacaoESolicitarDigitacao("ordenação InsertionSort");

            new Ordenacao("MergeSort");
            NotificarTerminoOperacaoESolicitarDigitacao("ordenação MergeSort");

            new Ordenacao("QuickSort");
            NotificarTerminoOperacaoESolicitarDigitacao("ordenação QuickSort");
            
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
