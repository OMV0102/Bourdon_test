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
            this.lblName = new System.Windows.Forms.Label();
            this.btnResultAllShow = new System.Windows.Forms.Button();
            this.btnEditUsers = new System.Windows.Forms.Button();
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
            this.btnExit.Location = new System.Drawing.Point(126, 305);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(137, 45);
            this.btnExit.TabIndex = 20;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            // btnResultAllShow
            // 
            this.btnResultAllShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResultAllShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResultAllShow.Location = new System.Drawing.Point(101, 227);
            this.btnResultAllShow.Name = "btnResultAllShow";
            this.btnResultAllShow.Size = new System.Drawing.Size(196, 62);
            this.btnResultAllShow.TabIndex = 10;
            this.btnResultAllShow.TabStop = false;
            this.btnResultAllShow.Text = "Просмотр всех результатов";
            this.btnResultAllShow.UseVisualStyleBackColor = true;
            this.btnResultAllShow.Click += new System.EventHandler(this.btnResultAllShow_Click);
            // 
            // btnEditUsers
            // 
            this.btnEditUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditUsers.Location = new System.Drawing.Point(75, 153);
            this.btnEditUsers.Name = "btnEditUsers";
            this.btnEditUsers.Size = new System.Drawing.Size(243, 62);
            this.btnEditUsers.TabIndex = 5;
            this.btnEditUsers.TabStop = false;
            this.btnEditUsers.Text = "Просмотр и редактирование пользователей";
            this.btnEditUsers.UseVisualStyleBackColor = true;
            this.btnEditUsers.Click += new System.EventHandler(this.btnEditUsers_Click);
            // 
            // Form_menu_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 362);
            this.Controls.Add(this.btnEditUsers);
            this.Controls.Add(this.btnResultAllShow);
            this.Controls.Add(this.lblName);
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
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnResultAllShow;
        private System.Windows.Forms.Button btnEditUsers;
    }
}