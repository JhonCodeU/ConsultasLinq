using System;
using System.Collections.Generic;
using System.Text;

namespace tallerLinq
{
    class universidad
    {
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int NumeroProgramas { get; set; }
        public int IdUniversidad { get; set; }
        public int IdCiudad { get; set; }

        public universidad(string nombre, string ciudad, int numeroProgramas, int idUniversidad, int idCiudad)
        {
            Nombre = nombre;
            Ciudad = ciudad;
            NumeroProgramas = numeroProgramas;
            IdUniversidad = idUniversidad;
            IdCiudad = idCiudad;
        }
    }
}
