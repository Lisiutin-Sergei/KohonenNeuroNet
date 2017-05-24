using KohonenNeuroNet.Core.Model.Business;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.NeuralNetwork.NeuralNetwork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
			var decimals = 2;
			double realDistance = 1.105;
			var abstractNetwork = new SelfOrganizingMap();

			abstractNetwork.InputAttributes.Add(new InputAttributeBase { InputAttributeNumber = 0 });
			abstractNetwork.InputAttributes.Add(new InputAttributeBase { InputAttributeNumber = 1 });
			abstractNetwork.InputAttributes.Add(new InputAttributeBase { InputAttributeNumber = 2 });

			abstractNetwork.Weights.Add(new WeightBase { InputAttributeNumber = 0, NeuronNumber = 0, Value = 0.1 });
			abstractNetwork.Weights.Add(new WeightBase { InputAttributeNumber = 1, NeuronNumber = 0, Value = 0.4 });
			abstractNetwork.Weights.Add(new WeightBase { InputAttributeNumber = 2, NeuronNumber = 0, Value = 0.5 });

			abstractNetwork.Neurons.Add(new NeuronBase { NeuronNumber = 0 });
			
			var inputVector = new List<InputAttributeValue>
			{
				new InputAttributeValue { InputAttributeNumber = 0, Value = 1 },
				new InputAttributeValue { InputAttributeNumber = 1, Value = 0 },
				new InputAttributeValue { InputAttributeNumber = 2, Value = 0 },
			};

			double distance = abstractNetwork.GetEuclideanDistance(abstractNetwork.Neurons[0], inputVector);

            Assert.AreEqual(Math.Round(realDistance, decimals), Math.Round(distance, decimals));
        }
    }
}
