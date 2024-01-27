using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.StickyNote;

public class TextInteractable : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBox;

    [SerializeField]
    private string text;

    [SerializeField]
    private TextMeshProUGUI textObject;

    [SerializeField]
    private GameObject objectHighlight;
    // Start is called before the first frame update



    private bool inCollider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectHighlight.SetActive(true);
        inCollider = true;
        StartCoroutine(CheckForButtonPress());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectHighlight.SetActive(false);
        inCollider = false;
        dialogueBox.SetActive(false);
        textObject.enabled = dialogueBox.activeInHierarchy;
        StopCoroutine(CheckForButtonPress());
    }



    private IEnumerator CheckForButtonPress()
    {
        while (inCollider)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                textObject.text = text;
                dialogueBox.SetActive(!dialogueBox.activeInHierarchy);
                textObject.enabled = dialogueBox.activeInHierarchy;
            }

            yield return null;
        }
    }


}
