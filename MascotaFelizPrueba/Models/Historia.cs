using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MascotaFelizPrueba.Models
{
    public class Historia
    {
        public int Id { get; set; }
        public DateTime FechaInicial { get; set; }
        public List<VisitaPyP> VisitasPyP { get; set; }

        public Historia()
        {

        }

    }
}
