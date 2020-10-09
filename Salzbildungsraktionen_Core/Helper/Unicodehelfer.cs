using System;
using System.Collections.Generic;
using System.Text;

namespace Salzbildungsreaktionen_Core.Helper
{
    public class Unicodehelfer
    {       
        public static char GetSubscriptOfNumber(int number)
        {
            // "₁₂₃₄₅₆₇₈₉"
            switch (number)
            {
                case 1:
                    return '₁';
                case 2:
                    return '₂';
                case 3:
                    return '₃';
                case 4:
                    return '₄';
                case 5:
                    return '₅';
                case 6:
                    return '₆';
                case 7:
                    return '₇';
                case 8:
                    return '₈';
                case 9:
                    return '₉';
                default:
                    return 'x';
            }
        }
    }
}
