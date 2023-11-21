using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PlayerDataBase", menuName = "ScriptableObject/PlayerDataBase", order = 1)]
public class PlayerData :ScriptableObject
{
    public Hashtable userHashTable = new Hashtable();
    public List<playerData> users = new List<playerData>();
    public void FillUserHashTable()
    {
        //foreach(var user in PlayerData.users)
        //{

        //}
    }


}

[Serializable]
public class playerData
{
    public string username;
    public string password;
}

public struct UserCredentials
{
    public string username;
    public string password;

    public UserCredentials(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}
