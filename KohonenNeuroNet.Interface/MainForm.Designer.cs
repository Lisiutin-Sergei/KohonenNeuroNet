namespace KohonenNeuroNet.Interface
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabPanelMain = new System.Windows.Forms.TabControl();
			this.tabLearning = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgvInputLearningData = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbIterationsCount = new System.Windows.Forms.NumericUpDown();
			this.tbClastersCount = new System.Windows.Forms.NumericUpDown();
			this.btnLearnNetwork = new System.Windows.Forms.Button();
			this.tbLearningFile = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnChooseLearningFile = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tabNetwork = new System.Windows.Forms.TabPage();
			this.dgvWeights = new System.Windows.Forms.DataGridView();
			this.tabTesting = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.dgvTesingData = new System.Windows.Forms.DataGridView();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbTestingFile = new System.Windows.Forms.TextBox();
			this.BtnTest = new System.Windows.Forms.Button();
			this.btnChooseTestingFile = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabClasters = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.dgvClasterEntities = new System.Windows.Forms.DataGridView();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.dgvClasters = new System.Windows.Forms.DataGridView();
			this.btnSaveNetwork = new System.Windows.Forms.Button();
			this.tabPanelMain.SuspendLayout();
			this.tabLearning.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvInputLearningData)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbIterationsCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbClastersCount)).BeginInit();
			this.tabNetwork.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvWeights)).BeginInit();
			this.tabTesting.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTesingData)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.tabClasters.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvClasterEntities)).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvClasters)).BeginInit();
			this.SuspendLayout();
			// 
			// tabPanelMain
			// 
			this.tabPanelMain.Controls.Add(this.tabLearning);
			this.tabPanelMain.Controls.Add(this.tabNetwork);
			this.tabPanelMain.Controls.Add(this.tabTesting);
			this.tabPanelMain.Controls.Add(this.tabClasters);
			this.tabPanelMain.Location = new System.Drawing.Point(12, 12);
			this.tabPanelMain.Name = "tabPanelMain";
			this.tabPanelMain.SelectedIndex = 0;
			this.tabPanelMain.Size = new System.Drawing.Size(818, 481);
			this.tabPanelMain.TabIndex = 0;
			// 
			// tabLearning
			// 
			this.tabLearning.Controls.Add(this.groupBox2);
			this.tabLearning.Controls.Add(this.groupBox1);
			this.tabLearning.Location = new System.Drawing.Point(4, 22);
			this.tabLearning.Name = "tabLearning";
			this.tabLearning.Padding = new System.Windows.Forms.Padding(3);
			this.tabLearning.Size = new System.Drawing.Size(810, 455);
			this.tabLearning.TabIndex = 0;
			this.tabLearning.Text = "Обучение";
			this.tabLearning.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgvInputLearningData);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 100);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(804, 352);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Выборка для обучения";
			// 
			// dgvInputLearningData
			// 
			this.dgvInputLearningData.AllowUserToAddRows = false;
			this.dgvInputLearningData.AllowUserToDeleteRows = false;
			this.dgvInputLearningData.AllowUserToResizeRows = false;
			this.dgvInputLearningData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInputLearningData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvInputLearningData.Location = new System.Drawing.Point(3, 16);
			this.dgvInputLearningData.Name = "dgvInputLearningData";
			this.dgvInputLearningData.ReadOnly = true;
			this.dgvInputLearningData.RowHeadersVisible = false;
			this.dgvInputLearningData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvInputLearningData.Size = new System.Drawing.Size(798, 333);
			this.dgvInputLearningData.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbIterationsCount);
			this.groupBox1.Controls.Add(this.tbClastersCount);
			this.groupBox1.Controls.Add(this.btnLearnNetwork);
			this.groupBox1.Controls.Add(this.tbLearningFile);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btnChooseLearningFile);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(804, 97);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Параметры обучения";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Выборка для обучения";
			// 
			// tbIterationsCount
			// 
			this.tbIterationsCount.Location = new System.Drawing.Point(138, 70);
			this.tbIterationsCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.tbIterationsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbIterationsCount.Name = "tbIterationsCount";
			this.tbIterationsCount.Size = new System.Drawing.Size(61, 20);
			this.tbIterationsCount.TabIndex = 5;
			this.tbIterationsCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// tbClastersCount
			// 
			this.tbClastersCount.Location = new System.Drawing.Point(138, 44);
			this.tbClastersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbClastersCount.Name = "tbClastersCount";
			this.tbClastersCount.Size = new System.Drawing.Size(61, 20);
			this.tbClastersCount.TabIndex = 5;
			this.tbClastersCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// btnLearnNetwork
			// 
			this.btnLearnNetwork.Location = new System.Drawing.Point(705, 67);
			this.btnLearnNetwork.Name = "btnLearnNetwork";
			this.btnLearnNetwork.Size = new System.Drawing.Size(93, 23);
			this.btnLearnNetwork.TabIndex = 3;
			this.btnLearnNetwork.Text = "Обучить сеть";
			this.btnLearnNetwork.UseVisualStyleBackColor = true;
			this.btnLearnNetwork.Click += new System.EventHandler(this.Btn_LearnNetwork_Click);
			// 
			// tbLearningFile
			// 
			this.tbLearningFile.Location = new System.Drawing.Point(138, 18);
			this.tbLearningFile.Name = "tbLearningFile";
			this.tbLearningFile.ReadOnly = true;
			this.tbLearningFile.Size = new System.Drawing.Size(561, 20);
			this.tbLearningFile.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Количество итераций";
			// 
			// btnChooseLearningFile
			// 
			this.btnChooseLearningFile.Location = new System.Drawing.Point(705, 16);
			this.btnChooseLearningFile.Name = "btnChooseLearningFile";
			this.btnChooseLearningFile.Size = new System.Drawing.Size(93, 23);
			this.btnChooseLearningFile.TabIndex = 1;
			this.btnChooseLearningFile.Text = "Выбрать файл";
			this.btnChooseLearningFile.UseVisualStyleBackColor = true;
			this.btnChooseLearningFile.Click += new System.EventHandler(this.Btn_ChooseLearningFile_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Количество кластеров";
			// 
			// tabNetwork
			// 
			this.tabNetwork.Controls.Add(this.dgvWeights);
			this.tabNetwork.Location = new System.Drawing.Point(4, 22);
			this.tabNetwork.Name = "tabNetwork";
			this.tabNetwork.Padding = new System.Windows.Forms.Padding(3);
			this.tabNetwork.Size = new System.Drawing.Size(810, 455);
			this.tabNetwork.TabIndex = 3;
			this.tabNetwork.Text = "Сеть";
			this.tabNetwork.UseVisualStyleBackColor = true;
			// 
			// dgvWeights
			// 
			this.dgvWeights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvWeights.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvWeights.Location = new System.Drawing.Point(3, 3);
			this.dgvWeights.Name = "dgvWeights";
			this.dgvWeights.Size = new System.Drawing.Size(804, 449);
			this.dgvWeights.TabIndex = 0;
			// 
			// tabTesting
			// 
			this.tabTesting.Controls.Add(this.groupBox4);
			this.tabTesting.Controls.Add(this.groupBox3);
			this.tabTesting.Controls.Add(this.button1);
			this.tabTesting.Location = new System.Drawing.Point(4, 22);
			this.tabTesting.Name = "tabTesting";
			this.tabTesting.Padding = new System.Windows.Forms.Padding(3);
			this.tabTesting.Size = new System.Drawing.Size(810, 455);
			this.tabTesting.TabIndex = 1;
			this.tabTesting.Text = "Тестирование";
			this.tabTesting.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.dgvTesingData);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new System.Drawing.Point(3, 79);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(804, 373);
			this.groupBox4.TabIndex = 9;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Выборка для кластеризации";
			// 
			// dgvTesingData
			// 
			this.dgvTesingData.AllowUserToAddRows = false;
			this.dgvTesingData.AllowUserToDeleteRows = false;
			this.dgvTesingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTesingData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTesingData.Location = new System.Drawing.Point(3, 16);
			this.dgvTesingData.Name = "dgvTesingData";
			this.dgvTesingData.ReadOnly = true;
			this.dgvTesingData.RowHeadersVisible = false;
			this.dgvTesingData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTesingData.Size = new System.Drawing.Size(798, 354);
			this.dgvTesingData.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.tbTestingFile);
			this.groupBox3.Controls.Add(this.BtnTest);
			this.groupBox3.Controls.Add(this.btnChooseTestingFile);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(3, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(804, 76);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Параметры кластеризации";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(153, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Выборка для кластеризации";
			// 
			// tbTestingFile
			// 
			this.tbTestingFile.Location = new System.Drawing.Point(165, 18);
			this.tbTestingFile.Name = "tbTestingFile";
			this.tbTestingFile.ReadOnly = true;
			this.tbTestingFile.Size = new System.Drawing.Size(525, 20);
			this.tbTestingFile.TabIndex = 6;
			// 
			// BtnTest
			// 
			this.BtnTest.Location = new System.Drawing.Point(696, 45);
			this.BtnTest.Name = "BtnTest";
			this.BtnTest.Size = new System.Drawing.Size(102, 23);
			this.BtnTest.TabIndex = 7;
			this.BtnTest.Text = "Кластеризовать";
			this.BtnTest.UseVisualStyleBackColor = true;
			this.BtnTest.Click += new System.EventHandler(this.Btn_Test_Click);
			// 
			// btnChooseTestingFile
			// 
			this.btnChooseTestingFile.Location = new System.Drawing.Point(696, 16);
			this.btnChooseTestingFile.Name = "btnChooseTestingFile";
			this.btnChooseTestingFile.Size = new System.Drawing.Size(102, 23);
			this.btnChooseTestingFile.TabIndex = 5;
			this.btnChooseTestingFile.Text = "Выбрать файл";
			this.btnChooseTestingFile.UseVisualStyleBackColor = true;
			this.btnChooseTestingFile.Click += new System.EventHandler(this.Btn_ChooseTestingFile_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(402, 454);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// tabClasters
			// 
			this.tabClasters.Controls.Add(this.groupBox6);
			this.tabClasters.Controls.Add(this.groupBox5);
			this.tabClasters.Location = new System.Drawing.Point(4, 22);
			this.tabClasters.Name = "tabClasters";
			this.tabClasters.Padding = new System.Windows.Forms.Padding(3);
			this.tabClasters.Size = new System.Drawing.Size(810, 455);
			this.tabClasters.TabIndex = 2;
			this.tabClasters.Text = "Кластеры";
			this.tabClasters.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.dgvClasterEntities);
			this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox6.Location = new System.Drawing.Point(3, 146);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(804, 306);
			this.groupBox6.TabIndex = 12;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Элементы кластера";
			// 
			// dgvClasterEntities
			// 
			this.dgvClasterEntities.AllowUserToAddRows = false;
			this.dgvClasterEntities.AllowUserToDeleteRows = false;
			this.dgvClasterEntities.AllowUserToResizeRows = false;
			this.dgvClasterEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvClasterEntities.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvClasterEntities.Location = new System.Drawing.Point(3, 16);
			this.dgvClasterEntities.Name = "dgvClasterEntities";
			this.dgvClasterEntities.ReadOnly = true;
			this.dgvClasterEntities.RowHeadersVisible = false;
			this.dgvClasterEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvClasterEntities.Size = new System.Drawing.Size(798, 287);
			this.dgvClasterEntities.TabIndex = 10;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.dgvClasters);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(3, 3);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(804, 143);
			this.groupBox5.TabIndex = 11;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Кластеры";
			// 
			// dgvClasters
			// 
			this.dgvClasters.AllowUserToAddRows = false;
			this.dgvClasters.AllowUserToDeleteRows = false;
			this.dgvClasters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvClasters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvClasters.Location = new System.Drawing.Point(3, 16);
			this.dgvClasters.Name = "dgvClasters";
			this.dgvClasters.ReadOnly = true;
			this.dgvClasters.RowHeadersVisible = false;
			this.dgvClasters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvClasters.Size = new System.Drawing.Size(798, 124);
			this.dgvClasters.TabIndex = 9;
			this.dgvClasters.SelectionChanged += new System.EventHandler(this.Dgv_Clasters_SelectionChanged);
			// 
			// btnSaveNetwork
			// 
			this.btnSaveNetwork.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNetwork.Image")));
			this.btnSaveNetwork.Location = new System.Drawing.Point(836, 34);
			this.btnSaveNetwork.Name = "btnSaveNetwork";
			this.btnSaveNetwork.Size = new System.Drawing.Size(50, 50);
			this.btnSaveNetwork.TabIndex = 1;
			this.btnSaveNetwork.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(899, 505);
			this.Controls.Add(this.btnSaveNetwork);
			this.Controls.Add(this.tabPanelMain);
			this.MaximumSize = new System.Drawing.Size(915, 544);
			this.MinimumSize = new System.Drawing.Size(915, 544);
			this.Name = "MainForm";
			this.Text = "Сеть Кохонена";
			this.tabPanelMain.ResumeLayout(false);
			this.tabLearning.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvInputLearningData)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbIterationsCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbClastersCount)).EndInit();
			this.tabNetwork.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvWeights)).EndInit();
			this.tabTesting.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvTesingData)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabClasters.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvClasterEntities)).EndInit();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvClasters)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPanelMain;
        private System.Windows.Forms.TabPage tabLearning;
        private System.Windows.Forms.Button btnChooseLearningFile;
        private System.Windows.Forms.DataGridView dgvInputLearningData;
        private System.Windows.Forms.TabPage tabTesting;
        private System.Windows.Forms.TextBox tbLearningFile;
        private System.Windows.Forms.Button btnLearnNetwork;
        private System.Windows.Forms.DataGridView dgvTesingData;
        private System.Windows.Forms.Button BtnTest;
        private System.Windows.Forms.TextBox tbTestingFile;
        private System.Windows.Forms.Button btnChooseTestingFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown tbClastersCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabClasters;
        private System.Windows.Forms.DataGridView dgvClasters;
        private System.Windows.Forms.DataGridView dgvClasterEntities;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown tbIterationsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TabPage tabNetwork;
        private System.Windows.Forms.DataGridView dgvWeights;
		private System.Windows.Forms.Button btnSaveNetwork;
	}
}

