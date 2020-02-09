﻿using Kontract.Kompression;

namespace Kompression.PatternMatch.PriceCalculators
{
    public class NintendoRlePriceCalculator : IPriceCalculator
    {
        public int CalculateLiteralPrice(int value, int literalRunLength, bool firstLiteralRun)
        {
            if (literalRunLength % 0x80 == 1)
                return 16;

            return 8;
        }

        public int CalculateMatchPrice(int displacement, int length, int matchRunLength)
        {
            return 16;
        }
    }
}
