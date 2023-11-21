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
    private bool showMessage = false;

    private void Start()
    {
        // Asegurarse de que el mensaje esté oculto al inicio.
        HideMessage();
    }
    private void Update()
    {
        if (userData.users.Count > 0)
        {
            Debug.Log("username: " + userData.users[0].username);
            Debug.Log("password: " + userData.users[0].password);
        }
    }

    public void OnLoginButtonClicked()
    {
        // Oculta el mensaje anterior si estaba visible.
        HideMessage();

        string enteredUsername = usernameInputField.text;
        string enteredPassword = passwordInputField.text;

        if (userData.users.Count > 0)
        {
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
        else
        {
            ShowMessage("No hay ninguna cuenta registrada");
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
