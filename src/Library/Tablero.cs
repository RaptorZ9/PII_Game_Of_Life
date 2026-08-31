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
    /// Justificación:
    /// Expert: es la única que tiene acceso a la colección completa de
    /// células, por lo que es la responsable de coordinar el recorrido
    /// y el avance de una generación. Cada Celula solo conoce su propio
    /// estado, no el del resto del tablero.
    /// 
    /// SRP porque su única razón de cambio es cómo se coordina el
    /// avance de una generación (no decide el estado de cada célula, eso lo
    /// hace Celula). Separar "coordinar" de "decidir el estado individual"
    /// evita que Tablero termine con dos responsabilidades distintas.
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
        /// El cálculo de vecinos y el cambio de estado se realizan en dos loops
        /// distintos para que el orden de recorrido no afecte el resultado, es
        /// decir, para que ninguna célula se compare con vecinos que ya fueron
        /// actualizados en la misma generación.
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
        /// Cumple con SRP porque el Tablero no conoce el origen de la información 
        /// como el archivo u otra fuente, solo la recibe ya construida.
        /// De esta forma, un cambio en la manera de cargar el tablero no afecta a esta clase.
        /// </summary>
        /// <param name="tabla">Tabla a cargar.</param>
        public void CargarTablero(Celula[,] tabla)
        {
            this.Tabla = tabla;
        }
    }
}