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
    public partial class RangeValuesInputForm : Form
    {
        private Action<int, int> _onAddAction;

        public RangeValuesInputForm(Action<int, int> onAddAction, int min, int max)
        {
            InitializeComponent();
            numericUpDown1.Minimum = min;
            numericUpDown2.Maximum = max;
            _onAddAction = onAddAction;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _onAddAction?.Invoke((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Hide();
        }
    }
}
