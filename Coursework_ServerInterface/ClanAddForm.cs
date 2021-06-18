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
    public partial class ClanAddForm : Form
    {
        private Action<string[]> _onAddAction;

        public ClanAddForm(Action<string[]> onAddAction)
        {
            InitializeComponent();
            _onAddAction = onAddAction;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = new string[2];
            values[0] = nameTextBox.Text;
            values[1] = colorCodeTextBox.Text;
            _onAddAction.Invoke(values);
            Hide();
        }
    }
}
