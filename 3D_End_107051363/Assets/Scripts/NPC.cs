using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;



    public bool playerInArea;
    public enum NPCState
    {
        FirstDialog, Missioning, Finish
    }

    [Header("NPC 狀態")]
    public NPCState state = NPCState.FirstDialog;



    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "騎士")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "騎士")
        {
            playerInArea = false;
           
        }
    }

    private void StopDialog()
    {
        dialog.SetActive(false);    
        StopAllCoroutines();        
    }


    private IEnumerator Dialog() 
    {
        dialog.SetActive(true);

        textContent.text = "";

        textName.text = name;

        string dialogString = data.dialogB;

        switch (state)
        {
            case NPCState.FirstDialog:
                dialogString = data.dialogA;
                break;
            case NPCState.Missioning:
                dialogString = data.dialogB;
                break;
            case NPCState.Finish:
                dialogString = data.dialogC;
                break;
        }


        for (int i = 0; i < dialogString.Length; i++)
        {
             
            textContent.text += dialogString[i] + "";
            yield return new WaitForSeconds(interval);
        }


    }
}
