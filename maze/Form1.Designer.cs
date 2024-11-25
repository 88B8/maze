namespace labirint
{
    partial class MazeForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonSolution = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonStep = new System.Windows.Forms.Button();
            this.rowsTextbox = new System.Windows.Forms.MaskedTextBox();
            this.colsTextbox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(11, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1522, 937);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(44, 955);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(122, 52);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Сгенерировать лабиринт";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonSolution
            // 
            this.buttonSolution.Location = new System.Drawing.Point(172, 955);
            this.buttonSolution.Name = "buttonSolution";
            this.buttonSolution.Size = new System.Drawing.Size(122, 52);
            this.buttonSolution.TabIndex = 2;
            this.buttonSolution.Text = "Показать решение";
            this.buttonSolution.UseVisualStyleBackColor = true;
            this.buttonSolution.Click += new System.EventHandler(this.buttonSolution_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(300, 955);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(122, 52);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Очистить лабиринт";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonStep
            // 
            this.buttonStep.Location = new System.Drawing.Point(428, 955);
            this.buttonStep.Name = "buttonStep";
            this.buttonStep.Size = new System.Drawing.Size(122, 52);
            this.buttonStep.TabIndex = 4;
            this.buttonStep.Text = "Шаг";
            this.buttonStep.UseVisualStyleBackColor = true;
            this.buttonStep.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // rowsTextbox
            // 
            this.rowsTextbox.Location = new System.Drawing.Point(642, 958);
            this.rowsTextbox.Mask = "000";
            this.rowsTextbox.Name = "rowsTextbox";
            this.rowsTextbox.Size = new System.Drawing.Size(81, 20);
            this.rowsTextbox.TabIndex = 5;
            this.rowsTextbox.Text = "21";
            this.rowsTextbox.ValidatingType = typeof(int);
            // 
            // colsTextbox
            // 
            this.colsTextbox.Location = new System.Drawing.Point(642, 984);
            this.colsTextbox.Mask = "000";
            this.colsTextbox.Name = "colsTextbox";
            this.colsTextbox.Size = new System.Drawing.Size(81, 20);
            this.colsTextbox.TabIndex = 6;
            this.colsTextbox.Text = "21";
            this.colsTextbox.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 961);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Строки:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 987);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Столбцы:";
            // 
            // MazeForm
            // 
            this.ClientSize = new System.Drawing.Size(1545, 1022);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colsTextbox);
            this.Controls.Add(this.rowsTextbox);
            this.Controls.Add(this.buttonStep);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSolution);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.pictureBox);
            this.Name = "MazeForm";
            this.Text = "Лабиринт";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MazeForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonSolution;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonStep;
        private System.Windows.Forms.MaskedTextBox rowsTextbox;
        private System.Windows.Forms.MaskedTextBox colsTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

