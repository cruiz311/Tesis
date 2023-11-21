using UnityEngine;

public class CameraController:MonoBehaviour
{
    public WebCamTexture webcamTexture;

    void Start()
    {
        // Obtener todas las c�maras disponibles en el dispositivo
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length > 0)
        {
            // Seleccionar la primera c�mara disponible (puedes elegir otra si prefieres)
            webcamTexture = new WebCamTexture(devices[0].name);
            // Asignar la textura de la c�mara a un material por ejemplo
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.material.mainTexture = webcamTexture;

            // Iniciar la visualizaci�n de la c�mara
            webcamTexture.Play();
        }
        else
        {
            Debug.Log("No se encontraron c�maras disponibles en el dispositivo.");
        }
    }

    void Update()
    {
        // Aqu� puedes agregar l�gica adicional si necesitas interactuar con la entrada de la c�mara en tiempo real
    }
}
