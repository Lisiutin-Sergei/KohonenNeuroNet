namespace KohonenNeuroNet.Core.NetworkData
{
    /// <summary>
    /// Атрибут сущности (колонка).
    /// </summary>
    public class NetworkAttribute
    {
        /// <summary>
        /// Максимальное значение атрибута.
        /// </summary>
        public double Max { get; set; }

        /// <summary>
        /// Минимальное значение атрибута.
        /// </summary>
        public double Min { get; set; }

        /// <summary>
        /// Название атрибута.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Порядковый номер атрибута.
        /// </summary>
        public int OrderNumber { get; set; }
    }
}
