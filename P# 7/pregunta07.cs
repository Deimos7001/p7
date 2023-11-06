using System;
using System.Threading;

//INF-317 - 1ER EXAMEN PARCIAL
//NOMBRE: VICTOR GABRIEL CAPIA ALI
//CI: 4762494 LP
//PREGUNTA 7. Realice el cálculo de PI con .NET

class Program
{
    // Declaración de una variable pública 'suma' para acumular la aproximación de PI/4.
    public static double suma = 0.0; 

    static void calcular_PI(object mensaje)
    {
        // Declaración de una variable local 'valor' para almacenar el valor de la aproximación en esta iteración.
        double valor = 0;
        
        // Convierte el argumento 'mensaje' a un entero que representa la posición en la serie de Leibniz.
        int posicion = (int) mensaje;

        // Calcula el valor actual de la serie de Leibniz en función de la posición.

        valor = 1 / ((2.0 * posicion) + 1.0); 

        if (posicion % 2 == 1)
        {
            suma = suma - valor; 
        }
        else
        {
            suma = suma + valor; 
        }
    }

    static void calcular_PI2(object mensaje)
    {
        // Declaración de una variable local 'valor' para almacenar el valor de la aproximación en esta iteración.
        double valor = 0;

        // Convierte el argumento 'mensaje' a un entero que representa la posición en la serie de Leibniz.
        int posicion = (int)mensaje;

        // Calcula el valor actual de la serie de Leibniz en función de la posición.

        valor = 4 / ((2.0 * posicion) + 1.0);

        if (posicion % 2 == 0)
        {
            suma = suma + valor;
        }
        else
        {
            suma = suma - valor;
        }
    }

    static void Main()
    {
        int inicio = 0; 
        int fin = 10000000; 
        for (int i = inicio; i <= fin; i++)
        {
            ThreadPool.QueueUserWorkItem(calcular_PI2, i); // Inicia el cálculo de π en subprocesos separados.

        }
        Thread.Sleep(3000);
        // Muestra la aproximación actual de π en la consola.
        Console.WriteLine("El valor de PI es: " + (suma));
        Console.ReadKey();
    }
}
