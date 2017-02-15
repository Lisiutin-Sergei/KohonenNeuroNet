using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohonenNeuroNet.Core.NeuralNetwork
{
    /// <summary>
    /// Нейрон сети.
    /// </summary>
    public class Neuron
    {
        public int number { get; set; }
        public List<double> weights { get; set; }

        public Neuron(int number_, int inputs_)
        {
            weights = new List<double>();
            number = number_;
            Random rand = new Random();
            for (int i = 0; i < inputs_; i++)
            {
                weights.Add(rand.NextDouble());
            }
        }
    }
}
