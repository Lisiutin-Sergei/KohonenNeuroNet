using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Linq;
using KohonenNeuroNet.Utilities.ExtensionMethods;

namespace KohonenNeuroNet.Tests
{
    /// <summary>
    /// Тесты для методов расширения DataTable.
    /// </summary>
    [TestClass]
    public class DataTableExtensionMethodsTest
    {
        /// <summary>
        /// Должен возвращать минимальное значение.
        /// </summary>
        [TestMethod]
        public void ShouldReturnMinColumnValue()
        {
            var random = new Random();
            var nullableRows = new int[] { 20, 50, 80 };

            using (var dataTable = new DataTable())
            {
                using (var column = new DataColumn())
                {
                    dataTable.Columns.Add(column);

                    // Заполним табличку
                    double min = 100;
                    double max = -100;
                    for (int i = 0; i <= 100; i++)
                    {
                        var row = dataTable.NewRow();
                        if (nullableRows.Contains(i))
                        {
                            row[0] = null;
                        }
                        else
                        { 
                            // от -100 до 100
                            var randomDecimal = (random.NextDouble() - 0.5) * 200;
                            row[0] = randomDecimal;
                            if (randomDecimal < min)
                            {
                                min = randomDecimal;
                            }
                            if (randomDecimal > max)
                            {
                                max = randomDecimal;
                            }
                        }
                        dataTable.Rows.Add(row);
                    }

                    double epsilon = 1E-10;
                    Assert.IsTrue(Math.Abs(min - dataTable.Min<double>(column)) <= epsilon);
                    Assert.IsTrue(Math.Abs(max - dataTable.Max<double>(column)) <= epsilon);
                }
            }
        }
    }
}
