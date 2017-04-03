﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public class TaskBinding<T>
    {
        private readonly Task<T> task;

        private Action<Task<T>> successHandlers;

        private Action<Task<T>> failureHandlers;

        private Action<Task<T>> cancelHandlers;

        public TaskBinding(Task<T> task)
        {
            this.task = task;
        }

        public TaskBinding<T> OnComplete(Action<Task<T>> completeHandler)
        {
            successHandlers += completeHandler;
            failureHandlers += completeHandler;
            cancelHandlers += completeHandler;

            return this;
        }

        public TaskBinding<T> OnSuccess(Action<Task<T>> successHandler)
        {
            successHandlers += successHandler;

            return this;
        }

        public TaskBinding<T> OnFailure(Action<Task<T>> failureHandler)
        {
            failureHandlers += failureHandler;

            return this;
        }

        public TaskBinding<T> OnCancel(Action<Task<T>> cancelHandler)
        {
            cancelHandlers += cancelHandler;

            return this;
        }

        public IEnumerator StartCoroutine()
        {
            yield return new TaskYieldInstruction(task);

            if (task.Status == TaskStatus.RanToCompletion && successHandlers != null)
                successHandlers.Invoke(task);

            if (task.Status == TaskStatus.Faulted && failureHandlers != null)
                failureHandlers.Invoke(task);

            if (task.Status == TaskStatus.Canceled && cancelHandlers != null)
                cancelHandlers.Invoke(task);
        }
    }
}