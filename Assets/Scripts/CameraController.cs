using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public RawImage rawImage; // Asigna la imagen del Canvas en el Inspector

    // Enum para representar la direcci�n de la c�mara
    public enum CameraFacingDirection
    {
        Front,
        Back
    }
    private WebCamTexture webcamTexture;

    void Start()
    {
        // Obtener una lista de dispositivos de c�mara disponibles
        WebCamDevice[] devices = WebCamTexture.devices;

        // Buscar la c�mara posterior
        WebCamDevice selectedCamera = SelectCamera(devices, CameraFacingDirection.Back);

        // Si no se encontr� la c�mara posterior, buscar la c�mara delantera
        if (selectedCamera.name == null)
        {
            selectedCamera = SelectCamera(devices, CameraFacingDirection.Front);
        }

        // Verificar si se encontr� alguna c�mara disponible
        if (selectedCamera.name != null)
        {
            // Crear una textura de c�mara con la c�mara seleccionada
            webcamTexture = new WebCamTexture(selectedCamera.name);

            // Redimensionar la textura de la c�mara para que coincida con el tama�o de la imagen
            webcamTexture.requestedWidth = (int)rawImage.rectTransform.rect.width;
            webcamTexture.requestedHeight = (int)rawImage.rectTransform.rect.height;

            // Asignar la textura de la c�mara al RawImage del Canvas
            if (rawImage != null)
            {
                rawImage.texture = webcamTexture;
            }

            // Comenzar la transmisi�n de la c�mara
            webcamTexture.Play();
        }
        else
        {
            Debug.Log("No hay c�mara disponible.");
        }
    }

    // Resto del c�digo igual que antes...

    // Funci�n para buscar la c�mara seg�n la direcci�n especificada
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
        return new WebCamDevice(); // Devolver una instancia vac�a si no se encuentra ninguna c�mara
    }
}
