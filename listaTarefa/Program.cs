using System;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks.Dataflow;
class Program
{
    

    //funcao adicionar
    static void Adicionar(List <string> Lista)
    {
        string? Nome;
        Console.Write("Digite a tarefa: ");
        Nome = Console.ReadLine();
        Lista.Add(Nome);
    }
            
    //funcao mostrar
    static void Mostrar(List <string> Lista)
    {
        int i =1;
        foreach(string tarefa in Lista)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"{i} {tarefa}" );
            i++;
            Console.WriteLine("--------------------------------------");
        }
        if(Lista.Count == 0)
        {
            Console.WriteLine("A lista esta vazia");
        }
    }

    //funcao remover
    static void Remover(List <string> Lista)
    {
        Console.Write("Escolha o numero da tarefa para remover: ");
        int.TryParse(Console.ReadLine(), out int indice);
        indice = indice-1;

        if (indice >=0 && indice < Lista.Count)
        {
            Lista.RemoveAt(indice);
            Console.WriteLine("tarefa removida");
        }
        else
        {
            Console.WriteLine("numero inválido");
        }
    }   
            
    static void Main()
    {
        Console.WriteLine("=== To-do List ===");

        //criar a lista
        List<string> Lista = new List<string>();

        while (true)
        {   
           
            Console.WriteLine("\n1. Adicionar tarefa");
            Console.WriteLine("2. Remover tarefa");
            Console.WriteLine("3. Mostrar lista");
            Console.WriteLine("4. Sair");

            Console.Write("opcao: ");
            int.TryParse(Console.ReadLine(), out int opcao);

            switch (opcao)
            {
                case 1: 
                    Adicionar(Lista);
                    break;
                case 2:
                    Remover(Lista);
                    break;
                case 3:
                    Mostrar(Lista);
                    break;
                case 4:
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("opcao inválida");
                    break;
            }
            if (opcao == 4)
            {
                break;
            }
        }
    }
}