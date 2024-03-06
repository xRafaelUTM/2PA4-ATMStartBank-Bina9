import cv2
from pyzbar.pyzbar import decode
import pyperclip

def leer_codigo_barras():
    #Inicia camara
    cap = cv2.VideoCapture(0)
    cap.set(3, 640)  #Ancho
    cap.set(4, 480)  #Alto

    #Bucle para leer los FRAMES 
    while True:
        success, frame = cap.read()
        if not success:
            break

        #Codifica los y espera codigo
        for barcode in decode(frame):
            #Convierte a texto
            codigo_barras = barcode.data.decode('utf-8')
            
            #Copia al porta papeles
            pyperclip.copy(codigo_barras)
            
            #Cierra la camara
            cap.release()
            cv2.destroyAllWindows()
            return  #Salir

        # Muestra el frame en una ventana
        cv2.imshow('LECTOR DE BARRAS by RAFITA', frame)
        if cv2.waitKey(1) & 0xFF == ord('q'):  # Sale con la tecla 'q'
            break

    # Limpieza
    cap.release()
    cv2.destroyAllWindows()

if __name__ == "__main__":
    leer_codigo_barras()
