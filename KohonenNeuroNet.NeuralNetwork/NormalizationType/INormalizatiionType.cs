using KohonenNeuroNet.NeuralNetwork.NetworkData;

namespace KohonenNeuroNet.NeuralNetwork.NormalizationType
{
	/// <summary>
	/// Интерфейс нормализации сети.
	/// </summary>
	public interface INormalizatiionType
    {
        /// <summary>
        /// Получить нормализованное значение атрибута.
        /// </summary>
        /// <param name="attribute">Атрибут сущности.</param>
        /// <returns>Нормализованное значение атрибута.</returns>
        double GetAttributeValue(NetworkEntityAttributeValue attribute);

        /// <summary>
        /// Получить нормализованное значение веса нейрона.
        /// </summary>
        /// <param name="inputsCount">Количество элементов входа.</param>
        /// <returns>Нормализованное значение веса нейрона.</returns>
        double GetNeuronWeight(int inputsCount);
    }
}
