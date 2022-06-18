using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityPlugins {

    public class Application : MonoBehaviour
    {
        void Start()
        {
            Logger.Log(TAG, "Application Start");
            Logger.LogWarning(TAG, "Application Start");
            Logger.LogError(TAG, "Application Start");
        }

        private static string TAG = "Application";
    }
}
