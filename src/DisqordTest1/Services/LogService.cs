﻿using System;

namespace DisqordTest1.Services
{
    public class LogService : ILogService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
