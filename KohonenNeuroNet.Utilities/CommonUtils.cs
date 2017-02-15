using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohonenNeuroNet.Utilities
{
    public static class CommonUtils
    {
        /// <summary>
        /// Название папки с ресурсами.
        /// </summary>
        public static readonly string ResourcesFolder = "KohonenNeuroNet.Resources";

        /// <summary>
        /// Абсолютный путь к папке с ресурсами.
        /// </summary>
        public static readonly string ResourcesDirectory = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, ResourcesFolder);
    }
}
