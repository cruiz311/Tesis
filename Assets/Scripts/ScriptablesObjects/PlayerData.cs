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
            // Aplicar hash a la contraseña (aquí se usa un ejemplo simple, debes usar un algoritmo de hashing seguro)
            string hashedPassword = HashFunction(user.password);

            // Agregar entrada al diccionario (usuario, contraseña_hasheada)
            userDictionary.Add(user.username, hashedPassword);
        }

        Debug.Log(userDictionary.Count);
    }

    // Ejemplo de función de hash (usa un algoritmo seguro como SHA-256)
    private string HashFunction(string input)
    {
        // Código para aplicar un hash a 'input'
        // Retorna la contraseña hasheada
        return input; // Reemplazar con la función de hashing real
    }
}

[System.Serializable]
public class PlayerCredentials
{
    public string username;
    public string password;
}
