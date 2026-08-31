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
    /// Clase para guardar las celulas del tablero actual.
    /// </summary>
    public class Tablero
    {
        /// <summary>
        /// Donde se guarda el tablero.
        /// </summary>
        public Celula[,] Tabla { get; set; }

        /*agragar las propiedades width y height*/

        /// <summary>
        /// Le pide a todas las celulas que se actualicen.
        /// </summary>
        public void SiguienteMovimiento()
        {
            int anchoTabla = this.Tabla.GetLength(0);
            int altoTabla = this.Tabla.GetLength(1);

            // Cambia los vecinos vivos de todas las celulas.
            foreach (Celula celula in this.Tabla)
            {
                celula.RevisarVecinosVivos(this.Tabla, anchoTabla, altoTabla);
            }

            // Cambia el estado de todas las celulas.
            foreach (Celula celula in this.Tabla)
            {
                celula.CambiarEstado();
            }
        }

        /// <summary>
        /// Le pide al normalizador que cargue un nuevo tablero.
        /// </summary>
        /// <param name="tabla">Tabla a cargar.</param>
        public void CargarTablero(Celula[,] tabla)
        {
            this.Tabla = tabla;
        }
    }
}