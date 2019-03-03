using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    private GameObject knight;

    public void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Kn");
    }

    private void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, knight.transform.position));
        if (Vector3.Distance(transform.position, knight.transform.position) <= 10f && Input.GetKeyDown(KeyCode.F))
        {
            TriggerDialouge();
        }
    }

    public void TriggerDialouge()
    {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }
}
