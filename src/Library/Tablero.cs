//------------------------------------------------------------------------------
// <copyright file="Tablero.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------
using System.IO;

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
        public bool[,] Table{ get; set; }

        /// <summary>
        /// Actualiza el estado del tablero.
        /// </summary>
        /// <param name="tablero">El estado actual del tablero.</param>
        public void SiguienteMovimiento(bool[,] tablero)
        {
            bool[,] gameBoard = tablero;
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
        /// <param name="nombre">Nombre del archivo a cargar.</param>
        public static void CargarTablero(string nombre)
        {
            string url = nombre;
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            bool[,] board = new bool[contentLines.Length, contentLines[0].Length];
            for (int y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        board[x, y] = true;
                    }
                }
            }
        }
    }
}