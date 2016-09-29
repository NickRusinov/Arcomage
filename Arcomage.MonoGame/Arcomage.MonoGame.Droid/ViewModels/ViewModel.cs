using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public abstract class ViewModel
    {
        protected T Set<T>(T oldValue, T newValue, Action<T, T> changeAction = null)
        {
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
                changeAction?.Invoke(oldValue, newValue);

            return newValue;
        }
    }
}
