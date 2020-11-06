using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bourdon_test
{
    public partial class Form_menu_admin : Form
    {
        public Form_menu_admin(User userObject)
        {
            InitializeComponent();
            user = userObject;
        }

        private User user;

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {

        }
    }
}
