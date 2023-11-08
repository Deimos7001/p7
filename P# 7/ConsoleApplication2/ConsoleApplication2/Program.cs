using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//INF-317 - 1ER EXAMEN PARCIAL
//NOMBRE: VICTOR GABRIEL CAPIA ALI
//CI: 4762494 LP
//PREGUNTA 7. Realice el cálculo de PI con .NET

namespace ConsoleApplication2
{
    class Program
    {
        static void Main()
        {
            int numTotalPoints = 1000000; // Número total de puntos a generar
            int numThreads = 4; // Número de hilos a utilizar

            // Contadores para puntos dentro y fuera del círculo
            int insideCircle = 0;
            int outsideCircle = 0;

            // Crear un objeto para sincronizar el acceso a los contadores
            object lockObject = new object();

            // Crear tareas paralelas para generar puntos aleatorios
            Parallel.For(0, numThreads, i =>
            {
                Random random = new Random();
                int pointsPerThread = numTotalPoints / numThreads;

                for (int j = 0; j < pointsPerThread; j++)
                {
                    double x = random.NextDouble();
                    double y = random.NextDouble();

                    // Comprueba si el punto está dentro del círculo
                    if (IsInsideCircle(x, y))
                    {
                        lock (lockObject)
                        {
                            insideCircle++;
                        }
                    }
                    else
                    {
                        lock (lockObject)
                        {
                            outsideCircle++;
                        }
                    }
                }
            });

            // Calcula la estimación de PI
            double estimatedPi = 4.0 * insideCircle / numTotalPoints;

            // Imprime el resultado
            //Console.WriteLine($"Estimación de Pi: {estimatedPi}");
            Console.WriteLine("Estimación de Pi: " + estimatedPi);

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey(); // Espera a que el usuario presione una tecla antes de salir
        }

        static bool IsInsideCircle(double x, double y)
        {
            // Comprueba si el punto (x, y) está dentro del círculo unitario
            return x * x + y * y <= 1;
        }
    }
}
