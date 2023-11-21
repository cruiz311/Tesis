using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataBase", menuName = "ScriptableObject/PlayerDataBase", order = 1)]
public class PlayerData : ScriptableObject
{
    public Dictionary<string, string> userDictionary = new Dictionary<string, string>();
    public List<PlayerCredentials> users = new List<PlayerCredentials>();
    public void FillUserDictionary()
    {
        foreach (var user in users)
        {
            if (!userDictionary.ContainsKey(user.username))
            {
                // Agregar entrada al diccionario solo si la clave no existe
                userDictionary.Add(user.username, user.password);
            }
        }
        Debug.Log(userDictionary.Count);
    }
}

[System.Serializable]
public class PlayerCredentials
{
    public string username;
    public string password;

    public string getUsername()
    {
        return username;
    }
}
