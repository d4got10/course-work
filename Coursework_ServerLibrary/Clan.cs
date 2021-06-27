using CourseWork_Server.DataStructures;

namespace Сoursework_Server
{
    public class Clan : ISaveable
    {
        public readonly string Name;
        public readonly string ColorCode;

        public Clan(string name, string colorCode)
        {
            Name = name;
            ColorCode = colorCode;
        }

        public string GetData()
        {
            return $"{Name}|{ColorCode}";
        }
    }
}
