using KohonenNeuroNet.Core.Model.Domain;

namespace KohonenNeuroNet.Core.Model.Business
{
    /// <summary>
    /// Модель представления нейрона.
    /// </summary>
    public class NeuronData
    {
        /// <summary>
        /// Нейрон.
        /// </summary>
        public NeuronBase Neuron { get; set; }

        /// <summary>
        /// Дочерняя нейронная сеть.
        /// </summary>
        public NeuralNetworkData Network { get; set; }

        public NeuronData(NeuronBase neuron, NeuralNetworkData network = null)
        {
            Neuron = neuron;
            Network = network;
        }
    }
}
