using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public static partial class LoggingExtensions
    {
        static partial void OnException(MonoBehaviour monoBehaviour, string message, string stackTrace);

        static partial void OnWarning(MonoBehaviour monoBehaviour, string message, string stackTrace);

        static partial void OnLog(MonoBehaviour monoBehaviour, string message, string stackTrace);

        public static void LogMessage(this MonoBehaviour monoBehaviour, string message, string stackTrace, LogType logType)
        {
            switch (logType)
            {
                case LogType.Exception:
                    OnException(monoBehaviour, message, stackTrace);
                    break;

                case LogType.Warning:
                    OnWarning(monoBehaviour, message, stackTrace);
                    break;

                case LogType.Log:
                    OnLog(monoBehaviour, message, stackTrace);
                    break;
            }
        }
    }
}
