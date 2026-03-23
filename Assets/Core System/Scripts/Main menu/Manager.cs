using CoreSystem.Configuration;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CoreSystem.MainMenu
{
    public class Manager : MonoBehaviour
    {
        public static Manager Instance { get; private set; }

        private void setSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        //private GameConfiguration configuration;

        private void Awake()
        {
            setSingleton();
        }

        public void Exit()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}