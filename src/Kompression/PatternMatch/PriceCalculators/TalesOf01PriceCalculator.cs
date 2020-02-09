﻿using Kontract.Kompression;

namespace Kompression.PatternMatch.PriceCalculators
{
    public class TalesOf01PriceCalculator : IPriceCalculator
    {
        public int CalculateLiteralPrice(int value, int literalRunLength, bool firstLiteralRun)
        {
            return 9;
        }

        public int CalculateMatchPrice(int displacement, int length, int matchRunLength)
        {
            return 17;
        }
    }
}
