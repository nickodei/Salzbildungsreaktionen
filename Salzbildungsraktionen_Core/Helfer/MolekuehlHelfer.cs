using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Elemente.Nichtmetalle;
using Salzbildungsreaktionen_Core.Stoffe.Reinstoffe.Verbindungen.Molekulare_Verbindungen;
using System.Linq;

namespace Salzbildungsreaktionen_Core.Helfer
{
    public static class MolekuehlHelfer
    {
        /// <summary>
        /// Generiert ein Wasser Molekühl
        /// </summary>
        /// <returns></returns>
        public static MultiElementMolekuehl GeneriereWasser()
        {
            Nichtmetall wasserstoff = Periodensystem.Instance.Nichtmetalle.Values.Where(x => x.Formel.Equals("H")).FirstOrDefault();
            if(wasserstoff != null)
            {
                ElementMolekuehl wasserstoffMolekuehl = new ElementMolekuehl(wasserstoff, 2);

                Nichtmetall sauerstoff = Periodensystem.Instance.Nichtmetalle.Values.Where(x => x.Formel.Equals("O")).FirstOrDefault();
                if(sauerstoff != null)
                {
                    MultiElementMolekuehl wasser = new MultiElementMolekuehl(wasserstoff, sauerstoff);
                    return wasser;
                }
            }

            return null;
        }
    }
}
