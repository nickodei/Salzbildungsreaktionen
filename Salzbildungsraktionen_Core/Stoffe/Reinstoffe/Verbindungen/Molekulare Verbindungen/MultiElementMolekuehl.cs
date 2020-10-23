using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using System.Collections.Generic;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen
{
    public class MultiElementMolekuehl : Molekuehl
    {
        private string _Name;
        public override string Name
        {
            get { return _Name; }
        }

        private string _Formel;
        public override string Formel
        {
            get { return _Formel; }
        }

        private Reinstoff[] _Bestandteile;
        public Reinstoff[] Bestandteile
        {
            get { return _Bestandteile; }
            set { _Bestandteile = value; }
        }

        public MultiElementMolekuehl(string formel) : base()
        {
            _Formel = formel;

            GeneriereBestandteileAusFormel(formel);
        }

        public MultiElementMolekuehl(params Reinstoff[] bestandteile) : base()
        {
            Bestandteile = bestandteile;
        }

        protected void GeneriereBestandteileAusFormel(string formel)
        {
            List<Reinstoff> bestandteile = new List<Reinstoff>();

            char[] buchstaben = formel.ToCharArray();
            for (int position = 0; position < buchstaben.Length; position++)
            {
                // Erhalte das aktuelle Symbol aus der Formel
                char symbol = buchstaben[position];
                if (position != buchstaben.Length - 1)
                {
                    // Überprüfe, ob es nicht ein Element mit zwei Zeichen ist oder eine andere Atomzahl hat
                    char nextSymbol = buchstaben[position + 1];

                    if (Periodensystem.Instance.Metalle.TryGetValue(symbol + "" + nextSymbol, out Metall metall2))
                    {
                        if (ÜberprüfeObAtomzahlAnders(nextSymbol))
                        {
                            // Es ist ein MetallMolekühl
                            ElementMolekuehl metallMolekueel = new ElementMolekuehl(metall2, UnicodeHelfer.GetNumberOfSubscript(nextSymbol));
                            bestandteile.Add(metallMolekueel);
                            position += 1;
                            continue;
                        }

                        // Es ist ein Metall
                        bestandteile.Add(metall2);
                        continue;
                    }
                    else if (Periodensystem.Instance.Nichtmetalle.TryGetValue(symbol + "" + nextSymbol, out Nichtmetall nichtmetall2))
                    {
                        if (ÜberprüfeObAtomzahlAnders(nextSymbol))
                        {
                            // Es ist ein MetallMolekühl
                            ElementMolekuehl nichtmetallMolekueel = new ElementMolekuehl(nichtmetall2, UnicodeHelfer.GetNumberOfSubscript(nextSymbol));
                            bestandteile.Add(nichtmetallMolekueel);
                            position += 1;
                            continue;
                        }

                        // Es ist ein Nichtmetall
                        bestandteile.Add(nichtmetall2);
                        continue;
                    }
                    // Erstmal in den Metallen
                    else if (Periodensystem.Instance.Metalle.TryGetValue(symbol + "", out Metall metall1))
                    {
                        if (ÜberprüfeObAtomzahlAnders(nextSymbol))
                        {
                            // Es ist ein MetallMolekühl
                            ElementMolekuehl metallMolekueel = new ElementMolekuehl(metall1, UnicodeHelfer.GetNumberOfSubscript(nextSymbol));
                            bestandteile.Add(metallMolekueel);
                            continue;
                        }

                        // Es ist ein Metall
                        bestandteile.Add(metall1);
                        continue;
                    }
                    else if (Periodensystem.Instance.Nichtmetalle.TryGetValue(symbol + "", out Nichtmetall nichtmetall1))
                    {
                        if (ÜberprüfeObAtomzahlAnders(nextSymbol))
                        {
                            // Es ist ein MetallMolekühl
                            ElementMolekuehl nichtmetallMolekueel = new ElementMolekuehl(nichtmetall1, UnicodeHelfer.GetNumberOfSubscript(nextSymbol));
                            bestandteile.Add(nichtmetallMolekueel);
                            continue;
                        }

                        // Es ist ein Nichtmetall
                        bestandteile.Add(nichtmetall1);
                        continue;
                    }
                }

                // Überprüfe, ob es ein Element mit einem Zeichen ist
                // Erstmal in den Metallen
                if (Periodensystem.Instance.Metalle.TryGetValue(symbol + "", out Metall metall))
                {
                    // Es ist ein Metall
                    bestandteile.Add(metall);
                    continue;
                }
                else if (Periodensystem.Instance.Nichtmetalle.TryGetValue(symbol + "", out Nichtmetall nichtmetall))
                {
                    // Es ist ein Nichtmetall
                    bestandteile.Add(nichtmetall);
                    continue;
                }
            }

            Bestandteile = bestandteile.ToArray();
        }
    }
}
