using UnityEngine;
using System.IO;


public class SaveManager:MonoBehaviour
{
    public PlayerData playerData; // Tu Scriptable Object
    private string dataPath;
    private void Awake()
    {
        dataPath = Application.persistentDataPath + "/playerData.json";
    }
    private void OnApplicationQuit()
    {
        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(dataPath, jsonData);
    }
}
