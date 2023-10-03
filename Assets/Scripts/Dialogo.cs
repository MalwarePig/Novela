using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI dialogueText;

    public string[] lines;
    private float[] textSpeed = new float[] { 0.08f, 0.06f, 0.07f, 0.2f,0.08f,0.08f,0.08f,0.08f,0.08f,0.08f,0.08f,0.08f};
    int index;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue(); 
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseDown();
    }

    
    private void OnMouseDown() {
        // Detecta si se hace clic con el botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
             Debug.Log("u");
           if (dialogueText.text == lines[index])
            {
                NextLine();
            }else{
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    } 
 

    public void StartDialogue(){
        index = 0; 
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine(){
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed[index]);
        }
    }

    public void NextLine(){
        if(index < lines.Length -1){
            index++;
            dialogueText.text = string.Empty;
            if(index == 3 ||index == 4 ||index == 5||index == 6){
                //Corrutina lenta
                StartCoroutine(LowLine());
            }else{
                StartCoroutine(WriteLine());
            } 
        }else{
            gameObject.SetActive(false);
        }
    }


    IEnumerator LowLine(){
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }


     

}
