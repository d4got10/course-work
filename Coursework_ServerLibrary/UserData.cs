namespace Сoursework_Server
{
    public struct UserData
    {
        //Amount
        public readonly string Login;
        public readonly string Password;

        public UserData(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
