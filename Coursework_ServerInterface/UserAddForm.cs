using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_ServerInterface
{
    public partial class UserAddForm : Form
    {
        private Action<string[]> _onAddAction;

        public UserAddForm(Action<string[]> onAddAction)
        {
            InitializeComponent();
            _onAddAction = onAddAction;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = new string[6];
            values[0] = nameTextBox.Text;
            values[1] = passwordTextBox.Text;
            values[2] = xPositionTextBox.Text + ":" + yPositionTextBox.Text;
            values[3] = clanTextBox.Text;
            values[4] = actionPointsTextBox.Text;
            values[5] = healthTextBox.Text;
            _onAddAction.Invoke(values);
            Hide();
        }
    }
}
