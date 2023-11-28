using UnityEngine;
using System.IO;

public class LoadManager:MonoBehaviour
{
    public PlayerData playerData; // Tu Scriptable Object

    public string dataPath;

    private void Awake()
    {
        dataPath = Application.persistentDataPath + "/playerData.json";
        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        if (File.Exists(dataPath))
        {
            string jsonData = File.ReadAllText(dataPath);
            JsonUtility.FromJsonOverwrite(jsonData, playerData);
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo JSON.");
        }
    }
}
