using System;
using System.IO;

namespace KohonenNeuroNet.Utilities
{
    public static class CommonUtils
    {
        /// <summary>
        /// Название папки с ресурсами.
        /// </summary>
        public static readonly string ResourcesFolderName = "KohonenNeuroNet.Resources";

        /// <summary>
        /// Абсолютный путь к папке с ресурсами.
        /// </summary>
        public static readonly string ResourcesDirectory = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, ResourcesFolderName);
    }
}
