using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Command : MonoBehaviour
    {
        public virtual void Execute(object parameter)
        {

        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }
    }
}