using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionen;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Ionisch;
using System;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Salz : Verbindung
    {
        public const string Natriumchlorid = "NaCl";
        public const string Magnesiumchlorid = "MgCl₂";

        private MetallIon _Metall;
        public MetallIon Metall
        {
            get { return _Metall; }
            private set { _Metall = value; }
        }

        private int _MetallIonMolekühle;
        public int MetallIonMolekühle
        {
            get { return _MetallIonMolekühle; }
            private set { _MetallIonMolekühle = value; }
        }

        private SäurerestIon _Säurerest;
        public SäurerestIon Säurerest
        {
            get { return _Säurerest; }
            private set { _Säurerest = value; }
        }

        private int _SäurerestIonMolekühle;
        public int SäurerestIonMolekühle
        {
            get { return _SäurerestIonMolekühle; }
            private set { _SäurerestIonMolekühle = value; }
        }

        public Salz(string name, string formel, MetallIon metall, SäurerestIon säurerest) : base(name, formel)
        {
            Metall = metall;
            Säurerest = säurerest;

            InitialisiereSalz();
        }

        private void InitialisiereSalz()
        {
            GleicheLadungenAus();
            SetzeFormel();
        }

        private void GleicheLadungenAus()
        {
            int kgV = Reaktionshelfer.GetLCM(Math.Abs(Metall.Ladung), Math.Abs(Säurerest.Ladung));

            MetallIonMolekühle = kgV / Math.Abs(Metall.Ladung);
            SäurerestIonMolekühle = kgV / Math.Abs(Säurerest.Ladung);
        }

        private void SetzeFormel()
        {
            if (MetallIonMolekühle > 1)
            {
                Formel += $"{Metall.Element.Symbol}{Unicodehelfer.GetSubscriptOfNumber(MetallIonMolekühle)}";
            }
            else
            {
                Formel += $"{Metall.Element.Symbol}";
            }

            if (SäurerestIonMolekühle > 1)
            {
                if (int.TryParse(Säurerest.Formel.Last().ToString(), out int s))
                {
                    Formel += $"({Säurerest.Formel}){Unicodehelfer.GetSubscriptOfNumber(SäurerestIonMolekühle)}";
                }
                else
                {
                    Formel += $"{Säurerest.Formel}{Unicodehelfer.GetSubscriptOfNumber(SäurerestIonMolekühle)}";
                }
            }
            else
            {
                Formel += $"{Säurerest.Formel}";
            }
        }

        public static Salz ErhalteSalz(MetallIon metallIon, SäurerestIon säurerestIon)
        {
            // Die Formel sowie der Name werden während der Objekterstellung generiert
            // Somit muss hier zuerst nicht "sinnvolles" übergeben werden
            return new Salz("", "", metallIon, säurerestIon);
        }
    }
}
