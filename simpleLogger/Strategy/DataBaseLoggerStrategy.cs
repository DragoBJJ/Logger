using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using simpleLogger.Interfaces;

namespace simpleLogger.Strategy
{
    class DataBaseLoggerStrategy : ILogger
    {

        private readonly IDataBase DataBase;

        public DataBaseLoggerStrategy(IDataBase dataBase)
        {

            DataBase = dataBase;

        }

        public void Log(int userID, string username, string proffesion, string message)
        {
            DataBase.AddLog(userID, username, proffesion, message);
        }
    }
}
