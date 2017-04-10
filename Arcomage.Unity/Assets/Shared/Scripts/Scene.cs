using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using SmartLocalization;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public partial class Scene : MonoBehaviour
    {
        static partial void OnException(string message, string stackTrace);

        static partial void OnWarning(string message, string stackTrace);

        static partial void OnLog(string message, string stackTrace);

        protected ILifetimeScope lifetimeScope;

        public virtual void Awake()
        {
            Application.logMessageReceived += OnLogMessageReceived;
            
            LanguageManager.Instance.defaultLanguage = GetLanguageCode(Application.systemLanguage);
            LanguageManager.Instance.ChangeLanguage(LanguageManager.Instance.defaultLanguage);
        }

        public virtual void OnEnable()
        {
            lifetimeScope = GameApplication.Instance.Container.BeginLifetimeScope(b => b.RegisterInstance(this));
        }

        public virtual void OnDisable()
        {
            lifetimeScope.Dispose();
        }

        private static void OnLogMessageReceived(string message, string stackTrace, LogType logType)
        {
            switch (logType)
            {
                case LogType.Exception:
                    OnException(message, stackTrace);
                    break;

                case LogType.Warning:
                    OnWarning(message, stackTrace);
                    break;

                case LogType.Log:
                    OnLog(message, stackTrace);
                    break;
            }
        }

        private static string GetLanguageCode(SystemLanguage language)
        {
            switch (language)
            {
                case SystemLanguage.English:
                    return "en-US";

                case SystemLanguage.Russian:
                    return "ru-RU";

                default:
                    return "en-US";
            }
        }
        
#if UNITY_ANDROID && !UNITY_EDITOR

        private static bool isHasBeenException;

        static partial void OnException(string message, string stackTrace)
        {
            if (!isHasBeenException)
            {
                var activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                var activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

                var sendReportClickListenerProxy = new SendReportClickListenerProxy("Exception", message, stackTrace);
                var cancelReportClickListenerProxy = new CancelReportClickHandlerProxy();
                var builder = new AndroidJavaObject("android.app.AlertDialog$Builder", activity);
                builder = builder.Call<AndroidJavaObject>("setCancelable", false);
                builder = builder.Call<AndroidJavaObject>("setTitle", "Непредвиденная ошибка");
                builder = builder.Call<AndroidJavaObject>("setMessage", "Отправить отчет разработчикам?");
                builder = builder.Call<AndroidJavaObject>("setPositiveButton", "Да", sendReportClickListenerProxy);
                builder = builder.Call<AndroidJavaObject>("setNegativeButton", "Нет", cancelReportClickListenerProxy);

                var alert = builder.Call<AndroidJavaObject>("create");
                alert.Call("show");
            }

            isHasBeenException = true;
        }

        private class SendReportClickListenerProxy : AndroidJavaProxy
        {
            private readonly string exceptionName;

            private readonly string message;

            private readonly string stackTrace;

            public SendReportClickListenerProxy(string exceptionName, string message, string stackTrace)
                : base("android.content.DialogInterface$OnClickListener")
            {
                this.exceptionName = exceptionName;
                this.message = message;
                this.stackTrace = stackTrace;
            }

            private void onClick(AndroidJavaObject dialog, int arg)
            {
                var activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                var activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

                var info = new AndroidJavaObject("android.app.ApplicationErrorReport$CrashInfo");
                info.Set("exceptionClassName", exceptionName);
                info.Set("exceptionMessage", message);
                info.Set("stackTrace", stackTrace);
                //info.Set("throwFileName", stackTrace.GetFrame(0).GetFileName());
                //info.Set("throwClassName", stackTrace.GetFrame(0).GetMethod().DeclaringType.Name);
                //info.Set("throwMethodName", stackTrace.GetFrame(0).GetMethod().Name);
                //info.Set("throwLineNumber", stackTrace.GetFrame(0).GetFileLineNumber());

                var report = new AndroidJavaObject("android.app.ApplicationErrorReport");
                report.Set("packageName", Application.bundleIdentifier);
                report.Set("processName", Application.bundleIdentifier);
                report.Set("time", (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
                report.Set("type", 1);
                report.Set("systemApp", false);
                report.Set("crashInfo", info);

                var intent = new AndroidJavaObject("android.content.Intent", "android.intent.action.APP_ERROR");
                intent.Call<AndroidJavaObject>("putExtra", "android.intent.extra.BUG_REPORT", report);

                activity.Call("startActivity", intent);

                // .. close
            }
        }

        private class CancelReportClickHandlerProxy : AndroidJavaProxy
        {
            public CancelReportClickHandlerProxy()
                : base("android.content.DialogInterface$OnClickListener")
            {

            }

            private void onClick(AndroidJavaObject dialog, int arg)
            {
                Application.Quit();
            }
        }

#endif

    }
}
