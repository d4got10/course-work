using CourseWork_Server.DataStructures;
using Coursework_ServerLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Сoursework_Server;

namespace Coursework_ServerInterface
{
    public partial class DebugForm : Form
    {
        private bool _needsToUpdateTextBox;
        private readonly IDisplayable _nameTree;
        private readonly IDisplayable _clanTree;
        private readonly IDisplayable _healthTree;
        private readonly IDisplayable _actionPointsTree;

        public DebugForm(IDisplayable nameTree, IDisplayable clanTree, IDisplayable healthTree, IDisplayable actionPointsTree)
        {
            InitializeComponent();

            _nameTree = nameTree;
            _clanTree = clanTree;
            _healthTree = healthTree;
            _actionPointsTree = actionPointsTree;

            Debug.ClearChangedContent();
            Debug.Changed += QueueTextBoxUpdate;
        }

        private void QueueTextBoxUpdate()
        {
            _needsToUpdateTextBox = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_needsToUpdateTextBox)
                UpdateTextBox();
        }

        private void UpdateTextBox()
        {
            _needsToUpdateTextBox = false;
            if(Visible) debugTextBox.AppendText(Debug.ChangedContent);
            Debug.ClearChangedContent();
        }

        private void DebugForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.Changed -= QueueTextBoxUpdate;
        }

        private void clearTextBoxButton_Click(object sender, EventArgs e)
        {
            debugTextBox.Clear();
        }

        private void displayNameTreeButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Дерево поиска по имени:");
            _nameTree.Display();
        }

        private void displayClanTreeButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Дерево поиска по имени клана:");
            _clanTree.Display();
        }

        private void displayHealthTreeButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Дерево поиска по количеству здоровья:");
            _healthTree.Display();
        }

        private void displayActionPointsTreeButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Дерево поиска по количеству очков действий:");
            _actionPointsTree.Display();
        }
    }
}
