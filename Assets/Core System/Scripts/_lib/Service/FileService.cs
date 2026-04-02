using CoreSystem.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CoreSystem.Persistent
{
    public static class FileService
    {
        /// <summary>
        /// Load data with the given path, if the file is not exist, create a new one and save it to the path, then return the new data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>

        public static T LoadOrCreate<T>(string path) where T : new()
        {
            if (!File.Exists(path))
            {
                var data = new T();
                SaveJsonFile(path, data);
                return data;
            }

            string json = File.ReadAllText(path);

            if (string.IsNullOrEmpty(json))
                return new T();

            return JsonUtility.FromJson<T>(json);
        }

        /// <summary>
        /// Load data with the given path
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param> the path file
        /// <returns></returns>
        public static T Load<T>(string path)
        {
            if (!File.Exists(path))
                return default;

            string json = File.ReadAllText(path);

            if (string.IsNullOrEmpty(json))
                return default;

            return JsonUtility.FromJson<T>(json);
        }

        /// <summary>
        /// Load data with the given path, if the file is not exist or empty, return new T() instead of default(T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T LoadOrDefault<T>(string path) where T : new()
        {
            if (!File.Exists(path))
                return new T();

            try
            {
                string json = File.ReadAllText(path);

                if (string.IsNullOrEmpty(json))
                    return new T();

                return JsonUtility.FromJson<T>(json) ?? new T();
            }
            catch
            {
                Debug.LogError($"Load failed: {path}");
                return new T();
            }
        }

        /// <summary>
        /// save data to the given path, if the folder is not exist, it will be created automatically
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public static void SaveJsonFile<T>(string path, T data)
        {
            string folder = Path.GetDirectoryName(path);

            Directory.CreateDirectory(folder);

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// delete the folder at the given path
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFolder(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
    }
}

