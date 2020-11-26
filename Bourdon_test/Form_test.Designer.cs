namespace Bourdon_test
{
    partial class Form_test
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
            this.components = new System.ComponentModel.Container();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelDigits = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.ColumnHeadersVisible = false;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grid.Location = new System.Drawing.Point(9, 118);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.RowTemplate.DividerHeight = 1;
            this.grid.RowTemplate.ReadOnly = true;
            this.grid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.ShowCellErrors = false;
            this.grid.ShowCellToolTips = false;
            this.grid.ShowEditingIcon = false;
            this.grid.ShowRowErrors = false;
            this.grid.Size = new System.Drawing.Size(826, 722);
            this.grid.TabIndex = 0;
            this.grid.TabStop = false;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnExit.Location = new System.Drawing.Point(9, 48);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(136, 36);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Закончить";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(761, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Время:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPause
            // 
            this.btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnPause.Location = new System.Drawing.Point(9, 8);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(136, 36);
            this.btnPause.TabIndex = 3;
            this.btnPause.TabStop = false;
            this.btnPause.Text = "Пауза";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(774, 49);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(55, 24);
            this.labelTime.TabIndex = 4;
            this.labelTime.Text = "00:00";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelDigits
            // 
            this.labelDigits.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.labelDigits.AutoSize = true;
            this.labelDigits.Location = new System.Drawing.Point(12, 89);
            this.labelDigits.Name = "labelDigits";
            this.labelDigits.Size = new System.Drawing.Size(222, 24);
            this.labelDigits.TabIndex = 5;
            this.labelDigits.Text = "Отмечайте эти цифры: ";
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(798, 83);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(30, 31);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "  ";
            // 
            // Form_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 852);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelDigits);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form_test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестирование";
            this.Load += new System.EventHandler(this.Form_test_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_test_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelDigits;
        private System.Windows.Forms.Label labelStatus;
    }
}