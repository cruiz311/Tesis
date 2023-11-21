import cv2
import mediapipe as mp
import os
import numpy as np

# Directorio base donde se guardarán las imágenes para el entrenamiento
base_dir = 'C:/Users/User/Desktop/tesis/PhytonDoc/Fotos/validacion/A'

# Inicialización de la cámara
cap = cv2.VideoCapture(0)

# Inicialización de MediaPipe
mp_hands = mp.solutions.hands
hands = mp_hands.Hands()
mp_drawing = mp.solutions.drawing_utils

# Diccionario para contar las imágenes guardadas por cada mano
manos_guardadas = {}

while True:
    ret, frame = cap.read()
    if not ret:
        break

    color = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
    results = hands.process(color)

    if results.multi_hand_landmarks:
        for idx, hand_landmarks in enumerate(results.multi_hand_landmarks):
            # Carpeta donde se guardarán las imágenes
            carpeta = base_dir

            # Contar imágenes guardadas por esta mano
            if idx not in manos_guardadas:
                manos_guardadas[idx] = 0

            # Obtener las coordenadas de los landmarks de la mano
            coordenadas_landmarks = []
            for lm in hand_landmarks.landmark:
                alto, ancho, c = frame.shape
                corx, cory = int(lm.x * ancho), int(lm.y * alto)
                coordenadas_landmarks.append([corx, cory])

            # Calcular el rectángulo delimitador de la mano
            x, y, w, h = cv2.boundingRect(np.array(coordenadas_landmarks))

            # Dibujar la mano y obtener la región de interés
            mp_drawing.draw_landmarks(frame, hand_landmarks, mp_hands.HAND_CONNECTIONS)
            hand_img = frame[y:y + h, x:x + w]

            # Guardar la imagen de la mano en la carpeta correspondiente
            if manos_guardadas[idx] < 50:  # Guardar solo 50 imágenes por mano
                cv2.imwrite(os.path.join(carpeta, f"Mano_{idx}_{manos_guardadas[idx]}.jpg"), hand_img)
                print(f"Imagen de mano guardada en {carpeta}")
                manos_guardadas[idx] += 1

    cv2.imshow("Detección de manos", frame)

    if cv2.waitKey(1) & 0xFF == 27:
        break

hands.close()
cap.release()
cv2.destroyAllWindows()
