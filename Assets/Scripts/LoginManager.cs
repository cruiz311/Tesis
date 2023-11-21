using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoginManager : MonoBehaviour
{
    public PlayerData userData;
    public InputField usernameInputField;
    public InputField passwordInputField;
    public Text messageText; // Referencia al objeto de texto para mostrar mensajes.

    Hashtable userHashTable = new Hashtable();
    private bool showMessage = false;

    private void Start()
    {
        // Asegurarse de que el mensaje esté oculto al inicio.
        HideMessage();
        userHashTable.Add("username", "john_d");
        userHashTable.Add("password", "sdasd");
    }
    private void Update()
    {
        Debug.Log("username: "+ userData.users[0].username);
        Debug.Log("password: "+ userData.users[0].password);
    }

    public void OnLoginButtonClicked()
    {
        // Oculta el mensaje anterior si estaba visible.
        HideMessage();

        string enteredUsername = usernameInputField.text;
        string enteredPassword = passwordInputField.text;

        if (enteredUsername == userData.users[0].username && enteredPassword == userData.users[0].password)
        {
            // Muestra un mensaje de inicio de sesión exitoso.
            ShowMessage("Inicio de sesión exitoso. Redirigiendo...");

            // Espera unos segundos antes de cargar la escena principal.
            StartCoroutine(LoadMainSceneAfterDelay());
        }
        else
        {
            // Los datos no coinciden, muestra un mensaje de error.
            ShowMessage("Nombre de usuario o contraseña incorrectos");
        }
    }

    IEnumerator LoadMainSceneAfterDelay()
    {
        // Espera 2 segundos antes de cargar la escena principal.
        yield return new WaitForSeconds(2.0f);

        // Carga la escena principal.
        SceneManager.LoadScene("MainScene");
    }

    private void ShowMessage(string text)
    {
        messageText.text = text;
        messageText.gameObject.SetActive(true);
        showMessage = true;
        // Oculta el mensaje después de 2 segundos.
        StartCoroutine(HideMessageAfterDelay());
    }

    private void HideMessage()
    {
        messageText.gameObject.SetActive(false);
        showMessage = false;
    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(2.0f);
        if (showMessage)
        {
            HideMessage();
        }
    }
}
