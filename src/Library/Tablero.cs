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
        public Celula[,] Table { get; set; }

        /*agragar las propiedades width y height*/

        /// <summary>
        /// Actualiza el estado del tablero.
        /// </summary>
        public void SiguienteMovimiento()
        {
            int boardWidth = this.Table.GetLength(0);
            int boardHeight = this.Table.GetLength(1);

            // Cambia los vecinos vivos de todas las celulas.
            foreach (Celula celula in this.Table)
            {
                celula.CheckAliveNeighbors(this.Table, boardWidth, boardHeight);
            }

            // Cambia el estado de todas las celulas.
            foreach (Celula celula in this.Table)
            {
                celula.ChangeState();
            }
        }

        /// <summary>
        /// Metodo para cargar un tablero de un archivo.
        /// </summary>
        /// <param name="tabla">Tabla a cargar.</param>
        public void CargarTablero(Celula[,] tabla)
        {
            this.Table = tabla;
        }
    }
}