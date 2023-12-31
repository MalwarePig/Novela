using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PantallaNegra : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI carta;
    public float textSpeed = 0.1f;
    public string[] lines;

    // Start is called before the first frame update
    void Start() {
        StartDialogue();
     }

    // Update is called once per frame
    void Update() { }

    public void StartDialogue()
    {
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        foreach (char letter in lines[0].ToCharArray())
        {
            carta.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }
    }
}
