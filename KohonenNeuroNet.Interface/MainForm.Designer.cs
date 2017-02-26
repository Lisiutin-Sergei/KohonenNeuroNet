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
            this.tabPanelMain = new System.Windows.Forms.TabControl();
            this.tabLearning = new System.Windows.Forms.TabPage();
            this.tbClastersCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLearnNetwork = new System.Windows.Forms.Button();
            this.tbLearningFile = new System.Windows.Forms.TextBox();
            this.btnChooseLearningFile = new System.Windows.Forms.Button();
            this.dgvInputLearningData = new System.Windows.Forms.DataGridView();
            this.tabTesting = new System.Windows.Forms.TabPage();
            this.BtnTest = new System.Windows.Forms.Button();
            this.tbTestingFile = new System.Windows.Forms.TextBox();
            this.btnChooseTestingFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvTesingData = new System.Windows.Forms.DataGridView();
            this.tabClasters = new System.Windows.Forms.TabPage();
            this.dgvClasterEntities = new System.Windows.Forms.DataGridView();
            this.dgvClasters = new System.Windows.Forms.DataGridView();
            this.tabPanelMain.SuspendLayout();
            this.tabLearning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbClastersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputLearningData)).BeginInit();
            this.tabTesting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTesingData)).BeginInit();
            this.tabClasters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasterEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasters)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPanelMain
            // 
            this.tabPanelMain.Controls.Add(this.tabLearning);
            this.tabPanelMain.Controls.Add(this.tabTesting);
            this.tabPanelMain.Controls.Add(this.tabClasters);
            this.tabPanelMain.Location = new System.Drawing.Point(12, 12);
            this.tabPanelMain.Name = "tabPanelMain";
            this.tabPanelMain.SelectedIndex = 0;
            this.tabPanelMain.Size = new System.Drawing.Size(875, 481);
            this.tabPanelMain.TabIndex = 0;
            // 
            // tabLearning
            // 
            this.tabLearning.Controls.Add(this.tbClastersCount);
            this.tabLearning.Controls.Add(this.label1);
            this.tabLearning.Controls.Add(this.btnLearnNetwork);
            this.tabLearning.Controls.Add(this.tbLearningFile);
            this.tabLearning.Controls.Add(this.btnChooseLearningFile);
            this.tabLearning.Controls.Add(this.dgvInputLearningData);
            this.tabLearning.Location = new System.Drawing.Point(4, 22);
            this.tabLearning.Name = "tabLearning";
            this.tabLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabLearning.Size = new System.Drawing.Size(867, 455);
            this.tabLearning.TabIndex = 0;
            this.tabLearning.Text = "Обучение";
            this.tabLearning.UseVisualStyleBackColor = true;
            // 
            // tbClastersCount
            // 
            this.tbClastersCount.Location = new System.Drawing.Point(134, 428);
            this.tbClastersCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbClastersCount.Name = "tbClastersCount";
            this.tbClastersCount.Size = new System.Drawing.Size(45, 20);
            this.tbClastersCount.TabIndex = 5;
            this.tbClastersCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество кластеров";
            // 
            // btnLearnNetwork
            // 
            this.btnLearnNetwork.Location = new System.Drawing.Point(777, 425);
            this.btnLearnNetwork.Name = "btnLearnNetwork";
            this.btnLearnNetwork.Size = new System.Drawing.Size(87, 23);
            this.btnLearnNetwork.TabIndex = 3;
            this.btnLearnNetwork.Text = "Обучить сеть";
            this.btnLearnNetwork.UseVisualStyleBackColor = true;
            this.btnLearnNetwork.Click += new System.EventHandler(this.Btn_LearnNetwork_Click);
            // 
            // tbLearningFile
            // 
            this.tbLearningFile.Location = new System.Drawing.Point(185, 428);
            this.tbLearningFile.Name = "tbLearningFile";
            this.tbLearningFile.Size = new System.Drawing.Size(487, 20);
            this.tbLearningFile.TabIndex = 2;
            // 
            // btnChooseLearningFile
            // 
            this.btnChooseLearningFile.Location = new System.Drawing.Point(678, 425);
            this.btnChooseLearningFile.Name = "btnChooseLearningFile";
            this.btnChooseLearningFile.Size = new System.Drawing.Size(93, 23);
            this.btnChooseLearningFile.TabIndex = 1;
            this.btnChooseLearningFile.Text = "Выбрать файл";
            this.btnChooseLearningFile.UseVisualStyleBackColor = true;
            this.btnChooseLearningFile.Click += new System.EventHandler(this.Btn_ChooseLearningFile_Click);
            // 
            // dgvInputLearningData
            // 
            this.dgvInputLearningData.AllowUserToAddRows = false;
            this.dgvInputLearningData.AllowUserToDeleteRows = false;
            this.dgvInputLearningData.AllowUserToResizeRows = false;
            this.dgvInputLearningData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputLearningData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvInputLearningData.Location = new System.Drawing.Point(3, 3);
            this.dgvInputLearningData.Name = "dgvInputLearningData";
            this.dgvInputLearningData.ReadOnly = true;
            this.dgvInputLearningData.RowHeadersVisible = false;
            this.dgvInputLearningData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInputLearningData.Size = new System.Drawing.Size(861, 417);
            this.dgvInputLearningData.TabIndex = 0;
            // 
            // tabTesting
            // 
            this.tabTesting.Controls.Add(this.BtnTest);
            this.tabTesting.Controls.Add(this.tbTestingFile);
            this.tabTesting.Controls.Add(this.btnChooseTestingFile);
            this.tabTesting.Controls.Add(this.button1);
            this.tabTesting.Controls.Add(this.dgvTesingData);
            this.tabTesting.Location = new System.Drawing.Point(4, 22);
            this.tabTesting.Name = "tabTesting";
            this.tabTesting.Padding = new System.Windows.Forms.Padding(3);
            this.tabTesting.Size = new System.Drawing.Size(867, 455);
            this.tabTesting.TabIndex = 1;
            this.tabTesting.Text = "Тестирование";
            this.tabTesting.UseVisualStyleBackColor = true;
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(774, 426);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(87, 23);
            this.BtnTest.TabIndex = 7;
            this.BtnTest.Text = "Тестировать";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.Btn_Test_Click);
            // 
            // tbTestingFile
            // 
            this.tbTestingFile.Location = new System.Drawing.Point(6, 428);
            this.tbTestingFile.Name = "tbTestingFile";
            this.tbTestingFile.Size = new System.Drawing.Size(663, 20);
            this.tbTestingFile.TabIndex = 6;
            // 
            // btnChooseTestingFile
            // 
            this.btnChooseTestingFile.Location = new System.Drawing.Point(675, 427);
            this.btnChooseTestingFile.Name = "btnChooseTestingFile";
            this.btnChooseTestingFile.Size = new System.Drawing.Size(93, 23);
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
            // dgvTesingData
            // 
            this.dgvTesingData.AllowUserToAddRows = false;
            this.dgvTesingData.AllowUserToDeleteRows = false;
            this.dgvTesingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTesingData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTesingData.Location = new System.Drawing.Point(3, 3);
            this.dgvTesingData.Name = "dgvTesingData";
            this.dgvTesingData.ReadOnly = true;
            this.dgvTesingData.RowHeadersVisible = false;
            this.dgvTesingData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTesingData.Size = new System.Drawing.Size(861, 417);
            this.dgvTesingData.TabIndex = 0;
            // 
            // tabClasters
            // 
            this.tabClasters.Controls.Add(this.dgvClasterEntities);
            this.tabClasters.Controls.Add(this.dgvClasters);
            this.tabClasters.Location = new System.Drawing.Point(4, 22);
            this.tabClasters.Name = "tabClasters";
            this.tabClasters.Padding = new System.Windows.Forms.Padding(3);
            this.tabClasters.Size = new System.Drawing.Size(867, 455);
            this.tabClasters.TabIndex = 2;
            this.tabClasters.Text = "Кластеры";
            this.tabClasters.UseVisualStyleBackColor = true;
            // 
            // dgvClasterEntities
            // 
            this.dgvClasterEntities.AllowUserToAddRows = false;
            this.dgvClasterEntities.AllowUserToDeleteRows = false;
            this.dgvClasterEntities.AllowUserToResizeRows = false;
            this.dgvClasterEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasterEntities.Location = new System.Drawing.Point(3, 121);
            this.dgvClasterEntities.Name = "dgvClasterEntities";
            this.dgvClasterEntities.ReadOnly = true;
            this.dgvClasterEntities.RowHeadersVisible = false;
            this.dgvClasterEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasterEntities.Size = new System.Drawing.Size(861, 328);
            this.dgvClasterEntities.TabIndex = 10;
            // 
            // dgvClasters
            // 
            this.dgvClasters.AllowUserToAddRows = false;
            this.dgvClasters.AllowUserToDeleteRows = false;
            this.dgvClasters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasters.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvClasters.Location = new System.Drawing.Point(3, 3);
            this.dgvClasters.Name = "dgvClasters";
            this.dgvClasters.ReadOnly = true;
            this.dgvClasters.RowHeadersVisible = false;
            this.dgvClasters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasters.Size = new System.Drawing.Size(861, 112);
            this.dgvClasters.TabIndex = 9;
            this.dgvClasters.SelectionChanged += new System.EventHandler(this.Dgv_Clasters_SelectionChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 505);
            this.Controls.Add(this.tabPanelMain);
            this.MaximumSize = new System.Drawing.Size(915, 544);
            this.MinimumSize = new System.Drawing.Size(915, 544);
            this.Name = "MainForm";
            this.Text = "Сеть Кохонена";
            this.tabPanelMain.ResumeLayout(false);
            this.tabLearning.ResumeLayout(false);
            this.tabLearning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbClastersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputLearningData)).EndInit();
            this.tabTesting.ResumeLayout(false);
            this.tabTesting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTesingData)).EndInit();
            this.tabClasters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasterEntities)).EndInit();
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
    }
}

