//------------------------------------------------------------------------------
// <copyright file="Normalizador.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Clase para cargar un estado de tablero desde una fuente.
    /// </summary>
    public class Normalizador
    {
        /// <summary>
        /// Retorna una tablero creado a partir de una fuente.
        /// </summary>
        /// <param name="ruta">Ruta del archivo a cargar.</param>
        /// <returns> Array de Celulas en dos dimensiones. </returns>
        public Celula[,] CargarTabla(string ruta)
        {
            string url = ruta;
            string contenido = File.ReadAllText(url);
            string[] contenidoLineas = contenido.Split('\n');
            Celula[,] tablero = new Celula[contenidoLineas.Length, contenidoLineas[0].Length];
            for (int y = 0; y < contenidoLineas.Length; y++)
            {
                for (int x = 0; x < contenidoLineas[y].Length; x++)
                {
                    if (contenidoLineas[y][x] == '1')
                    {
                        tablero[x, y] = new Celula(true, x, y);
                    }
                    else
                    {
                        tablero[x, y] = new Celula(false, x, y);
                    }
                }
            }

            return tablero;
        }
    }
}