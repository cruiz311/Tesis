using UnityEngine;

public class CameraController:MonoBehaviour
{
    public WebCamTexture webcamTexture;

    void Start()
    {
        // Obtener todas las cámaras disponibles en el dispositivo
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length > 0)
        {
            // Seleccionar la primera cámara disponible (puedes elegir otra si prefieres)
            webcamTexture = new WebCamTexture(devices[0].name);
            // Asignar la textura de la cámara a un material por ejemplo
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.material.mainTexture = webcamTexture;

            // Iniciar la visualización de la cámara
            webcamTexture.Play();
        }
        else
        {
            Debug.Log("No se encontraron cámaras disponibles en el dispositivo.");
        }
    }

    void Update()
    {
        // Aquí puedes agregar lógica adicional si necesitas interactuar con la entrada de la cámara en tiempo real
    }
}
