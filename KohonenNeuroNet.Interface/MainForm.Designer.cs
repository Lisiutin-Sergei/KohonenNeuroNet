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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbClastersCount = new System.Windows.Forms.NumericUpDown();
            this.btnLearnNetwork = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbEpochCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tabNetwork = new System.Windows.Forms.TabPage();
            this.tabPanelMain.SuspendLayout();
            this.tabLearning.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbClastersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputLearningData)).BeginInit();
            this.tabTesting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTesingData)).BeginInit();
            this.tabClasters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasterEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEpochCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.tabPanelMain.Size = new System.Drawing.Size(875, 481);
            this.tabPanelMain.TabIndex = 0;
            // 
            // tabLearning
            // 
            this.tabLearning.Controls.Add(this.groupBox2);
            this.tabLearning.Controls.Add(this.groupBox1);
            this.tabLearning.Location = new System.Drawing.Point(4, 22);
            this.tabLearning.Name = "tabLearning";
            this.tabLearning.Padding = new System.Windows.Forms.Padding(3);
            this.tabLearning.Size = new System.Drawing.Size(867, 455);
            this.tabLearning.TabIndex = 0;
            this.tabLearning.Text = "Обучение";
            this.tabLearning.UseVisualStyleBackColor = true;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbEpochCount);
            this.groupBox1.Controls.Add(this.tbClastersCount);
            this.groupBox1.Controls.Add(this.btnLearnNetwork);
            this.groupBox1.Controls.Add(this.tbLearningFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnChooseLearningFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры обучения";
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
            this.tbClastersCount.Size = new System.Drawing.Size(45, 20);
            this.tbClastersCount.TabIndex = 5;
            this.tbClastersCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnLearnNetwork
            // 
            this.btnLearnNetwork.Location = new System.Drawing.Point(762, 67);
            this.btnLearnNetwork.Name = "btnLearnNetwork";
            this.btnLearnNetwork.Size = new System.Drawing.Size(93, 23);
            this.btnLearnNetwork.TabIndex = 3;
            this.btnLearnNetwork.Text = "Обучить сеть";
            this.btnLearnNetwork.UseVisualStyleBackColor = true;
            this.btnLearnNetwork.Click += new System.EventHandler(this.Btn_LearnNetwork_Click);
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
            // tbLearningFile
            // 
            this.tbLearningFile.Location = new System.Drawing.Point(138, 18);
            this.tbLearningFile.Name = "tbLearningFile";
            this.tbLearningFile.ReadOnly = true;
            this.tbLearningFile.Size = new System.Drawing.Size(618, 20);
            this.tbLearningFile.TabIndex = 2;
            // 
            // btnChooseLearningFile
            // 
            this.btnChooseLearningFile.Location = new System.Drawing.Point(762, 16);
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
            this.dgvInputLearningData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInputLearningData.Location = new System.Drawing.Point(3, 16);
            this.dgvInputLearningData.Name = "dgvInputLearningData";
            this.dgvInputLearningData.ReadOnly = true;
            this.dgvInputLearningData.RowHeadersVisible = false;
            this.dgvInputLearningData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInputLearningData.Size = new System.Drawing.Size(855, 333);
            this.dgvInputLearningData.TabIndex = 0;
            // 
            // tabTesting
            // 
            this.tabTesting.Controls.Add(this.groupBox4);
            this.tabTesting.Controls.Add(this.groupBox3);
            this.tabTesting.Controls.Add(this.button1);
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
            this.BtnTest.Location = new System.Drawing.Point(747, 47);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(102, 23);
            this.BtnTest.TabIndex = 7;
            this.BtnTest.Text = "Кластеризовать";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.Btn_Test_Click);
            // 
            // tbTestingFile
            // 
            this.tbTestingFile.Location = new System.Drawing.Point(165, 18);
            this.tbTestingFile.Name = "tbTestingFile";
            this.tbTestingFile.ReadOnly = true;
            this.tbTestingFile.Size = new System.Drawing.Size(576, 20);
            this.tbTestingFile.TabIndex = 6;
            // 
            // btnChooseTestingFile
            // 
            this.btnChooseTestingFile.Location = new System.Drawing.Point(747, 16);
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
            this.dgvTesingData.Size = new System.Drawing.Size(855, 354);
            this.dgvTesingData.TabIndex = 0;
            // 
            // tabClasters
            // 
            this.tabClasters.Controls.Add(this.groupBox6);
            this.tabClasters.Controls.Add(this.groupBox5);
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
            this.dgvClasterEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClasterEntities.Location = new System.Drawing.Point(3, 16);
            this.dgvClasterEntities.Name = "dgvClasterEntities";
            this.dgvClasterEntities.ReadOnly = true;
            this.dgvClasterEntities.RowHeadersVisible = false;
            this.dgvClasterEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasterEntities.Size = new System.Drawing.Size(855, 287);
            this.dgvClasterEntities.TabIndex = 10;
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
            this.dgvClasters.Size = new System.Drawing.Size(855, 124);
            this.dgvClasters.TabIndex = 9;
            this.dgvClasters.SelectionChanged += new System.EventHandler(this.Dgv_Clasters_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество эпох";
            // 
            // tbEpochCount
            // 
            this.tbEpochCount.Location = new System.Drawing.Point(138, 70);
            this.tbEpochCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbEpochCount.Name = "tbEpochCount";
            this.tbEpochCount.Size = new System.Drawing.Size(45, 20);
            this.tbEpochCount.TabIndex = 5;
            this.tbEpochCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvInputLearningData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(861, 352);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выборка для обучения";
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
            this.groupBox3.Size = new System.Drawing.Size(861, 76);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvTesingData);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(861, 373);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Выборка для кластеризации";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvClasters);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(861, 143);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Кластеры";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvClasterEntities);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 146);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(861, 306);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Элементы кластера";
            // 
            // tabNetwork
            // 
            this.tabNetwork.Location = new System.Drawing.Point(4, 22);
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.tabNetwork.Size = new System.Drawing.Size(867, 455);
            this.tabNetwork.TabIndex = 3;
            this.tabNetwork.Text = "Сеть";
            this.tabNetwork.UseVisualStyleBackColor = true;
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbClastersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputLearningData)).EndInit();
            this.tabTesting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTesingData)).EndInit();
            this.tabClasters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasterEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbEpochCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
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
        private System.Windows.Forms.NumericUpDown tbEpochCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TabPage tabNetwork;
    }
}

