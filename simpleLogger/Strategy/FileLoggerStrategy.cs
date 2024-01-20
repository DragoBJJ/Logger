using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Diagnostics;
using simpleLogger.Interfaces;


namespace simpleLogger.Strategy;


public class FileLoggerStrategy : ILogger

{
    private string FileName { get; set; }
    private string FilePath { get; set; }


    public FileLoggerStrategy(string owner, string path)
    {
        SaveOwnerData(owner, path);
    }

    private void SaveLogFile(int userID, string name, string proffesion, string message)
    {
        using StreamWriter w = File.AppendText(FilePath);
        {
            w.WriteLine("\r\nLog Entry : ");
            w.WriteLine(" {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine($"User ID: {userID}, Name: {name}, Proffesion: {proffesion}, Message :{message}");
            w.WriteLine("---------------------------------------------------------------------------");
        }
    }

    private void SaveOwnerData(string owner = "", string directory = "")
    {
        FileName = $"{owner}Log.txt";
        FilePath = $"{directory}/{FileName}";
    }


    public void Log(int userID, string name, string proffesion, string message)
    {
        SaveLogFile(userID, name, proffesion, message);
    }
}