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
        /// Получить данные о нейронной сети.
        /// </summary>
        /// <returns>Данные о нейронной сети.</returns>
        public NeuralNetworkData GetNetworkData(int networkId)
        {
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create(_configuration))
            {
                var netwotk = unitOfWork.NetworkRepository.GetByID(networkId);
                var neurons = unitOfWork.NeuronRepository.GetAll()
                    .Where(e => e.NetworkId == networkId)
                    .ToList();
                var inputAttributes = unitOfWork.InputAttributeRepository.GetAll()
                    .Where(e => e.NetworkId == networkId)
                    .ToList();
                var weights = unitOfWork.WeightRepository.GetAll()
                    .Where(e => neurons.Select(n => n.NeuronId).Contains(e.NeuronId))
                    .ToList();

                return new NeuralNetworkData
                {
                    Network = netwotk,
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
                            neuron.NetworkId = networkData.Network.NetworkId;
                            neuron.NeuronId = unitOfWork.NeuronRepository.Insert(neuron);
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
                                .First(e => e.NeuronNumber == weight.NeuronNumber)
                                .NeuronId;
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
                            unitOfWork.NeuronRepository.Update(neuron);
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
