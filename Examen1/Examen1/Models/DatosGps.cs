using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Examen1.Models
{
   public class DatosGps
    {
        [PrimaryKey,AutoIncrement]
        public int IdDatos { get; set;}

        public double longitud { get; set; }

        public double latitud { get; set; }

        [MaxLength(50)]
        public String textocorto { get; set; }

        [MaxLength(100)]
        public String textolargo { get; set; }
    }
}
