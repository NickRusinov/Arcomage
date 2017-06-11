using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Framework.Android
{
    public class AndroidAuthorization : Authorization
    {
        //private static readonly string authorizationScope = "oauth2:" +
        //    "https://www.googleapis.com/auth/userinfo.email";

        private static string authorizationToken;

        public override string GetAuthorizationHeader()
        {
            return "AndroidAuthorization";
        }

        public override string GetAuthorizationToken()
        {
            if (authorizationToken != null)
                return authorizationToken;

            try
            {
                Debug.Log("Получение токена акторизации");
                Debug.Log("Получение списка аккаунтов пользователя");

                var activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                var activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

                var accountManagerClass = new AndroidJavaClass("android.accounts.AccountManager");
                var accountManager = accountManagerClass.CallStatic<AndroidJavaObject>("get", activity);
                var accountArrayObject = accountManager.Call<AndroidJavaObject>("getAccountsByType", "com.google");
                var accountArray = AndroidJNIHelper.ConvertFromJNIArray<AndroidJavaObject[]>(accountArrayObject.GetRawObject());

                if (accountArray.Length == 0)
                {
                    Debug.Log("Не найдено ни одного аккаунта пользователя");

                    var authorizationOkClickListenerProxy = new AuthorizationOkClickListenerProxy();
                    var builder = new AndroidJavaObject("android.app.AlertDialog$Builder", activity);
                    builder = builder.Call<AndroidJavaObject>("setCancelable", false);
                    builder = builder.Call<AndroidJavaObject>("setTitle", "Авторизация");
                    builder = builder.Call<AndroidJavaObject>("setMessage", "Вы не авторизованы в вашем google аккаунте");
                    builder = builder.Call<AndroidJavaObject>("setNegativeButton", "OK", authorizationOkClickListenerProxy);

                    var alert = builder.Call<AndroidJavaObject>("create");
                    alert.Call("show");

                    return authorizationToken = "";
                }

                Debug.LogFormat("Получено {0} аккаунтов пользователя", accountArray.Length);
                Debug.Log("Получение токена авторизации для аккаунта пользователя");
                
                var account = accountArray[0];
                var token = account.Get<string>("name");

                //var googleAuthUtilsClass = new AndroidJavaClass("com.google.android.gms.auth.GoogleAuthUtil");
                //var token = googleAuthUtilsClass.CallStatic<string>("getToken", activity, account, authorizationScope);

                Debug.Log("Получен токен авторизации для аккаунта пользователя");

                return authorizationToken = token;
            }
            catch (Exception e)
            {
                Debug.LogWarningFormat("Ошибка при получении токена авторизации: {0}", e);

                throw;
            }
        }

        private class AuthorizationOkClickListenerProxy : AndroidJavaProxy
        {
            public AuthorizationOkClickListenerProxy()
                : base("android.content.DialogInterface$OnClickListener")
            {

            }

            private void onClick(AndroidJavaObject dialog, int arg)
            {
                dialog.Call("cancel");
            }
        }
    }
}
