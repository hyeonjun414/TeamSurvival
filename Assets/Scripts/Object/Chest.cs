using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    GameManager gm;

    [TextArea]
    public string[] conversation;
    int converIndex = 0;

    bool isCoroutine = false;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public bool Interaction()
    {
        if (converIndex < conversation.Length)
        {
            print("상자와 상호작용");
            gm.SetActiveDialog(true);
            if (isCoroutine)
            {
                gm.SetDialogContent("상자", conversation[converIndex]);
                StopAllCoroutines();
                NextText();
            }
            StartCoroutine(ConverEffect(conversation[converIndex]));

            
            return true;
        }
        else
        {
            NextText();
            gm.SetActiveDialog(false);
            return false;
        }
    }
    IEnumerator ConverEffect(string curText)
    {
        print("대화 시작");
        gm.discText.text = "";
        isCoroutine = true;
        foreach(char ch in curText)
        {
            gm.discText.text += ch;
            yield return new WaitForSeconds(0.1f);
        }
        isCoroutine = false;
        NextText();
        yield return null;
    }
    void NextText()
    {
        if (converIndex == conversation.Length)
        {
            converIndex = 0;
        }
        else
        {
            converIndex++;
        }
        
    }
}
