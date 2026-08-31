//------------------------------------------------------------------------------
// <copyright file="Impresora.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Text;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Clase para imprimir.
    /// Justificacion;
    /// SRP: su única razón de cambio es la forma en que se muestra 
    /// el tablero en pantalla. Se mantiene independiente de Tablero y Celula.
    /// </summary>
    public class Impresora
    {
        /// <summary>
        /// Imprime la tabla proporcionada.
        /// Justificación:
        /// SRP: su única razón de cambio es la forma en que se muestra el tablero en pantalla.
        /// </summary>
        /// <param name="tabla">Tabla a imprimir.</param>
        public void Imprimir(Celula[,] tabla)
        {
            Celula[,] tablero = tabla; // Variable que representa el tablero
            int width = tablero.GetLength(0); // Variable que representa el ancho del tablero
            int height = tablero.GetLength(1); // Variable que representa altura del tablero

            Console.Clear();
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tablero[x, y].Viva)
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }

                s.Append('\n');
            }

            Console.WriteLine(s.ToString());
        }
    }
}