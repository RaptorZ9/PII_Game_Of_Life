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
    /// Justificacion: esta clase cumple con Expert: es quien tiene la informacion necesaria (su
    /// posición y su estado) para calcular vecinos vivos y decidir si vive o
    /// muere, entonces le asignamos esa responsabilidad a ella y no a Tablero.
    /// También cumple SRP porque tiene una sola razón de cambio: si cambian
    /// las reglas del juego, solo se modifica esta clase.
    /// </summary>
    public class Celula
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Celula"/>.
        /// Crea la cedula dependiendo dando al parametro viva la inicializacion requerida.
        /// </summary>
        /// <param name="viva"> Valor requerido para la propiedad Viva. </param>
        /// <param name="x"> Posicion x de la celula. </param>
        /// <param name="y"> Posicion y de la celula. </param>
        public Celula(bool viva, int x, int y)
        {
            this.Viva = viva;
            this.VecinosVivos = 0;
            this.Posicion = new Tuple<int, int>(x, y);
        }

        /// <summary>
        /// Estado actual de la celula.
        /// </summary>
        public bool Viva { get; set; }

        /// <summary>
        /// Guarda la posicion de la celula en el tablero.
        /// </summary>
        public Tuple<int, int> Posicion { get; }

        /// <summary>
        /// Numero de vecinos vivos.
        /// </summary>
        public int VecinosVivos { get; set; }

       /// <summary>
       /// Revisa la cantidad de vecinos vivos y actualiza la propiedad.
       /// </summary>
       /// <param name="tablero"> La tablero donde se encuentra la celula.</param>
       /// <param name="anchoTablero"> El ancho de la tablero. </param>
       /// <param name="altoTablero"> El alto de la tablero. </param>
        public void RevisarVecinosVivos(Celula[,] tablero, int anchoTablero, int altoTablero)
        {
            int vecinosVivos = 0;
            for (int i = this.Posicion.Item1 - 1; i <= this.Posicion.Item1 + 1; i++)
                    {
                        for (int j = this.Posicion.Item2 - 1; j <= this.Posicion.Item2 + 1; j++)
                            {
                                if (i >= 0 && i < anchoTablero && j >= 0 && j < altoTablero && tablero[i, j].Viva)
                                {
                                    vecinosVivos++;
                                }
                            }
                    }

            if (this.Viva)
            {
                vecinosVivos--;
            }

            this.VecinosVivos = vecinosVivos;
        }

        /// <summary>
        /// Cambia el estado de la celula dependiendo de sus vecinos.
        /// </summary>
        public void CambiarEstado()
        {
            if (this.Viva && this.VecinosVivos < 2)
            {
                // Célula muere por baja población
                this.Viva = false;
            }
            else if (this.Viva && this.VecinosVivos > 3)
            {
                // Célula muere por sobrepoblación
                this.Viva = false;
            }
            else if (!this.Viva && this.VecinosVivos == 3)
            {
                // Célula nace por reproducción
                this.Viva = true;
            }
        }
    }
}