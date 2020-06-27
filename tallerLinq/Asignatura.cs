using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace tallerLinq
{
    class Asignatura {
        public string NombreA { get; set; }
        public string Duracion { get; set; }
        public int Creditos { get; set; }
        public int idAsignatura { get; set; }

        public Asignatura(string nombre, string duracion, int creditos, int idA)
        {
            NombreA = nombre;
            Duracion = duracion;
            Creditos = creditos;
            idAsignatura = idA;
        }

        public string NombreYCreditos
        {
            get
            {
                return NombreA + " - " + Creditos;
            }
        }
    }
}
