using System;
using System.Collections.Generic;

class Torre
{
    public Stack<int> Discos { get; private set; }
    public string Nombre { get; private set; }

    public Torre(string nombre)
    {
        Nombre = nombre;
        Discos = new Stack<int>();
    }

    public void MoverDiscoA(Torre destino)
    {
        int disco = Discos.Pop();
        destino.Discos.Push(disco);
        Console.WriteLine($"Mover disco {disco} desde {Nombre} hacia {destino.Nombre}");
    }
}

class TorresDeHanoi
{
    /// <summary>
    /// Mueve los discos de una torre a otra usando recursión y pilas.
    /// </summary>
    public static void Resolver(int n, Torre origen, Torre auxiliar, Torre destino)
    {
        if (n == 1)
        {
            origen.MoverDiscoA(destino);
        }
        else
        {
            Resolver(n - 1, origen, destino, auxiliar);
            origen.MoverDiscoA(destino);
            Resolver(n - 1, auxiliar, origen, destino);
        }
    }

    static void Main()
    {
        int numDiscos;
        Console.Write("Ingrese el número de discos: ");
        numDiscos = int.Parse(Console.ReadLine());

        Torre origen = new Torre("Origen");
        Torre auxiliar = new Torre("Auxiliar");
        Torre destino = new Torre("Destino");

        // Se apilan los discos en orden descendente
        for (int i = numDiscos; i >= 1; i--)
        {
            origen.Discos.Push(i);
        }

        Console.WriteLine("\n🔁 Secuencia de movimientos:\n");
        Resolver(numDiscos, origen, auxiliar, destino);
    }
}