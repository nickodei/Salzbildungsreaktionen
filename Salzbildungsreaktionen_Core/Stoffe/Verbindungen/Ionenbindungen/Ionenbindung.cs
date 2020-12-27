using Salzbildungsreaktionen_Core.Helfer;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Elemente;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen;
using Salzbildungsreaktionen_Core.Stoffe.Homogene_Stoffe.Reine_Stoffe.Verbindungen.Saeure;
using Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Elementare_Verbindungen;
using Salzbildungsreaktionen_Core.Teilchen.Ionen;
using System;

namespace Salzbildungsreaktionen_Core.Stoffe.Verbindungen.Ionische_Verbindungen
{
    public abstract class Ionenbindung : Verbindung
    {
        public Kation Kation { get; set; }
        public Anion Anion { get; set; }

        public Ionenbindung()
        {
        }
    }
}
