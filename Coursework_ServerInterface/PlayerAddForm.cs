using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseWork_Server.DataStructures;
using CourseWork_Server.DataStructures.Danil;
using Сoursework_Server;

namespace Coursework_ServerInterface
{
    public partial class PlayerAddForm : Form
    {
        private Action<string[]> _onAddAction;
        private IHashTableFinder<string, UserData> _users;
        private IHashTableFinder<string, Clan> _clans;

        public PlayerAddForm(IHashTableFinder<string, UserData> users, IHashTableFinder<string, Clan> clans, Action<string[]> onAddAction)
        {
            InitializeComponent();
            _onAddAction = onAddAction;
            _users = users;
            _clans = clans;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_users.TryFind(userNameTextBox.Text, out var data, out _))
            {
                passwordTextBox.Text = data.Password;
            }
            else
            {
                passwordTextBox.Text = "ошибка";
            }
        }

        private void PlayerAddForm_Load(object sender, EventArgs e)
        {
            positionXField.Minimum = -AppConstants.GameGridSize / 2;
            positionXField.Maximum = AppConstants.GameGridSize / 2;

            positionYField.Minimum = -AppConstants.GameGridSize / 2;
            positionYField.Maximum = AppConstants.GameGridSize / 2;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var values = new string[7];
            values[0] = userNameTextBox.Text;
            values[1] = passwordTextBox.Text;
            values[2] = clanTextBox.Text;
            values[3] = colorTextBox.Text;
            values[4] = positionXField.Value.ToString() + ":" + positionYField.Value.ToString();
            values[5] = actionPointsField.Value.ToString();
            values[6] = healthPointsField.Value.ToString();
            _onAddAction.Invoke(values);
            Hide();
        }

        private void clanTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_clans.TryFind(clanTextBox.Text, out var data, out _))
            {
                colorTextBox.Text = data.ColorCode;
            }
            else
            {
                colorTextBox.Text = "ошибка";
            }
        }
    }
}
