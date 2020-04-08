using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Queue<string> _sentences;

    public Text _speakerName, _textToSay;
    Animator _animator;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentences();
        }
    }
    public void StartDialogue(Dialogue _dialogue)
    {
        _animator.SetBool("IsOpenned", true);
        _speakerName.text = _dialogue._nameOfTheSpeaker;

        _sentences.Clear();
        foreach(string sentences in _dialogue._sentences)
        {
            _sentences.Enqueue(sentences); 
        }
        DisplayNextSentences();
    }

    public void DisplayNextSentences()
    {
        if(_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentences = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences));
    }

    IEnumerator TypeSentence(string sentence)
    {
        _textToSay.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            _textToSay.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        Debug.Log("End of the dialogue");
        _animator.SetBool("IsOpenned", false);
        _speakerName.text = "";
        _textToSay.text = "";
    }
}
