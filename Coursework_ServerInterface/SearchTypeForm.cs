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
    public partial class SearchTypeForm : Form
    {
        private Action<SearchTypes> _onAction;

        public SearchTypeForm(Action<SearchTypes> onAction)
        {
            _onAction = onAction;
            InitializeComponent();
        }

        private void userSearchButton_Click(object sender, EventArgs e)
        {
            _onAction?.Invoke(SearchTypes.User);
            Hide();
        }

        private void clanSearchButton_Click(object sender, EventArgs e)
        {
            _onAction?.Invoke(SearchTypes.Clan);
            Hide();
        }
    }
}
