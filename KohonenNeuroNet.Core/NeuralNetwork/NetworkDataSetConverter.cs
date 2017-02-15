﻿using KohonenNeuroNet.Utilities.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohonenNeuroNet.Core.NeuralNetwork
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
            var entities = GetEntities(data);

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
                    Min = data.Min<decimal>(column),
                    Max = data.Max<decimal>(column)
                };
                attributes.Add(attribute);
            }

            return attributes;
        }

        /// <summary>
        /// Получить список элементов набора данных.
        /// </summary>
        /// <param name="data">Набор данных.</param>
        /// <returns>Список элементов набора данных.</returns>
        public List<NetworkDataEntity> GetEntities(DataTable data)
        {
            var entities = new List<NetworkDataEntity>();
            if (data == null || data.Rows.Count == 0 || data.Columns.Count == 0)
            {
                return entities;
            }

            // Список атрибутов.
            var attributes = GetAttributes(data);

            // Пропускаем 1 строку - заголовок таблицы 
            int rowsToSkip = 1;
            int columnWithEntityName = 0;
            int firstAttributeColumnIndex = columnWithEntityName + 1;
            decimal temp;
            for (int r = rowsToSkip; r < data.Rows.Count; r++)
            {
                var row = data.Rows[r];
                var entity = new NetworkDataEntity
                {
                    OrderNumber = r - rowsToSkip,
                    Name = row[columnWithEntityName]?.ToString() ?? string.Empty
                };

                // Пропускаем 1 колонку - название элемента
                for (int c = firstAttributeColumnIndex; c < data.Columns.Count; c++)
                {
                    var cell = data.Rows[r][c];
                    var isSuccessfullParse = decimal.TryParse(cell?.ToString(), out temp);
                    var attributeValue = new NetworkEntityAttributeValue
                    {
                        Attribute = attributes.Single(a => a.OrderNumber == c - firstAttributeColumnIndex),
                        Value = isSuccessfullParse ? temp : 0M
                    };
                    entity.AttributeValues.Add(attributeValue);
                }

                entities.Add(entity);
            }

            return entities;
        }
    }
}
