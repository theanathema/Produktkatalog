using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Produktkatalog.Models
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public double Pris { get; set; }

        [DataType(DataType.MultilineText)]
        public string Beskrivning { get; set; }

    }
}