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
    /// Clase para cargar un estado de board desde una fuente.
    /// </summary>
    public class Normalizador
    {
        /// <summary>
        /// Retorna una board creada a partir de una fuente.
        /// </summary>
        /// <param name="ruta">Ruta del archivo a cargar.</param>
        /// <returns>Array de bools en dos dimensiones.</returns>
        public Celula[,] CargarTabla(string ruta)
        {
            string url = ruta;
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            Celula[,] board = new Celula[contentLines.Length, contentLines[0].Length];
            for (int y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        board[x, y] = new Celula(true, x, y);
                    }
                    else
                    {
                        board[x, y] = new Celula(false, x, y);
                    }
                }
            }

            return board;
        }
    }
}