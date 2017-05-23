using KohonenNeuroNet.Interface.DI;
using Ninject;
using System;
using System.Windows.Forms;

namespace KohonenNeuroNet.Interface
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
		{
			var kernel = new StandardKernel();
			IoC.Instance.Initialize(kernel);
			
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(IoC.Instance.Resolve<NetworksForm>());
        }
    }
}
