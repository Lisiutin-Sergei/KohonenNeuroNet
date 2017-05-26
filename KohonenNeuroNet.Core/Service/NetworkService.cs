using KohonenNeuroNet.Core.Interface.Data;
using KohonenNeuroNet.Core.Interface.Service;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.Core.Model.Business;
using System;

namespace KohonenNeuroNet.Core.Service
{
    /// <summary>
    /// Сервис работы с сетью.
    /// </summary>
    public class NetworkService : INetworkService
    {
        private IConfiguration _configuration;
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public NetworkService(IConfiguration configuration, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _configuration = configuration;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Загрузить список нейронных сетей.
        /// </summary>
        /// <returns>Список нейронных сетей.</returns>
        public List<NetworkBase> LoadAllNetworks()
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create(_configuration))
            {
                return unitOfWork.NetworkRepository.GetAll()
                    .ToList();
            }
        }

        /// <summary>
        /// Рекурсивно получить все нейронные сети для нейрона-кластера.
        /// </summary>
        /// <param name="unitOfWork">Модуль для работы с БД.</param>
        /// <param name="neuronId">Идентификатор нейрона.</param>
        /// <returns></returns>
        private NeuralNetworkData GetNetworkRecursive(IUnitOfWork unitOfWork, int neuronId)
        {
            var network = unitOfWork.NetworkRepository
                .GetAll()
                .FirstOrDefault(e => e.ParentNeuronId == neuronId);
            if (network == null)
            {
                return null;
            }

            var neurons = unitOfWork.NeuronRepository.GetAll()
                .Where(e => e.NetworkId == network.NetworkId)
                .Select(e => new NeuronData(e, null))
                .ToList();
            var inputAttributes = unitOfWork.InputAttributeRepository.GetAll()
                .Where(e => e.NetworkId == network.NetworkId)
                .ToList();
            var weights = unitOfWork.WeightRepository.GetAll()
                .Where(e => neurons.Select(n => n.Neuron.NeuronId).Contains(e.NeuronId))
                .ToList();

            foreach (var currentNeuron in neurons)
            {
                currentNeuron.Network = GetNetworkRecursive(unitOfWork, currentNeuron.Neuron.NeuronId);
            }

            return new NeuralNetworkData
            {
                Network = network,
                Neurons = neurons,
                InputAttributes = inputAttributes,
                Weights = weights
            };
        }

        /// <summary>
        /// Получить данные о нейронной сети.
        /// </summary>
        /// <returns>Данные о нейронной сети.</returns>
        public NeuralNetworkData GetNetworkData(int networkId)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create(_configuration))
            {
                var network = unitOfWork.NetworkRepository.GetByID(networkId);
                if (network == null)
                {
                    return null;
                }

                var neurons = unitOfWork.NeuronRepository.GetAll()
                    .Where(e => e.NetworkId == network.NetworkId)
                    .Select(e => new NeuronData(e, null))
                    .ToList();
                var inputAttributes = unitOfWork.InputAttributeRepository.GetAll()
                    .Where(e => e.NetworkId == network.NetworkId)
                    .ToList();
                var weights = unitOfWork.WeightRepository.GetAll()
                    .Where(e => neurons.Select(n => n.Neuron.NeuronId).Contains(e.NeuronId))
                    .ToList();

                foreach (var currentNeuron in neurons)
                {
                    currentNeuron.Network = GetNetworkRecursive(unitOfWork, currentNeuron.Neuron.NeuronId);
                }

                return new NeuralNetworkData
                {
                    Network = network,
                    Neurons = neurons,
                    InputAttributes = inputAttributes,
                    Weights = weights
                };
            }
        }

        /// <summary>
        /// Сохранить данные о сети.
        /// </summary>
        /// <param name="networkData">Данные о сети.</param>
		public void SaveNetworkData(NeuralNetworkData networkData)
        {
            var isEdit = networkData.Network.NetworkId > 0;

            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create(_configuration))
            {
                unitOfWork.BeginTransaction();

                try
                {
                    if (!isEdit)
                    {
                        // Сеть
                        networkData.Network.CreatedOn = DateTime.Now;
                        networkData.Network.NetworkId = unitOfWork.NetworkRepository.Insert(networkData.Network);

                        // Нейроны
                        foreach (var neuron in networkData.Neurons)
                        {
                            neuron.Neuron.NetworkId = networkData.Network.NetworkId;
                            neuron.Neuron.NeuronId = unitOfWork.NeuronRepository.Insert(neuron.Neuron);
                        }

                        // Входные параметры
                        foreach (var inputAttribute in networkData.InputAttributes)
                        {
                            inputAttribute.NetworkId = networkData.Network.NetworkId;
                            inputAttribute.InputAttributeId = unitOfWork.InputAttributeRepository.Insert(inputAttribute);
                        }

                        // Веса
                        foreach (var weight in networkData.Weights)
                        {
                            weight.InputAttributeId = networkData.InputAttributes
                                .First(e => e.InputAttributeNumber == weight.InputAttributeNumber)
                                .InputAttributeId;
                            weight.NeuronId = networkData.Neurons
                                .First(e => e.Neuron.NeuronNumber == weight.NeuronNumber)
                                .Neuron.NeuronId;
                            weight.WeightId = unitOfWork.WeightRepository.Insert(weight);
                        }
                    }
                    else
                    {
                        // Сеть
                        unitOfWork.NetworkRepository.Update(networkData.Network);

                        // Нейроны
                        foreach (var neuron in networkData.Neurons)
                        {
                            unitOfWork.NeuronRepository.Update(neuron.Neuron);
                        }

                        // Входные параметры
                        foreach (var inputAttribute in networkData.InputAttributes)
                        {
                            unitOfWork.InputAttributeRepository.Update(inputAttribute);
                        }

                        // Веса
                        foreach (var weight in networkData.Weights)
                        {
                            unitOfWork.WeightRepository.Update(weight);
                        }
                    }

                    unitOfWork.CommitTransaction();
                }
                catch
                {
                    unitOfWork.RollbackTransaction();
                    throw;
                }
            }
        }

        /// <summary>
        /// Рекурсивно удалить нейронные сети.
        /// </summary>
        /// <param name="unitOfWork">Модуль для работы с БД.</param>
        /// <param name="neuronId">Идентификатор нейрона.</param>
        private void DeleteNetworkRecursive(IUnitOfWork unitOfWork, int neuronId)
        {
            var network = GetNetworkRecursive(unitOfWork, neuronId);
            if (network == null)
            {
                return;
            }

            foreach (var currentNeuron in network.Neurons)
            {
                DeleteNetworkRecursive(unitOfWork, currentNeuron.Neuron.NeuronId);
            }

            network.Weights.ForEach(w => unitOfWork.WeightRepository.Delete(w));
            network.InputAttributes.ForEach(i => unitOfWork.InputAttributeRepository.Delete(i));
            network.Neurons.ForEach(n => unitOfWork.NeuronRepository.Delete(n.Neuron));
            unitOfWork.NetworkRepository.Delete(network.Network);
        }

        /// <summary>
        /// Удалить сеть.
        /// </summary>
        /// <param name="networkId">Идентификатор сети.</param>
        public void DeleteNetwork(int networkId)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create(_configuration))
            {
                var network = unitOfWork.NetworkRepository.GetByID(networkId);

                var neurons = unitOfWork.NeuronRepository.GetAll()
                    .Where(e => e.NetworkId == networkId)
                    .ToList();

                var inputAttributes = unitOfWork.InputAttributeRepository.GetAll()
                    .Where(e => e.NetworkId == networkId)
                    .ToList();

                var weights = unitOfWork.WeightRepository.GetAll()
                    .Where(e => 
                        inputAttributes.Any(ia => ia.InputAttributeId == e.InputAttributeId) ||
                        neurons.Any(n => n.NeuronId == e.NeuronId)
                    )
                    .ToList();

                unitOfWork.BeginTransaction();
                try
                {
                    foreach(var neuron in neurons)
                    {
                        DeleteNetworkRecursive(unitOfWork, neuron.NeuronId);
                    }

                    weights.ForEach(w => unitOfWork.WeightRepository.Delete(w));
                    inputAttributes.ForEach(i => unitOfWork.InputAttributeRepository.Delete(i));
                    neurons.ForEach(n => unitOfWork.NeuronRepository.Delete(n));
                    unitOfWork.NetworkRepository.Delete(network);

                    unitOfWork.CommitTransaction();
                }
                catch
                {
                    unitOfWork.RollbackTransaction();
                    throw;
                }
            }
        }
    }
}
