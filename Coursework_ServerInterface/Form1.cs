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
        private bool _usersNeedsToUpdate;

        public Form1()
        {
            Load += new EventHandler(Form1_Load);
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

            _currentFromView = FormViews.Users;

            UpdateFormView();
            UpdateServerButtons();

            ServerPowerStateChange += (t) => UpdateServerButtons();
            ServerIsRunning = false;

            Server = new Server();
            UpdateUsersGridView();

            Server.GameLogic.UsersUpdated += () => _usersNeedsToUpdate = true;
        }

        private void UpdateUsersGridView()
        {
            dataGridView1.Rows.Clear();
            var values = Server.GameLogic.Values;
            for (int i = 0; i < values.Length; i++)
            {
                string[] row = new string[7];
                row[0] = values[i].Hash.ToString();
                row[1] = values[i].Value.Name.ToString();
                row[2] = values[i].Value.Password.ToString();
                row[3] = values[i].Value.Position.ToString();
                row[4] = values[i].Value.Clan;
                row[5] = values[i].Value.ActionPointsCount.ToString();
                row[6] = values[i].Value.Health.ToString();
                dataGridView1.Rows.Add(row);
            }
            _usersNeedsToUpdate = false;
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
            var newUserForm = new UserAddForm(OnAddUser);
            newUserForm.Show();
            //dataGridView1.Rows.Add();
        }

        private void OnAddUser(string[] values)
        {
            try
            {
                if (values.Length == 6)
                {
                    var username = values[0];
                    var password = values[1];
                    var splittedPosition = values[2].Split(':');
                    var x = splittedPosition[0];
                    var y = splittedPosition[1];
                    var position = new Vector2(int.Parse(x), int.Parse(y));
                    var clan = values[3];
                    var actionPointsCount = int.Parse(values[4]);
                    var health = int.Parse(values[5]);

                    var player = Server.GameLogic.CreateAndAddPlayer(username, password, position, clan, actionPointsCount, health);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Некорректные входные данные.");
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                dataGridView1.SelectedRows[0].Index !=
                dataGridView1.Rows.Count - 1)
            {
                string username = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
                string password = (string)dataGridView1.SelectedRows[0].Cells[2].Value;
                if (Server.GameLogic.TryGetPlayer(username, password, out var player))
                {
                    Server.GameLogic.RemovePlayer(player);
                }
                //dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
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
            StartServer();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StartServer()
        {
            ServerIsRunning = true;
            Server.Start();
        }

        private void StopServer()
        {
            ServerIsRunning = false;
            Server.Stop();
        }

        private void UpdateConsoleText()
        {
            if(Program.TryReadNewText(out var text))
                textBox1.AppendText(text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateConsoleText();
            if (_usersNeedsToUpdate)
            {
                UpdateUsersGridView();
            }
        }
    }
}
