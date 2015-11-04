using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1MSP
{
    class Program
    {
        private static int CompruebaLineas() //comprueba que se haya introducido un parámetro correcto
        {
            int lineas = 0;
            do
            {
                int i;
                Console.WriteLine("Introduce el número de letras por linea: ");
                String Sline = Console.ReadLine();
                bool result = int.TryParse(Sline, out i);
                if (i > 0) lineas = i;
                else Console.WriteLine("Debe introducir un número mayor que 0");
            } while (lineas <= 0);
            return lineas;
        }
        private static void ProcesaTexto(String texto, int lineas)// procesa el texto
        {
            String nextLine = "";
            String posLine = ""; // salida con el ultimo espacio
            int antI = 0; // parametro para recordar donde se encontro el ultimo espacio
            int c = 0;
            Boolean espacio = false;
            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] == ' ')
                {
                    posLine = nextLine;
                    espacio = true;
                    antI = i;
                }
                nextLine += texto[i];
                c++;
                if (c == 1 && texto[i] == ' ') //para que no se empiece una linea con un espacio en el caso de que la linea anterior acabara con una palabra completa
                {
                    nextLine = "";
                    c--;
                }
                    if (c == lineas || i == texto.Length - 1)// si se llega al límite o se acaba el texto
                {
                    if (i<texto.Length - 1)
                    {
                        if (texto[i+1] == ' ') espacio = false; // si se ha alcanzado el final de una palabra no hace falta volver al espacio anterior
                    }
                    if (espacio == true && i != texto.Length-1)
                    {
                        nextLine = posLine;
                        i = antI;
                    }
                    if (nextLine.Length > 0)// para evitar escribir lineas con un espacio
                    {
                        Console.WriteLine(nextLine);
                    }
                    c = 0;
                    espacio = false;
                    nextLine = "";
                }
            }
        }
        static void Main(string[] args)
        {
            String texto;
            int lineas;
            Console.WriteLine("Introduce un texto: ");
            texto = Console.ReadLine();
            lineas = CompruebaLineas();
            ProcesaTexto(texto, lineas);
            Console.ReadLine();
        }
    }
}
