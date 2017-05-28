using System.Data;

namespace KohonenNeuroNet.Utilities.Interface.Reader
{
    /// <summary>
    /// Интерфейс поставщиков данных.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Прочитать данные из файла.
        /// </summary>
        /// <param name="fileName">Имя файла/путь к файлу.</param>
        /// <returns>Таблица с данными.</returns>
        DataTable ReadFromFile(string fileName);
    }
}
