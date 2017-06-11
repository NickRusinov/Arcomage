using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Framework.Services
{
    public abstract class Logger
    {
        public virtual void LogLog(string message, string stackTrace) { }

        public virtual void LogWarning(string message, string stackTrace) { }

        public virtual void LogException(string message, string stackTrace) { }

        public void Log(string message, string stackTrace, LogType logType)
        {
            switch (logType)
            {
                case LogType.Exception:
                    LogException(message, stackTrace);
                    break;

                case LogType.Warning:
                    LogWarning(message, stackTrace);
                    break;

                case LogType.Log:
                    LogLog(message, stackTrace);
                    break;
            }
        }
    }
}
