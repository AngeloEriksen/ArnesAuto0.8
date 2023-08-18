using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArnesAuto.Objects
{
    internal class Kunder
    {
        public string? Fornavn { get; set; }
        public string? Efternavn { get; set; }
        public string? Telefonnummer { get; set; }
        public string? Nummerplade { get; set; }
        public string? Mærke { get; set; }
        public string? Model { get; set; }
        public string? Årgang { get; set; }
        public double? Motorstørrelse { get; set; }
        public DateTime FørsteRegistrering { get; set; }
        public DateTime SidsteSynsdato { get; set; }
    }
}
