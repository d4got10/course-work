using CourseWork_Server.DataStructures;

namespace Сoursework_Server
{
    public struct UserData : ISaveable, ILoadable
    {
        //Amount
        public string Login { get; private set; }
        public string Password { get; private set; }

        public UserData(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string GetData()
        {
            return Login + "|" + Password;
        }

        public void SetData(string data)
        {
            var splitted = data.Split('|');
            Login = splitted[0];
            Password = splitted[1];
        }
    }
}
