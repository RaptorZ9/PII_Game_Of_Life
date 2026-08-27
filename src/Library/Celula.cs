//------------------------------------------------------------------------------
// <copyright file="Celula.cs" company="Universidad Católica del Uruguay">
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
    /// Clase dedicada a los comportamientos y propiedades de las celulas.
    /// </summary>
    public class Celula
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Celula"/>.
        /// Crea la cedula dependiendo dando al parametro alive la inicializacion requerida.
        /// </summary>
        /// <param name="alive"> Valor requerido para la propiedad Alive. </param>
        /// <param name="x"> Posicion x de la celula. </param>
        /// <param name="y"> Posicion y de la celula. </param>
        public Celula(bool alive, int x, int y)
        {
            this.Alive = alive;
            this.AliveNeighbors = 0;
            this.Position = new Tuple<int, int>(x, y);
        }

        /// <summary>
        /// Estado actual de la celula.
        /// </summary>
        public bool Alive { get; set; }

        /// <summary>
        /// Guarda la posicion de la celula en el tablero.
        /// </summary>
        public Tuple<int, int> Position { get; }

        /// <summary>
        /// Numero de vecinos vivos.
        /// </summary>
        public int AliveNeighbors { get; set; }

       /// <summary>
       /// Revisa la cantidad de vecinos vivos y actualiza la propiedad.
       /// </summary>
       /// <param name="tabla"> La tabla donde se encuentra la celula.</param>
       /// <param name="boardWidth"> El ancho de la tabla. </param>
       /// <param name="boardHeight"> El alto de la tabla. </param>
        public void CheckAliveNeighbors(Celula[,] tabla, int boardWidth, int boardHeight)
        {
            int aliveNeighbors = 0;
            for (int i = this.Position.Item1 - 1; i <= this.Position.Item1 + 1; i++)
                    {
                        for (int j = this.Position.Item2 - 1; j <= this.Position.Item2 + 1; j++)
                            {
                                if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && tabla[i, j].Alive)
                                {
                                    aliveNeighbors++;
                                }
                            }
                    }

            if (this.Alive)
            {
                aliveNeighbors--;
            }

            this.AliveNeighbors = aliveNeighbors;
        }

        /// <summary>
        /// Cambia el estado de la celula dependiendo de sus vecinos.
        /// </summary>
        public void ChangeState()
        {
            if (this.Alive && this.AliveNeighbors < 2)
            {
                // Célula muere por baja población
                this.Alive = false;
            }
            else if (this.Alive && this.AliveNeighbors > 3)
            {
                // Célula muere por sobrepoblación
                this.Alive = false;
            }
            else if (!this.Alive && this.AliveNeighbors == 3)
            {
                // Célula nace por reproducción
                this.Alive = true;
            }
        }
    }
}