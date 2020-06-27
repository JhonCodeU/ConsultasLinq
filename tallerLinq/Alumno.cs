using
System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tallerLinq
{
    class Alumno
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Nota { get; set; }
        public int Idprograma { get; set; }
        public int IdUniversidad { get; set; }
        public int IdCiudad { get; set; }

        public Alumno(string nombre, int edad, double nota, int idprograma, int idUniversidad, int idCiudad)
        {
            Nombre = nombre;
            Edad = edad;
            Nota = nota;
            Idprograma = idprograma;
            IdUniversidad = idUniversidad;
            IdCiudad = idCiudad;
        }

        public string EdadYNombreAlumno
        {
            get
            {
                return Nombre + " - " + Edad;
            }
        }
    }
}