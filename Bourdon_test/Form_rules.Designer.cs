namespace Bourdon_test
{
    partial class Form_rules
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.boxDifficulty = new System.Windows.Forms.ComboBox();
            this.txtRules = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Location = new System.Drawing.Point(12, 424);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 43);
            this.btnBack.TabIndex = 0;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartTest.Location = new System.Drawing.Point(242, 417);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(241, 50);
            this.btnStartTest.TabIndex = 1;
            this.btnStartTest.TabStop = false;
            this.btnStartTest.Text = "Начать тестирование";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(196, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Правила прохождения теста";
            // 
            // boxDifficulty
            // 
            this.boxDifficulty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxDifficulty.FormattingEnabled = true;
            this.boxDifficulty.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.boxDifficulty.Location = new System.Drawing.Point(323, 59);
            this.boxDifficulty.Name = "boxDifficulty";
            this.boxDifficulty.Size = new System.Drawing.Size(121, 32);
            this.boxDifficulty.TabIndex = 3;
            this.boxDifficulty.TabStop = false;
            this.boxDifficulty.SelectedIndexChanged += new System.EventHandler(this.boxDifficulty_SelectedIndexChanged);
            // 
            // txtRules
            // 
            this.txtRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRules.BackColor = System.Drawing.SystemColors.Info;
            this.txtRules.DetectUrls = false;
            this.txtRules.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtRules.Location = new System.Drawing.Point(12, 103);
            this.txtRules.Name = "txtRules";
            this.txtRules.ReadOnly = true;
            this.txtRules.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRules.Size = new System.Drawing.Size(690, 303);
            this.txtRules.TabIndex = 4;
            this.txtRules.TabStop = false;
            this.txtRules.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(29, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите уровень сложности:";
            // 
            // Form_rules
            // 
            this.AcceptButton = this.btnStartTest;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(714, 480);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRules);
            this.Controls.Add(this.boxDifficulty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form_rules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Правила";
            this.Load += new System.EventHandler(this.Form_rules_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_rules_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxDifficulty;
        private System.Windows.Forms.RichTextBox txtRules;
        private System.Windows.Forms.Label label2;
    }
}