using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace KohonenNeuroNet.Utilities.ExtensionMethods
{
    /// <summary>
    /// Класс методов расширения для DataTable.
    /// </summary>
    public static class DataTableExtension
    {
        /// <summary>
        /// Конвертировать объект в структуру.
        /// </summary>
        /// <typeparam name="T">Тип стркутуры, в которую надо конвертировать объект.</typeparam>
        /// <param name="o">Объект.</param>
        /// <returns>Сконвертированный объект или значение по умолчанию.</returns>
        private static T Convert<T>(object o)
            where T : struct
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null && o != null)
                {
                    return (T)converter.ConvertFromString(o?.ToString());
                }
                return default(T);
            }
            catch (Exception e)
            {
                throw new Exception($"Невозможно привести {o} к типу {typeof(T).ToString()}", e);
            }
        }

        /// <summary>
        /// Получить максимальное значение колонки таблицы.
        /// </summary>
        /// <typeparam name="T">Тип данных колонки.</typeparam>
        /// <param name="table">Таблица с данными.</param>
        /// <param name="column">Колонка таблицы, по которой ищется максимум.</param>
        /// <param name="rowsToSkip">Количество строк, которые пропускаем.</param>
        /// <returns>Максимальное значение колонки таблицы.</returns>
        public static T Max<T>(this DataTable table, DataColumn column, int rowsToSkip = 1)
            where T: struct
        {
            return table
                .AsEnumerable()
                .Skip(rowsToSkip)
                .Max(row => Convert<T>(row[column]));
        }

        /// <summary>
        /// Получить минимальное значение колонки таблицы.
        /// </summary>
        /// <typeparam name="T">Тип данных колонки.</typeparam>
        /// <param name="table">Таблица с данными.</param>
        /// <param name="column">Колонка таблицы, по которой ищется максимум.</param>
        /// <param name="rowsToSkip">Количество строк, которые пропускаем.</param>
        /// <returns>Минимальное значение колонки таблицы.</returns>
        public static T Min<T>(this DataTable table, DataColumn column, int rowsToSkip = 1)
            where T : struct
        {
            return table
                .AsEnumerable()
                .Skip(rowsToSkip)
                .Min(row => Convert<T>(row[column]));
        }
    }
}
