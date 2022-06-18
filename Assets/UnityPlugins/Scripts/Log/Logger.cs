using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityPlugins {

    public class Logger
    {
        public static void Log(string tag, string content)
        {
            Debug.Log(string.Format("{0}: {1}", tag, content));
        }

        public static void LogWarning(string tag, string content)
        {
            Debug.LogWarning(string.Format("{0}: {1}", tag, content));
        }

        public static void LogError(string tag, string content)
        {
            Debug.LogError(string.Format("{0}: {1}", tag, content));
        }
    }
}
