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

    public void Awake()
    {
        userData.FillUserDictionary();
    }
    private void Start()
    {
        // Asegurarse de que el mensaje esté oculto al inicio.
        HideMessage();
    }
    private void Update()
    {
        userData.FillUserDictionary();
    }


    public void OnLoginButtonClicked()
    {
        // Oculta el mensaje anterior si estaba visible.
        HideMessage();

        string enteredUsername = usernameInputField.text;
        string enteredPassword = passwordInputField.text;

        // Verificar si userData tiene algún usuario registrado
        if (userData.userDictionary.Count > 0)
        {
            // Verificar si el usuario ingresado existe en el Dictionary
            if (userData.userDictionary.ContainsKey(enteredUsername))
            {
                string storedPassword = userData.userDictionary[enteredUsername];
                // Comparar la contraseña ingresada con la contraseña almacenada (aplicar hash a la contraseña ingresada)
                if (enteredPassword == storedPassword)
                {
                    // Contraseña correcta: carga la escena principal
                    ShowMessage("Bienvenido " + enteredUsername);
                    StartCoroutine(LoadMainSceneAfterDelay());
                }
                else
                {
                    // Contraseña incorrecta: mostrar mensaje
                    ShowMessage("Contraseña incorrecta");
                }
            }
            else
            {
                // El usuario ingresado no está registrado: mostrar mensaje
                ShowMessage("Usuario no encontrado");
            }
        }
        else
        {
            // No hay usuarios registrados: mostrar mensaje
            ShowMessage("No hay usuarios registrados");
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
