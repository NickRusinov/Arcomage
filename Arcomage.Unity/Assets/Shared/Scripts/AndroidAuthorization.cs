using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public class AndroidAuthorization : Authorization
    {
        //private static readonly string authorizationScope = "oauth2:" +
        //    "https://www.googleapis.com/auth/userinfo.email";

        private string authorizationToken;

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

                var activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                var activity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

                Debug.Log("Получение списка аккаунтов пользователя");

                var accountManagerClass = new AndroidJavaClass("android.accounts.AccountManager");
                var accountManager = accountManagerClass.CallStatic<AndroidJavaObject>("get", activity);
                var accountArrayObject = accountManager.Call<AndroidJavaObject>("getAccountsByType", "com.google");
                var accountArray = AndroidJNIHelper.ConvertFromJNIArray<AndroidJavaObject[]>(accountArrayObject.GetRawObject());

                Debug.LogFormat("Получено {0} аккаунтов пользователя", accountArray.Length);

                // TODO 
                var account = accountArray[0];

                Debug.Log("Получение токена авторизации для аккаунта пользователя");

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
    }
}
