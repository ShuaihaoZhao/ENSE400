using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    private GameObject knight_target;

    private Dialogue temp_dia;

    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        
        knight_target = GameObject.FindGameObjectWithTag("Kn");
        sentences = new Queue<string>();

	}
	
	public void StartDialogue(Dialogue dialogue)
    {
        temp_dia = dialogue;//copy the class value
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence ()
    {
        Debug.Log(sentences.Count);
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        //StopAllCoroutines();
       //StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

        if (temp_dia.GetType() == "B" && temp_dia.Get_Dialogue_condition()== true)
        {
            knight_target.GetComponent<Player_stats>().Heal(10);
        }

        if (temp_dia.GetType() == "G" && temp_dia.Get_Dialogue_condition() == true)
        {
            knight_target.GetComponent<Attack>().Unloack_attack();
        }

        temp_dia.Set_Dialogue_condition(false);
    }
}
