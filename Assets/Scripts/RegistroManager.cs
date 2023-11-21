using UnityEngine;
using UnityEngine.UI;

public class RegistroManager : MonoBehaviour
{
    public PlayerData playerDatabase;
    public InputField usernameInputField;
    public InputField passwordInputField;

    public void RegistrarUsuario()
    {
        // Verifica si el usuario ya existe en la lista
        if (UsuarioExistente(usernameInputField.text))
        {
            Debug.Log("El usuario ya existe.");
            return;
        }
        // Crea una nueva instancia de UserData y agrega los datos
        playerData newUser = new playerData();
        newUser.username = usernameInputField.text;
        newUser.password = passwordInputField.text;
        // Agrega el nuevo usuario a la lista en el ScriptableObject
        playerDatabase.users.Add(newUser);
    }
    private bool UsuarioExistente(string username)
    {
        foreach (var user in playerDatabase.users)
        {
            if (user.username == username)
            {
                return true;
            }
        }
        return false;
    }
}
