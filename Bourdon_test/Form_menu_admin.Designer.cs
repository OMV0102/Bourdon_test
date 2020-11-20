namespace Bourdon_test
{
    partial class Form_menu_admin
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
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisterUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRegisterUser.Location = new System.Drawing.Point(101, 74);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(196, 62);
            this.btnRegisterUser.TabIndex = 0;
            this.btnRegisterUser.TabStop = false;
            this.btnRegisterUser.Text = "Регистрация новых пользователей";
            this.btnRegisterUser.UseVisualStyleBackColor = true;
            this.btnRegisterUser.Click += new System.EventHandler(this.btnRegisterUser_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(113, 296);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(137, 45);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditUser.Enabled = false;
            this.btnEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditUser.Location = new System.Drawing.Point(101, 151);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(196, 62);
            this.btnEditUser.TabIndex = 2;
            this.btnEditUser.TabStop = false;
            this.btnEditUser.Text = "Редактирование пользователей";
            this.btnEditUser.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(134, 24);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Фамилия И.О.";
            // 
            // Form_menu_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 381);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRegisterUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_menu_admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню аналитика";
            this.Load += new System.EventHandler(this.Form_menu_admin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_menu_admin_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegisterUser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Label lblName;
    }
}