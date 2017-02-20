namespace KohonenNeuroNet.Core.Types
{
    /// <summary>
    /// Типы нормализации.
    /// </summary>
    public enum NormalizationTypes
    {
        /// <summary>
        /// Линейная нормализация, от 0 до 1.
        /// </summary>
        Linear_0_1 = 1,

        /// <summary>
        /// Линейная нормализация, от -1 до 1.
        /// </summary>
        Linear__1_1 = 2,

        /// <summary>
        /// Нормализация с использованием сигмоидной логистической функции, от 0 до 1.
        /// </summary>
        Sygmoid_0_1 = 3,

        /// <summary>
        /// Нормализация с использованием сигмоидной логистической функции, от -1 до 1.
        /// </summary>
        Sygmoid__1_1 = 4
    }
}
