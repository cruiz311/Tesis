using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public RawImage rawImage; // Asigna la imagen del Canvas en el Inspector

    // Enum para representar la dirección de la cámara
    public enum CameraFacingDirection
    {
        Front,
        Back
    }
    private WebCamTexture webcamTexture;

    void Start()
    {
        // Obtener una lista de dispositivos de cámara disponibles
        WebCamDevice[] devices = WebCamTexture.devices;

        // Buscar la cámara posterior
        WebCamDevice selectedCamera = SelectCamera(devices, CameraFacingDirection.Back);

        // Si no se encontró la cámara posterior, buscar la cámara delantera
        if (selectedCamera.name == null)
        {
            selectedCamera = SelectCamera(devices, CameraFacingDirection.Front);
        }

        // Verificar si se encontró alguna cámara disponible
        if (selectedCamera.name != null)
        {
            // Crear una textura de cámara con la cámara seleccionada
            webcamTexture = new WebCamTexture(selectedCamera.name);

            // Redimensionar la textura de la cámara para que coincida con el tamaño de la imagen
            webcamTexture.requestedWidth = (int)rawImage.rectTransform.rect.width;
            webcamTexture.requestedHeight = (int)rawImage.rectTransform.rect.height;

            // Asignar la textura de la cámara al RawImage del Canvas
            if (rawImage != null)
            {
                rawImage.texture = webcamTexture;
            }

            // Comenzar la transmisión de la cámara
            webcamTexture.Play();
        }
        else
        {
            Debug.Log("No hay cámara disponible.");
        }
    }

    // Resto del código igual que antes...

    // Función para buscar la cámara según la dirección especificada
    private WebCamDevice SelectCamera(WebCamDevice[] devices, CameraFacingDirection facingDirection)
    {
        foreach (WebCamDevice device in devices)
        {
            if ((facingDirection == CameraFacingDirection.Front && device.isFrontFacing) ||
                (facingDirection == CameraFacingDirection.Back && !device.isFrontFacing))
            {
                return device;
            }
        }
        return new WebCamDevice(); // Devolver una instancia vacía si no se encuentra ninguna cámara
    }
}
