using Salzbildungsreaktionen_Core.Helper;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Metalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen
{
    public class Verbindung : Reinstoff
    {
        private List<Reinstoff> _Bestandteile;
        public List<Reinstoff> Bestandteile
        {
            get { return _Bestandteile; }
            set { _Bestandteile = value; }
        }

        public Verbindung(string formel) : base("", formel)
        {
            Bestandteile = new List<Reinstoff>();

            EhalteBestandteileAusFormel();
            GeneriereFormelname();
        }

        public void GeneriereFormelname()
        {
            if(Bestandteile.Count == 1)
            {
                // Nur ein Element vorhanden, also übernehem den Namen
                Name = Bestandteile[0].Name;
            }
        }

        public void EhalteBestandteileAusFormel()
        {
            char[] buchstaben = Formel.ToCharArray();
            for(int position = 0; position < buchstaben.Length; position++)
            {
                // Erhalte das aktuelle Symbol aus der Formel
                char symbol = buchstaben[position];

                if(position != buchstaben.Length - 1)
                {
                    // Überprüfe, ob es nicht ein Element mit zwei Zeichen ist oder eine andere Atomzahl hat
                    char nextSymbol = buchstaben[position + 1];

                    if (Periodensystem.Instance.Metalle.TryGetValue(symbol + "" + nextSymbol, out Metall metall2))
                    {
                        if(ÜberprüfeObAtomzahlAnders(nextSymbol))
                        {
                            // Es ist ein MetallMolekühl
                            MolekulareVerbindung metallMolekueel = new MolekulareVerbindung(metall2, Unicodehelfer.GetNumberOfSubscript(nextSymbol));
                            Bestandteile.Add(metallMolekueel);
                            position += 1;
                            continue;
                        }

                        // Es ist ein Metall
                        Bestandteile.Add(metall2);
                        continue;
                    }
                    else if(Periodensystem.Instance.Nichtmetalle.TryGetValue(symbol + "" + nextSymbol, out Nichtmetall nichtmetall2))
                    {
                        if (ÜberprüfeObAtomzahlAnders(nextSymbol))
                        {
                            // Es ist ein MetallMolekühl
                            MolekulareVerbindung nichtmetallMolekueel = new MolekulareVerbindung(nichtmetall2, Unicodehelfer.GetNumberOfSubscript(nextSymbol));
                            Bestandteile.Add(nichtmetallMolekueel);
                            position += 1;
                            continue;
                        }

                        // Es ist ein Nichtmetall
                        Bestandteile.Add(nichtmetall2);
                        continue;
                    }
                    // Erstmal in den Metallen
                    else if (Periodensystem.Instance.Metalle.TryGetValue(symbol + "", out Metall metall1))
                    {
                        if (ÜberprüfeObAtomzahlAnders(nextSymbol))
                        {
                            // Es ist ein MetallMolekühl
                            MolekulareVerbindung metallMolekueel = new MolekulareVerbindung(metall1, Unicodehelfer.GetNumberOfSubscript(nextSymbol));
                            Bestandteile.Add(metallMolekueel);
                            continue;
                        }

                        // Es ist ein Metall
                        Bestandteile.Add(metall1);
                        continue;
                    }
                    else if (Periodensystem.Instance.Nichtmetalle.TryGetValue(symbol + "", out Nichtmetall nichtmetall1))
                    {
                        if (ÜberprüfeObAtomzahlAnders(nextSymbol))
                        {
                            // Es ist ein MetallMolekühl
                            MolekulareVerbindung nichtmetallMolekueel = new MolekulareVerbindung(nichtmetall1, Unicodehelfer.GetNumberOfSubscript(nextSymbol));
                            Bestandteile.Add(nichtmetallMolekueel);
                            continue;
                        }

                        // Es ist ein Nichtmetall
                        Bestandteile.Add(nichtmetall1);
                        continue;
                    }
                }

                // Überprüfe, ob es ein Element mit einem Zeichen ist
                // Erstmal in den Metallen
                if (Periodensystem.Instance.Metalle.TryGetValue(symbol + "", out Metall metall))
                {
                    // Es ist ein Metall
                    Bestandteile.Add(metall);
                    continue;
                }
                else if (Periodensystem.Instance.Nichtmetalle.TryGetValue(symbol + "", out Nichtmetall nichtmetall))
                {
                    // Es ist ein Nichtmetall
                    Bestandteile.Add(nichtmetall);
                    continue;
                }
            }
        }

        public bool ÜberprüfeObAtomzahlAnders(char nextSymbol)
        {
            return Unicodehelfer.GetNumberOfSubscript(nextSymbol) != -1;
        }
    }
}
