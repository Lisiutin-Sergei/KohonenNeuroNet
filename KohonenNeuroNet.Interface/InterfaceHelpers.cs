using KohonenNeuroNet.Core.NetworkData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KohonenNeuroNet.Interface
{
    /// <summary>
    /// Посредник для работы с данными в интерфейсе.
    /// </summary>
    public class InterfaceMediator
    {
        /// <summary>
        /// Отобразить данные сети в DataGridView.
        /// </summary>
        /// <param name="entities">Набор сущностей.</param>
        /// <param name="attributes">Атрибуты набора сущностей.</param>
        /// <param name="grid">DataGridView.</param>
        public void DrawDataIntoGrid(List<NetworkDataEntity> entities, List<NetworkAttribute> attributes, DataGridView grid)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            if (entities == null || attributes == null)
            {
                return;
            }
            
            grid.Columns.Add("№", "№");
            foreach (var attribute in attributes)
            {
                grid.Columns.Add(attribute.Name, attribute.Name);
            }
            foreach(var entity in entities)
            {
                var entityAttributeValues = new List<object> { entity.OrderNumber };
                entityAttributeValues.AddRange(entity.AttributeValues.Select(a => (object)a.Value));
                grid.Rows.Add(entityAttributeValues.ToArray());
            }
        }
        public void DrawDataIntoGrid(NetworkDataSet dataSet, DataGridView grid)
        {
            if (dataSet == null)
            {
                DrawDataIntoGrid(null, null, grid);
            }
            DrawDataIntoGrid(dataSet.Entities, dataSet.Attributes, grid);
        }
        
        /// <summary>
        /// Отобразить кластеры в DataGridView.
        /// </summary>
        /// <param name="clasters">Кластеры.</param>
        /// <param name="grid">DataGridView.</param>
        public void DrawClasters(List<NetworkClaster> clasters, DataGridView grid)
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            if (clasters == null)
            {
                return;
            }
            
            grid.Columns.Add("ClasterNumber", "Номер кластера");
            grid.Columns.Add("EntitiesCount", "Количество элементов");
            foreach (var claster in clasters)
            {
                grid.Rows.Add((object)claster.Number, (object)claster.Entities.Count);
            }
        }
        
    }
}
