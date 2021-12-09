using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoManager : MonoBehaviour
{
    public GameObject colisão1, colisão2, colisão3;

    public GameObject dialogo;

    public Text nomeText;
    public Text dialogoText;

    private DialogoColisão dialogoColisao;
    private MenuDePause menuDePause;

    private Queue<string> frases;
    // Start is called before the first frame update
    void Start()
    {
        dialogoColisao = FindObjectOfType<DialogoColisão>().GetComponent<DialogoColisão>();
        menuDePause = FindObjectOfType<MenuDePause>().GetComponent<MenuDePause>();

        frases = new Queue<string>();
    }

    public void StartDialogo (Dialogo dialogo)
    {
        nomeText.text = dialogo.name;

        frases.Clear();

        foreach(string frase in dialogo.frases)
        {
            frases.Enqueue(frase);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (frases.Count == 0)
        {
            EndDialogo();
            return;
        }

        string frase = frases.Dequeue();
        dialogoText.text = frase;
    }

    public void EndDialogo()
    {
        if (dialogoColisao.NumeroColisão == 1)
        {
            dialogoColisao.dialogoCompleto = true;
            dialogo.SetActive(false);
            colisão1.SetActive(false);
            colisão2.SetActive(true);
        }
        else if (dialogoColisao.NumeroColisão == 2)
        {
            dialogoColisao.dialogoCompleto = true;
            dialogo.SetActive(false);
            colisão2.SetActive(false);
            colisão3.SetActive(true);
        }
    }

    public void SairDialogo()
    {
        dialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogoColisao.dialoEstaAberto == true)
        {
            DisplayNextSentence();
        }

        if (menuDePause.estaNoPause == true)
        {
            SairDialogo();
        }

        
    }
}
