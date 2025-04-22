namespace Laba_12
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown_arraySize = new System.Windows.Forms.NumericUpDown();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SortMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comparisons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sorted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_arraySize)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.SortMethod,
            this.Comparisons,
            this.Assignments,
            this.Time,
            this.sorted});
            this.dataGridView1.Location = new System.Drawing.Point(6, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(785, 212);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(50, 242);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(105, 28);
            this.buttonSort.TabIndex = 1;
            this.buttonSort.Text = "Сортировать";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(277, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Размер массива";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(546, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // numericUpDown_arraySize
            // 
            this.numericUpDown_arraySize.Location = new System.Drawing.Point(225, 248);
            this.numericUpDown_arraySize.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown_arraySize.Name = "numericUpDown_arraySize";
            this.numericUpDown_arraySize.Size = new System.Drawing.Size(249, 20);
            this.numericUpDown_arraySize.TabIndex = 4;
            this.numericUpDown_arraySize.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CheckBox.Width = 40;
            // 
            // SortMethod
            // 
            this.SortMethod.FillWeight = 150F;
            this.SortMethod.HeaderText = "";
            this.SortMethod.Name = "SortMethod";
            this.SortMethod.ReadOnly = true;
            this.SortMethod.Width = 150;
            // 
            // Comparisons
            // 
            this.Comparisons.FillWeight = 150F;
            this.Comparisons.HeaderText = "Сравнения";
            this.Comparisons.Name = "Comparisons";
            this.Comparisons.ReadOnly = true;
            this.Comparisons.Width = 150;
            // 
            // Assignments
            // 
            this.Assignments.FillWeight = 150F;
            this.Assignments.HeaderText = "Присвоения";
            this.Assignments.Name = "Assignments";
            this.Assignments.ReadOnly = true;
            this.Assignments.Width = 150;
            // 
            // Time
            // 
            this.Time.FillWeight = 150F;
            this.Time.HeaderText = "Время";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 150;
            // 
            // sorted
            // 
            this.sorted.HeaderText = "Отсортировано";
            this.sorted.Name = "sorted";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(793, 283);
            this.Controls.Add(this.numericUpDown_arraySize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayupov 23VP1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_arraySize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown_arraySize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comparisons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorted;
    }
}

