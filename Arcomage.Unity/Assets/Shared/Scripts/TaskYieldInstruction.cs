using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public class TaskYieldInstruction : CustomYieldInstruction
    {
        private readonly Task task;

        public TaskYieldInstruction(Task task)
        {
            this.task = task;
        }

        public override bool keepWaiting
        {
            get { return !task.IsCompleted; }
        }
    }
}
