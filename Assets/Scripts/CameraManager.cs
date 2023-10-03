using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;  // Array de cámaras disponibles
    private int currentCameraIndex = 0;
 

    private void Start()
    {
        // Desactiva todas las cámaras excepto la primera
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

   /*  private void Update()
    {
        OnMouseDown();
    }

    private void OnMouseDown() { 
        
    } */

    public void NextScene(){
        Debug.Log("Cambio");
        // Cambia de cámara cuando se presiona la tecla deseada (por ejemplo, la tecla "C")
        cameras[currentCameraIndex].gameObject.SetActive(false);
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        cameras[currentCameraIndex].gameObject.SetActive(true); 
    }

     
}
