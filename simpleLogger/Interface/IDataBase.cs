using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleLogger.Interfaces
{
    interface IDataBase
    {
        void AddLog(int userID, string name, string profession, string message);
    }
}
