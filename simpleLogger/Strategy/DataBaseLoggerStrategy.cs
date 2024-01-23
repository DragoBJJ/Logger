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
        private readonly StrategyKey ID = StrategyKey.DATABASE;
        private readonly IDataBase DataBase;

        public DataBaseLoggerStrategy(IDataBase dataBase)
        {

            this.DataBase = dataBase;

        }

        public StrategyKey GetID()
        {
            return this.ID;
        }

        public void Log(int userID, string username, string proffesion, string message)
        {
            this.DataBase.AddLog(userID, username, proffesion, message);
        }
    }
}
