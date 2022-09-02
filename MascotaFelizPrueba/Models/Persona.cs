using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MascotaFelizPrueba.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public int Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Persona()
        {

        }


    }
}
