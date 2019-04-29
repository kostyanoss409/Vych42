namespace ComputationalMath42
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.XMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.XMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AmountOfPoints = new System.Windows.Forms.TextBox();
            this.WriteValuesToFile = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.Button();
            this.Draw = new System.Windows.Forms.Button();
            this.Degree = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.XUserText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.YUserText = new System.Windows.Forms.TextBox();
            this.CalculateUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsShowPointValues = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(17, 16);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PointValueFormat = "G";
            this.zedGraphControl1.Size = new System.Drawing.Size(933, 718);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1009, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Диапазон Х";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(960, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "От";
            // 
            // XMin
            // 
            this.XMin.Location = new System.Drawing.Point(1005, 37);
            this.XMin.Margin = new System.Windows.Forms.Padding(4);
            this.XMin.MaxLength = 308;
            this.XMin.Name = "XMin";
            this.XMin.ShortcutsEnabled = false;
            this.XMin.Size = new System.Drawing.Size(132, 22);
            this.XMin.TabIndex = 3;
            this.XMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.XMin_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(960, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "До";
            // 
            // XMax
            // 
            this.XMax.Location = new System.Drawing.Point(1005, 70);
            this.XMax.Margin = new System.Windows.Forms.Padding(4);
            this.XMax.MaxLength = 308;
            this.XMax.Name = "XMax";
            this.XMax.ShortcutsEnabled = false;
            this.XMax.Size = new System.Drawing.Size(132, 22);
            this.XMax.TabIndex = 5;
            this.XMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.XMax_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(991, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Количество точек";
            // 
            // AmountOfPoints
            // 
            this.AmountOfPoints.Location = new System.Drawing.Point(983, 132);
            this.AmountOfPoints.Margin = new System.Windows.Forms.Padding(4);
            this.AmountOfPoints.MaxLength = 8;
            this.AmountOfPoints.Name = "AmountOfPoints";
            this.AmountOfPoints.ShortcutsEnabled = false;
            this.AmountOfPoints.Size = new System.Drawing.Size(132, 22);
            this.AmountOfPoints.TabIndex = 7;
            this.AmountOfPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountOfPoints_KeyPress);
            // 
            // WriteValuesToFile
            // 
            this.WriteValuesToFile.Location = new System.Drawing.Point(977, 171);
            this.WriteValuesToFile.Margin = new System.Windows.Forms.Padding(4);
            this.WriteValuesToFile.Name = "WriteValuesToFile";
            this.WriteValuesToFile.Size = new System.Drawing.Size(147, 38);
            this.WriteValuesToFile.TabIndex = 8;
            this.WriteValuesToFile.Text = "Записать в файл";
            this.WriteValuesToFile.UseVisualStyleBackColor = true;
            this.WriteValuesToFile.Click += new System.EventHandler(this.WriteValuesToFile_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(977, 217);
            this.OpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(147, 38);
            this.OpenFile.TabIndex = 9;
            this.OpenFile.Text = "Открыть файл";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // Draw
            // 
            this.Draw.Location = new System.Drawing.Point(999, 326);
            this.Draw.Margin = new System.Windows.Forms.Padding(4);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(100, 38);
            this.Draw.TabIndex = 10;
            this.Draw.Text = "Построить";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Degree
            // 
            this.Degree.Location = new System.Drawing.Point(983, 290);
            this.Degree.Margin = new System.Windows.Forms.Padding(4);
            this.Degree.MaxLength = 310;
            this.Degree.Name = "Degree";
            this.Degree.ShortcutsEnabled = false;
            this.Degree.Size = new System.Drawing.Size(132, 22);
            this.Degree.TabIndex = 11;
            this.Degree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Degree_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(979, 267);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Степень полинома";
            // 
            // XUserText
            // 
            this.XUserText.Location = new System.Drawing.Point(1005, 400);
            this.XUserText.Name = "XUserText";
            this.XUserText.ShortcutsEnabled = false;
            this.XUserText.Size = new System.Drawing.Size(132, 22);
            this.XUserText.TabIndex = 13;
            this.XUserText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.XUser_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1002, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Вычисление f(x)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(960, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(960, 429);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "f(X)";
            // 
            // YUserText
            // 
            this.YUserText.Location = new System.Drawing.Point(1005, 429);
            this.YUserText.Name = "YUserText";
            this.YUserText.Size = new System.Drawing.Size(132, 22);
            this.YUserText.TabIndex = 17;
            // 
            // CalculateUserButton
            // 
            this.CalculateUserButton.Location = new System.Drawing.Point(999, 458);
            this.CalculateUserButton.Name = "CalculateUserButton";
            this.CalculateUserButton.Size = new System.Drawing.Size(100, 38);
            this.CalculateUserButton.TabIndex = 18;
            this.CalculateUserButton.Text = "Вычислить";
            this.CalculateUserButton.UseVisualStyleBackColor = true;
            this.CalculateUserButton.Click += new System.EventHandler(this.CalculateUserButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 747);
            this.Controls.Add(this.CalculateUserButton);
            this.Controls.Add(this.YUserText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.XUserText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Degree);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.WriteValuesToFile);
            this.Controls.Add(this.AmountOfPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.XMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.XMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox XMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox XMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AmountOfPoints;
        private System.Windows.Forms.Button WriteValuesToFile;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.TextBox Degree;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox XUserText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox YUserText;
        private System.Windows.Forms.Button CalculateUserButton;
    }
}

