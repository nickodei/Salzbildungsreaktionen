namespace Salzbildungsreaktionen_Core.Helper
{
    public class UnicodeHelfer
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

        public static int GetNumberOfSubscript(char character)
        {
            switch (character)
            {
                case '₁':
                    return 1;
                case '₂':
                    return 2;
                case '₃':
                    return 3;
                case '₄':
                    return 4;
                case '₅':
                    return 5;
                case '₆':
                    return 6;
                case '₇':
                    return 7;
                case '₈':
                    return 8;
                case '₉':
                    return 9;
                default:
                    return -1;
            }
        }
    }
}
