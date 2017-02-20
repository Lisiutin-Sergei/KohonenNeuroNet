using KohonenNeuroNet.Core.NeuralNetwork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KohonenNeuroNet.Tests
{
    /// <summary>
    /// Тесты для абстрактной нейронной сети.
    /// </summary>
    [TestClass]
    public class AbstractNetworkTest
    {
        /// <summary>
        /// Должен правильно рассчитывать евклидово расстояние между 2 векторами
        /// </summary>
        [TestMethod]
        public void ShouldCalculateEuclidianDistance()
        {
            var abstractNetwork = new ClassicKohonenNetwork();
            var neuronWeights = new double[] { 0.1, 0.4, 0.5 };
            var input = new double[] { 1, 0, 0 };

            var decimals = 2;
            double distance = abstractNetwork.GetEuclideanDistance(neuronWeights, input);
            double realDistance = 1.105;
            Assert.AreEqual(Math.Round(realDistance, decimals), Math.Round(distance, decimals));
        }
    }
}
