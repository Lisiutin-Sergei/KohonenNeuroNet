using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
