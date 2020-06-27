using System;
using System.Collections.Generic;
using System.Text;

namespace tallerLinq
{
    class Programa
    {
        public string Nombre { get; set; }
        public string Duracion { get; set; }
        public int TotalCreditos { get; set; }

        public int Idprograma { get; set; }

        public Programa(string nombre, string duracion, int totalCreditos, int idprograma)
        {
            Nombre = nombre;
            Duracion = duracion;
            TotalCreditos = totalCreditos;
            Idprograma = idprograma;
        }
    }
}
