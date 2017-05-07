using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Framework.Editor
{
    public class UnityAuthorization : Authorization
    {
        private string authorizationToken;

        public override string GetAuthorizationHeader()
        {
            return "UnityAuthorization";
        }

        public override string GetAuthorizationToken()
        {
            if (authorizationToken != null)
                return authorizationToken;

            Debug.Log("Получение токена авторизации");

            var token = Guid.NewGuid().ToString("N");

            Debug.Log("Получен токен авторизации для аккаунта пользователя");

            return authorizationToken = token;
        }
    }
}
