using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;
using Сoursework_Server;

namespace Coursework_ServerInterface
{
    public partial class Form1 : Form
    {
        private bool _serverIsRunning;
        public bool ServerIsRunning
        {
            get => _serverIsRunning;
            set
            {
                if (_serverIsRunning != value) {
                    _serverIsRunning = value;
                    ServerPowerStateChange?.Invoke(value);
                }
            }
        }

        public Server Server { get; private set; }

        public Action<bool> ServerPowerStateChange;

        private enum FormViews
        {
            None,
            Users
        }

        private FormViews _currentFromView;

        public Form1()
        {
            this.Load += new EventHandler(Form1_Load);
            InitializeComponent();
        }

        private Panel _buttonPanel = new Panel();
        private DataGridView _songsDataGridView = new DataGridView();
        private Button _addNewRowButton = new Button();
        private Button _deleteRowButton = new Button();

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Dock = DockStyle.Fill;

            dataGridView1.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                songsDataGridView_CellFormatting);

            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Gray;

            UpdateFormView();
            UpdateServerButtons();

            ServerPowerStateChange += (t) => UpdateServerButtons();
            ServerIsRunning = false;

            Server = new Server();
        }

        private void songsDataGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }

        private void SetupDataGridView()
        {
            Controls.Add(_songsDataGridView);

            _songsDataGridView.ColumnCount = 5;

            _songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            _songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            _songsDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(_songsDataGridView.Font, FontStyle.Bold);

            _songsDataGridView.Name = "songsDataGridView";
            _songsDataGridView.Location = new Point(8, 8);
            _songsDataGridView.Size = new Size(500, 250);
            _songsDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            _songsDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            _songsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            _songsDataGridView.GridColor = Color.Black;
            _songsDataGridView.RowHeadersVisible = false;

            _songsDataGridView.Columns[0].Name = "Release Date";
            _songsDataGridView.Columns[1].Name = "Track";
            _songsDataGridView.Columns[2].Name = "Title";
            _songsDataGridView.Columns[3].Name = "Artist";
            _songsDataGridView.Columns[4].Name = "Album";
            _songsDataGridView.Columns[4].DefaultCellStyle.Font =
                new Font(_songsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            _songsDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            _songsDataGridView.MultiSelect = false;
            _songsDataGridView.Dock = DockStyle.Fill;

            _songsDataGridView.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                songsDataGridView_CellFormatting);
        }

        private void PopulateDataGridView()
        {

            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            _songsDataGridView.Rows.Add(row0);
            _songsDataGridView.Rows.Add(row1);
            _songsDataGridView.Rows.Add(row2);
            _songsDataGridView.Rows.Add(row3);
            _songsDataGridView.Rows.Add(row4);
            _songsDataGridView.Rows.Add(row5);
            _songsDataGridView.Rows.Add(row6);

            _songsDataGridView.Columns[0].DisplayIndex = 0;//3;
            _songsDataGridView.Columns[1].DisplayIndex = 1;//4;
            _songsDataGridView.Columns[2].DisplayIndex = 2;//0;
            _songsDataGridView.Columns[3].DisplayIndex = 3;//1;
            _songsDataGridView.Columns[4].DisplayIndex = 4;//2;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.SelectedRows[0].Index !=
                dataGridView1.Rows.Count - 1)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_currentFromView == FormViews.Users)
                _currentFromView = FormViews.None;
            else
                _currentFromView = FormViews.Users;
            UpdateFormView();
        }

        private void UpdateFormView()
        {
            switch (_currentFromView)
            {
                case FormViews.Users:
                    dataGridView1.Show();
                    break;
                default:
                    dataGridView1.Hide();
                    break;
            }
        }

        private void UpdateServerButtons()
        {
            if (ServerIsRunning)
            {
                StartButton.Enabled = false;
                StopButton.Enabled = true;
            }
            else
            {
                StartButton.Enabled = true;
                StopButton.Enabled = false;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ServerIsRunning = true;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ServerIsRunning = false;
        }

        private void StartServer()
        {
            Server.Start();
        }

        private void StopServer()
        {
            //Server.Shutdown();
        }
    }
}
