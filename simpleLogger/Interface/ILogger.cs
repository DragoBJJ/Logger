﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleLogger.Interfaces
{
    interface ILogger
    {
        void Log(int userID, string name, string proffesion, string message);
    }
}
