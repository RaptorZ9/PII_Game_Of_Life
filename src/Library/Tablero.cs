//------------------------------------------------------------------------------
// <copyright file="Tablero.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Clase para crear y modificar el tablero.
    /// </summary>
    public class Tablero
    {
        /// <summary>
        /// Donde se guarda el tablero.
        /// </summary>
        public bool[,] Table { get; set; }

        /// <summary>
        /// Actualiza el estado del tablero.
        /// </summary>
        public void SiguienteMovimiento()
        {
            bool[,] gameBoard = this.Table;
            int boardWidth = gameBoard.GetLength(0);
            int boardHeight = gameBoard.GetLength(1);

            bool[,] cloneboard = new bool[boardWidth, boardHeight];
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x - 1; i <= x + 1; i++)
                    {
                        for (int j = y - 1; j <= y + 1; j++)
                            {
                                if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && gameBoard[i, j])
                                {
                                    aliveNeighbors++;
                                }
                            }
                    }

                    if (gameBoard[x, y])
                    {
                        aliveNeighbors--;
                    }

                    if (gameBoard[x, y] && aliveNeighbors < 2)
                    {
                        // Célula muere por baja población
                        cloneboard[x, y] = false;
                    }
                    else if (gameBoard[x, y] && aliveNeighbors > 3)
                    {
                        // Célula muere por sobrepoblación
                        cloneboard[x, y] = false;
                    }
                    else if (!gameBoard[x, y] && aliveNeighbors == 3)
                    {
                        // Célula nace por reproducción
                        cloneboard[x, y] = true;
                    }
                    else
                    {
                        // Célula mantiene el estado que tenía
                        cloneboard[x, y] = gameBoard[x, y];
                    }
                }
            }

            this.Table = cloneboard;
        }

        /// <summary>
        /// Metodo para cargar un tablero de un archivo.
        /// </summary>
        /// <param name="tabla">Tabla a cargar.</param>
        public void CargarTablero(bool[,] tabla)
        {
            this.Table = tabla;
        }
    }
}