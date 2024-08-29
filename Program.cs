using System;

namespace CuadroMagico
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            do
            {
                Console.Clear();
                Console.Write("Ingrese el valor de n (impar): ");

                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (CuadradoMagico.esPar(n))
                    {
                        Console.WriteLine("Debe ser un numero impar.");
                        Console.ReadKey(true);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(true);
                }
            }
            while (CuadradoMagico.esPar(n));

            CuadradoMagico cm = new CuadradoMagico(n);
            cm.Crear();

            Console.WriteLine("\n\nEL cuadrado mágico de orden " + n + " es:\n\n");
            cm.Mostrar();

            Console.ReadKey(true);
        }
    }

    class CuadradoMagico
    {
        private int[,] cm;
        private int n;

        public CuadradoMagico(int orden)
        {
            n = orden;
            cm = new int[n, n];
        }

        public static bool esPar(int n)
        {
            if (n % 2 == 0) return true;
            else return false;
        }

        public void Crear()
        {
            int fil = 0, col = n / 2, fil_ant = 0, col_ant = n / 2, cont = 1;

            cm[fil, col] = cont++;

            while (cont <= n * n)
            {
                fil--;
                col++;

                if (fil < 0) fil = n - 1;
                if (col > n - 1) col = 0;
                if (cm[fil, col] != 0)
                {
                    col = col_ant;
                    fil = fil_ant + 1;
                    if (fil == n) fil = 0;
                }

                cm[fil, col] = cont++;
                fil_ant = fil;
                col_ant = col;
            }
        }

        public void Mostrar()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < n; j++) Console.Write(cm[i, j] + "\t");
                Console.WriteLine();
            }
        }
    }
}