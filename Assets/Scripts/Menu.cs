using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    //Camaras
    public PlayableDirector director; // Arrastra el PlayableDirector aquí desde el Inspector.
    public Button boton; // Arrastra el botón aquí desde el Inspector.

    //Button
    public float TiempoBoton = 2.0f; // Tiempo actual del temporizador
    private Image botonImage;
    private Color colorButton;
    public TMP_Text tmpText;

    //Panel
    public GameObject Panel; // Assign in inspector panel
    [SerializeField] TextMeshProUGUI carta;
    public float textSpeed = 0.1f;
    public string[] lines;
   
    //State
    private bool PlayState = false;

    // Start is called before the first frame update
    void Start()
    {
        // Asegúrate de que has asignado un botón en el Inspector.
        if (boton != null)
        {
            // Obtiene la imagen asociada al botón (la imagen que representa su apariencia).
            botonImage = boton.GetComponent<Image>();
            // Obtiene el color actual de la imagen.
            colorButton = botonImage.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayState == true)
        {
            // Resta el tiempo del frame actual del tiempo total
            TiempoBoton -= Time.deltaTime;
            // Establece el nuevo valor alfa.
            colorButton.a = TiempoBoton;
            // Asigna el color modificado de vuelta a la imagen del botón.
            botonImage.color = colorButton;

            tmpText.color = new(0f,0f,0f,TiempoBoton);
            if (TiempoBoton < 0)
            {
                PlayState = false;
                Panel.SetActive(true);
                StartDialogue();
            }
        }
    }

    public void Play()
    {
        
        director.Play(); // Esto activará la animación cuando se inicie el juego o cuando se ejecute este método.
        if (TiempoBoton > 0)
        {
            Debug.Log(TiempoBoton);
        }

        PlayState = true;
    }


    public void StartDialogue(){ 
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine(){
        foreach (char letter in lines[0].ToCharArray())
        {
            carta.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void CargarNovela(){
        SceneManager.LoadScene("E1");
    }
}
