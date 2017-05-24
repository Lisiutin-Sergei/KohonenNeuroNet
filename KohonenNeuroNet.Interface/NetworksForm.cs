using KohonenNeuroNet.Core.Interface.Service;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.Interface.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KohonenNeuroNet.Interface
{
	/// <summary>
	/// Форма списка нейронных сетей.
	/// </summary>
	public partial class NetworksForm : Form
	{
		private readonly INetworkService _networkService;

		public NetworksForm(INetworkService networkService)
		{
			InitializeComponent();

			_networkService = networkService;
		}

		/// <summary>
		/// При загрузке формы.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Load(object sender, EventArgs e)
		{
			try
			{
				var networks = _networkService.LoadAllNetworks();
				RefreshNetworks(networks);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Создание новой сети.
		/// </summary>
		private void Btn_AddNetwork_Click(object sender, EventArgs e)
		{
			try
			{
                var mainForm = IoC.Instance.Resolve<MainForm>(new IoC.NinjectArgument("networkId", null));
                if (mainForm.ShowDialog() == DialogResult.OK)
				{
					var networks = _networkService.LoadAllNetworks();
					RefreshNetworks(networks);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Редактирование нейронной сети.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_EditNetwork_Click(object sender, EventArgs e)
		{
			try
			{
				if (dgvNetworks.SelectedRows.Count != 1)
				{
					MessageBox.Show("Выберите нейронную сеть для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				var networkId = (int)dgvNetworks.SelectedRows[0].Cells[0].Value;
                var mainForm = IoC.Instance.Resolve<MainForm>(new IoC.NinjectArgument("networkId", networkId));

                if (mainForm.ShowDialog() == DialogResult.OK)
                {
                    var networks = _networkService.LoadAllNetworks();
                    RefreshNetworks(networks);
                } 
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        /// <summary>
		/// Удаление нейронной сети.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_DeleteNetwork_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNetworks.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Выберите нейронную сеть для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Удалить выбранную нейронную сеть?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var networkId = (int)dgvNetworks.SelectedRows[0].Cells[0].Value;
                    _networkService.DeleteNetwork(networkId);

                    var networks = _networkService.LoadAllNetworks();
                    RefreshNetworks(networks);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновить таблицу сетей.
        /// </summary>
        /// <param name="networks">Список сетей.</param>
        private void RefreshNetworks(List<NetworkBase> networks)
		{
			dgvNetworks.Rows.Clear();
			if (!(networks?.Any() ?? false))
			{
				return;
			}

			foreach (var network in networks)
			{
				dgvNetworks.Rows.Add(network.NetworkId, network.Name);
			}
		}
	}
}
