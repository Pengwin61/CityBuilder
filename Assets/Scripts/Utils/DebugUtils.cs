using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    /// <summary>
    /// Контекст логгирования. Битовая маска(аналогично слоям в юнити)
    /// Каждый контекст должен быть равен степени числа 2.
    /// Эта степень не должна превышать максимально возможный int - 2 147 483 647
    /// Таким образом максимальное количество контекстов 32 (2^0 - 2^31)
    /// </summary>
    [Flags]
    public enum LogContext
    {
        General = 1 << 0,
        Loading = 1 << 1
    }

    public class DebugUtils : Debug
    {

        public static LogContext logContext = 0;

        public static void Log(string message, LogContext context = LogContext.General)
        {
            Debug.Log(AddContext(message, context));
        }

        public static void LogWarning(string message, LogContext context = LogContext.General)
        {
            Debug.LogWarning(AddContext(message, context));
        }

        public static void LogError(string message, LogContext context = LogContext.General)
        {
            Debug.LogError(AddContext(message, context));
        }

        public static void LogList<T>(IEnumerable<T> list, string message, LogContext context = LogContext.General)
        {
            message = GetListMessage(list, message);
            Debug.Log(AddContext(message, context));
        }

        public static void LogListWarning<T>(IEnumerable<T> list, string message, LogContext context = LogContext.General)
        {
            message = GetListMessage(list, message);
            Debug.LogWarning(AddContext(message, context));
        }

        public static void LogListError<T>(IEnumerable<T> list, string message, LogContext context = LogContext.General)
        {
            message = GetListMessage(list, message);
            Debug.LogError(AddContext(message, context));
        }

        private static string GetListMessage<T>(IEnumerable<T> list, string message)
        {
            string text = message;
            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is GameObject)
                {
                    text = $"{text}<{(enumerator.Current as GameObject).name}>";
                }
                else
                {
                    text = $"{text}<{enumerator.Current}>";
                }
            }
            return text;
        }

        private static string AddContext(string message, LogContext context)
        {
            if (context != LogContext.General)
            {
                message = $"[{context}] {message}";
            }
            return message;
        }
    }
}