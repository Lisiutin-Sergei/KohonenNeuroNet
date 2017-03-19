using System;

namespace KohonenNeuroNet.Core.NormalizationType
{
    /// <summary>
    /// Статичный рандомайзер.
    /// </summary>
    public static class Randomizer
    {
        private static readonly Random _random = new Random();

        public static Random Instance
        {
            get
            {
                return _random;
            }
        }
    }
}
