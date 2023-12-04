import socket

# Configurar el socket
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.bind(('localhost', 5555))  # IP y puerto a los que se conectará Unity
server_socket.listen(5)  # Escuchar hasta 5 conexiones entrantes

print("Esperando la conexión de Unity...")
client_socket, addr = server_socket.accept()  # Aceptar la conexión

print("Conexión establecida con Unity:", addr)

# Envío de datos a Unity
data_to_send = "¡Hola omar te saludo desde Python!"
client_socket.sendall(data_to_send.encode())

# Cerrar la conexión
client_socket.close()
server_socket.close()
