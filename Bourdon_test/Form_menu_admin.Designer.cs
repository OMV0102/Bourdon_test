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
            this.SuspendLayout();
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.Location = new System.Drawing.Point(299, 120);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(196, 23);
            this.btnRegisterUser.TabIndex = 0;
            this.btnRegisterUser.Text = "Регистрация пользователей";
            this.btnRegisterUser.UseVisualStyleBackColor = true;
            this.btnRegisterUser.Click += new System.EventHandler(this.btnRegisterUser_Click);
            // 
            // Form_menu_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegisterUser);
            this.Name = "Form_menu_admin";
            this.Text = "Form_menu_admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegisterUser;
    }
}