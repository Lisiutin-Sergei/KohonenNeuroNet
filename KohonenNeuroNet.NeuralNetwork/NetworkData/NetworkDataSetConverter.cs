using KohonenNeuroNet.Utilities.ExtensionMethods;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace KohonenNeuroNet.NeuralNetwork.NetworkData
{
	/// <summary>
	/// Конвертер, преобразовывающий даннные в формат, с которым работает нейронная сеть.
	/// </summary>
	public class NetworkDataSetConverter
    {
        /// <summary>
        /// Преобразовать данные в формат нейронной сети из DataTable.
        /// </summary>
        /// <param name="data">DataTable с данными.</param>
        /// <returns>Данные в формате нейронной сети.</returns>
        public NetworkDataSet Convert(DataTable data)
        {
            var networkDataSet = new NetworkDataSet();
            if (data == null)
            {
                return networkDataSet;
            }

            // Список атрибутов.
            var attributes = GetAttributes(data);

            // Список элементов
            var entities = GetEntities(data, attributes);

            return new NetworkDataSet
            {
                Attributes = attributes,
                Entities = entities
            };
        }

        /// <summary>
        /// Получить список атрибутов (колонок) набора данных.
        /// </summary>
        /// <param name="data">Набор данных.</param>
        /// <returns>Список атрибутов набора данных.</returns>
        public List<NetworkAttribute> GetAttributes(DataTable data)
        {
            var attributes = new List<NetworkAttribute>();
            if (data == null)
            {
                return attributes;
            }

            // Пропускаем 1 колонку - название элемента
            int columnWithEntityName = 0;
            int firstAttributeColumnIndex = columnWithEntityName + 1;
            for (int i = firstAttributeColumnIndex; i < data.Columns.Count; i++)
            {
                var column = data.Columns[i];
                var attribute = new NetworkAttribute
                {
                    OrderNumber = i - firstAttributeColumnIndex,
                    Name = data.Rows[0][i]?.ToString() ?? string.Empty,
                    Min = data.Min<double>(column, firstAttributeColumnIndex),
                    Max = data.Max<double>(column, firstAttributeColumnIndex)
                };
                attributes.Add(attribute);
            }

            return attributes;
        }

        /// <summary>
        /// Получить список элементов набора данных.
        /// </summary>
        /// <param name="data">Набор данных.</param>
        /// <param name="attributes">Список атрибутов набора данных.</param>
        /// <returns>Список элементов набора данных.</returns>
        public List<NetworkDataEntity> GetEntities(DataTable data, List<NetworkAttribute> attributes)
        {
            var entities = new List<NetworkDataEntity>();
            if (data == null || data.Rows.Count == 0 || data.Columns.Count == 0)
            {
                return entities;
            }
            
            // Пропускаем 1 строку - заголовок таблицы 
            int rowsToSkip = 1;
            int columnWithEntityName = 0;
            int firstAttributeColumnIndex = columnWithEntityName + 1;
            double temp;
            for (int r = rowsToSkip; r < data.Rows.Count; r++)
            {
                var row = data.Rows[r];
                if (string.IsNullOrWhiteSpace(row[0]?.ToString()))
                {
                    break;
                }

                var entity = new NetworkDataEntity
                {
                    OrderNumber = r - rowsToSkip,
                    Name = row[columnWithEntityName]?.ToString() ?? string.Empty
                };

                // Пропускаем 1 колонку - название элемента
                for (int c = firstAttributeColumnIndex; c < data.Columns.Count; c++)
                {
                    var cell = data.Rows[r][c];
                    var isSuccessfullParse = double.TryParse(cell?.ToString(), out temp);
                    var attributeValue = new NetworkEntityAttributeValue
                    {
                        Attribute = attributes.Single(a => a.OrderNumber == c - firstAttributeColumnIndex),
                        Value = isSuccessfullParse ? temp : 0
                    };
                    entity.AttributeValues.Add(attributeValue);
                }

                entities.Add(entity);
            }

            return entities;
        }
    }
}
