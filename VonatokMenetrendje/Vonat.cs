using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VonatokMenetrendje
{
    internal class Vonat
    {
        private string vonatSzam;
        private DateTime indulasIdo;
        private DateTime erkezesIdo;
        private string utvonal;

        public Vonat(string vonatSzam, DateTime indulasIdo, DateTime erkezesIdo, string utvonal)
        {
            this.VonatSzam = vonatSzam;
            this.IndulasIdo = indulasIdo;
            this.ErkezesIdo = erkezesIdo;
            this.Utvonal = utvonal;
        }

        public string VonatSzam { get => vonatSzam; set => vonatSzam = value; }
        public DateTime IndulasIdo { get => indulasIdo; set => indulasIdo = value; }
        public DateTime ErkezesIdo { get => erkezesIdo; set => erkezesIdo = value; }
        public string Utvonal { get => utvonal; set => utvonal = value; }
        public TimeSpan UtazasiIdo
        {
            get { return erkezesIdo - indulasIdo; }
        }

        public override string ToString()
        {
            return $"{vonatSzam} {indulasIdo} {erkezesIdo} {utvonal} {UtazasiIdo}";
        }

    }
}
