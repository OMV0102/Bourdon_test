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
    public partial class Form_menu_user : Form
    {
        public Form_menu_user(User userObject)
        {
            InitializeComponent();
            this.user = userObject;
        }

        private User user;
    }
}
