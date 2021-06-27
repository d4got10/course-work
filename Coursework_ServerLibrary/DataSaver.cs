using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CourseWork_Server.DataStructures
{
    public interface ISaveable
    {
        string GetData();
    }

    public interface ILoadable
    {
        void SetData(string data);
    }

    public class DataSaver<T> where T : ISaveable
    {
        public void Save(T target, string path, string fileName)
        {
            Directory.CreateDirectory(path);
            File.WriteAllText(path + $"\\{fileName}", target.GetData());
        } 
    }

    public class DataLoader
    {
        public string Load(string path, string fileName)
        {
            try
            {
                using (var file = File.OpenRead(path + $"\\{fileName}"))
                {
                    using (var reader = new StreamReader(file))
                    {
                        var data = reader.ReadToEnd();
                        return data;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Файл для загрузки не существует. " + path);
                return "";
            }
        }
    }
}
