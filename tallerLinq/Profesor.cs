using System;
using System.Collections.Generic;
using System.Text;

namespace tallerLinq
{
    class Profesor
    {
        public string Nombre { get; set; }
        public string Profeccion { get; set; }
        public int Edad { get; set; }
        public int idAsignaturaP { get; set; }

        public Profesor(string nombre, string profeccion, int edad, int idAP)
        {
            Nombre = nombre;
            Profeccion = profeccion;
            Edad = edad;
            idAsignaturaP = idAP;
        }
        public string EdadYNombre
        {
            get
            {
                return Edad + " - " + Nombre;
            }
        }
    }
}
