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

        private enum GridViews
        {
            Main,
            Users,
            Clans
        }

        private GridViews _currentGridView;
        private bool _gridDataNeedsToUpdate;

        public Form1()
        {
            Load += new EventHandler(Form1_Load);
            InitializeComponent();
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            usersGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            usersGridView.MultiSelect = false;
            usersGridView.Dock = DockStyle.Fill;

            usersGridView.DefaultCellStyle.SelectionForeColor = Color.Gray;

            _currentGridView = GridViews.Main;

            ServerPowerStateChange += (t) => UpdateServerButtons();
            ServerIsRunning = false;

            Server = new Server();
            UpdateMainGridView();
            UpdateUsersGridView();

            UpdateGridView();
            UpdateServerButtons();
            Server.GameLogic.PlayersUpdated += () => _gridDataNeedsToUpdate = true;
            Server.GameLogic.UsersUpdated += () => _gridDataNeedsToUpdate = true;
            Server.GameLogic.ClansUpdated += () => _gridDataNeedsToUpdate = true;
        }

        private void UpdateMainGridView()
        {

            mainGridView.Rows.Clear();
            var values = Server.GameLogic.Players;
            for (int i = 0; i < values.Count; i++)
            {
                string[] row = new string[7];
                row[0] = values[i].UserData.Login;//.Hash.ToString();
                row[1] = values[i].UserData.Password;
                row[2] = values[i].Position.ToString();
                if (values[i].Clan != null)
                {
                    row[3] = values[i].Clan.Name;//.Position.ToString();
                    row[4] = values[i].Clan.ColorCode;
                }
                else
                {
                    row[3] = "";
                    row[4] = "";
                }
                row[5] = values[i].ActionPointsCount.ToString();
                row[6] = values[i].Health.ToString();
                mainGridView.Rows.Add(row);
            }
        }

        private void UpdateUsersGridView()
        {

            usersGridView.Rows.Clear();
            var values = Server.GameLogic.UsersValues;
            for (int i = 0; i < values.Length; i++)
            {
                string[] row = new string[3];
                row[0] = values[i].Hash.ToString();
                row[1] = values[i].Value.Login;
                row[2] = values[i].Value.Password;
                usersGridView.Rows.Add(row);
            }
        }

        private void UpdateClansGridView()
        {

            clansGridView.Rows.Clear();
            var values = Server.GameLogic.ClansValues;
            for (int i = 0; i < values.Length; i++)
            {
                string[] row = new string[3];
                row[0] = values[i].Hash.ToString();
                row[1] = values[i].Value.Name;
                row[2] = values[i].Value.ColorCode;
                clansGridView.Rows.Add(row);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Form form = null;
            switch (_currentGridView)
            {
                case GridViews.Main:
                    form = new PlayerAddForm(Server.GameLogic.UsersFinder, Server.GameLogic.ClansFinder, OnAddPlayer);
                    break;
                case GridViews.Users:
                    form = new UserAddForm(OnAddUser);
                    break;
                case GridViews.Clans:
                    form = new ClanAddForm(OnAddClan);
                    break;
            }
            if(form != null)
                form.Show();
        }

        private void OnAddUser(string[] values)
        {
            try
            {
                if (values.Length == 2)
                {
                    var username = values[0];
                    var password = values[1];

                    var player = Server.GameLogic.CreateUser(username, password);
                }
                else
                {
                    throw new Exception("Введено некорректное количество полей.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Некорректные входные данные.");
            }
        }

        private void OnAddClan(string[] values)
        {
            try
            {
                if (values.Length == 2)
                {
                    var clanName = values[0];
                    var colorCode = values[1];

                    var clan = Server.GameLogic.CreateClan(clanName, colorCode);
                }
                else
                {
                    throw new Exception("Введено некорректное количество полей.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректные входные данные.");
            }
        }

        private void OnAddPlayer(string[] values)
        {
            try
            {
                if (values.Length == 7)
                {
                    var username = values[0];
                    var password = values[1];

                    if (Server.GameLogic.TryGetUserData(username, password, out var data))
                    {
                        var splittedPosition = values[4].Split(':');
                        var position = new Vector2(int.Parse(splittedPosition[0]), int.Parse(splittedPosition[1]));
                        var actionPoints = int.Parse(values[5]);
                        var health = int.Parse(values[6]);

                        //TODO: find clan and add to user
                        var clanName = values[2];
                        var clanColorCode = values[3];
                        Clan clan;

                        Server.GameLogic.ClansFinder.TryFind(clanName, out clan, out _);

                        var player = Server.GameLogic.CreateAndAddPlayer(data, position, clan, actionPoints, health);
                    }
                    else
                    {
                        throw new Exception("Пользователя с такими данными не существует.");
                    }
                }
                else
                {
                    throw new Exception("Введено некорректное количество полей.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректные входные данные." + ex.Message);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            switch (_currentGridView)
            {
                case GridViews.Main:
                    if (usersGridView.SelectedRows.Count > 0)
                    {
                        string username = (string)mainGridView.SelectedRows[0].Cells[0].Value;
                        string password = (string)mainGridView.SelectedRows[0].Cells[1].Value;
                        if (Server.GameLogic.PlayersByName.TryFind(username, out var players))
                        {
                            foreach (var player in players)
                            {
                                Server.GameLogic.RemovePlayer(player);
                            }
                        }
                    }
                    break;
                case GridViews.Users:
                    if (usersGridView.SelectedRows.Count > 0)
                    {
                        string username = (string)usersGridView.SelectedRows[0].Cells[1].Value;
                        string password = (string)usersGridView.SelectedRows[0].Cells[2].Value;
                        if (Server.GameLogic.UsersFinder.TryFind(username, out var user, out _))
                        {
                            Server.GameLogic.RemoveUser(user);
                        }
                    }
                    break;
                case GridViews.Clans:
                    if (usersGridView.SelectedRows.Count > 0)
                    {
                        string clanName = (string)clansGridView.SelectedRows[0].Cells[1].Value;
                        string colorCode = (string)clansGridView.SelectedRows[0].Cells[2].Value;
                        if (Server.GameLogic.ClansFinder.TryFind(clanName, out var clan, out _))
                        {
                            Server.GameLogic.RemoveClan(clan);
                        }
                    }
                    break;
            }
        }

        private void usersDataGridButton_Click(object sender, EventArgs e)
        {
            _currentGridView = GridViews.Users;
            UpdateGridView();
        }

        private void mainGridDataButton_Click(object sender, EventArgs e)
        {
            _currentGridView = GridViews.Main;
            UpdateGridView();
        }
        private void clansGridDataButton_Click(object sender, EventArgs e)
        {
            _currentGridView = GridViews.Clans;
            UpdateGridView();
        }

        private void UpdateGridView()
        {
            DisableAllGridViews();
            switch (_currentGridView)
            {
                case GridViews.Main:
                    UpdateMainGridView();
                    mainGridView.Show();
                    break;
                case GridViews.Users:
                    UpdateUsersGridView();
                    usersGridView.Show();
                    break;
                case GridViews.Clans:
                    UpdateClansGridView();
                    clansGridView.Show();
                    break;
                default:
                    break;
            }
            _gridDataNeedsToUpdate = false;
        }

        private void DisableAllGridViews()
        {
            mainGridView.Hide();
            usersGridView.Hide();
            clansGridView.Hide();
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
            if (_gridDataNeedsToUpdate)
            {
                UpdateGridView();
            }
        }

    }
}
