using UnityEngine;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System;

public class PythonClient : MonoBehaviour
{
    private TcpClient socketConnection;
    private NetworkStream stream;
    private byte[] buffer;

    void Start()
    {
        StartPythonScript(); // Iniciar el script de Python

        // Conectar al servidor Python
        ConnectToServer();
    }

    void StartPythonScript()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "C:/Users/User/Desktop/Tesis/venv/Scripts/python.exe"; // Ruta al ejecutable de Python
        startInfo.Arguments = "C:/Users/User/Desktop/Tesis/Socket/server.py"; // Ruta a tu script de Python
        Process.Start(startInfo);
    }

    private void ConnectToServer()
    {
        try
        {
            socketConnection = new TcpClient("127.0.0.1", 5555); // IP y puerto del servidor Python
            stream = socketConnection.GetStream();
            buffer = new byte[socketConnection.ReceiveBufferSize];

            StartListening();
        }
        catch (SocketException e)
        {
            UnityEngine.Debug.Log("Socket error: " + e.Message);
        }
    }

    private void StartListening()
    {
        stream.BeginRead(buffer, 0, socketConnection.ReceiveBufferSize, ReadData, null);
    }

    private void ReadData(IAsyncResult ar)
    {
        int bytesRead = stream.EndRead(ar);
        string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

        UnityEngine.Debug.Log("Mensaje recibido desde Python: " + message);

        // Puedes trabajar con el mensaje recibido aquí

        StartListening();
    }
}
