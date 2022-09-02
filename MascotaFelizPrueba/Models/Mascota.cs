using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MascotaFelizPrueba.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Color { get; set; }

        public string Especie { get; set; }

        public string Raza { get; set; }

        public Dueno Dueno { get; set; }
        public Veterinario Veterinario { get; set; }
        public Historia Historia { get; set; }


        public Mascota()
        {

        }


    }
}
