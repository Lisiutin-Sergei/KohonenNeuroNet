using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KohonenNeuroNet.Core.NormalizationType;
using System.Collections.Generic;
using System.Linq;

namespace KohonenNeuroNet.Tests
{
    /// <summary>
    /// Тесты для линейного нормализатора от 0 до 1.
    /// </summary>
    [TestClass]
    public class LinearNormalizationTypeTest
    {
        /// <summary>
        /// Должен давать рандомные числа от 0 до 1.
        /// </summary>
        [TestMethod]
        public void ShouldGetDifferentRandomWeights()
        {
            var normalization = new LinearNormalizationType_0_1();
            var count = 100;
            var inputsCount = 5;

            var weights = new List<double>(count);
            for (int i = 0; i < count; i++)
            {
                weights.Add(normalization.GetNeuronWeight(inputsCount));
            }
            Assert.AreEqual(count, weights.Distinct().Count());
            Assert.IsTrue(weights.TrueForAll(w => w <= 1 && w >= 0));
        }
    }
}
