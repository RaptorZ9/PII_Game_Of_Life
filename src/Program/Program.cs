//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
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
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            string boardPath = Path.Combine(folder, "board.txt");
            // Reemplaza 👇 esta línea con tu código
            Tablero juego = new Tablero();
            Normalizador norm = new Normalizador();
            Impresora impresora = new Impresora();

            juego.CargarTablero(norm.CargarTabla(boardPath));
            impresora.Imprimir(juego.Tabla);

            while(true)
            {
                juego.SiguienteMovimiento();
                impresora.Imprimir(juego.Tabla);

                Thread.Sleep(300);
            }
        }
    }
}
