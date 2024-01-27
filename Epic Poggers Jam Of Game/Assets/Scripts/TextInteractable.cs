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

    public float textSpeed;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectHighlight.SetActive(true);
        inCollider = true;
        StopCoroutine(CheckForButtonPress());
        StartCoroutine(CheckForButtonPress());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(CheckForButtonPress());
        textObject.text = "";
        objectHighlight.SetActive(false);
        inCollider = false;
        dialogueBox.SetActive(false);
        textObject.enabled = dialogueBox.activeInHierarchy;
    }



    private IEnumerator CheckForButtonPress()
    {
        while (inCollider)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialogueBox.SetActive(!dialogueBox.activeInHierarchy);
                textObject.enabled = dialogueBox.activeInHierarchy;
                textObject.text = "";
                for (int i = 0; i < text.Length + 1; i++)
                {
                    if (inCollider)
                    {
                        textObject.text = text.Substring(0, i);
                        yield return new WaitForSeconds(textSpeed);
                    }
                    else break;
                }
            }

            yield return null;
        }
    }


}
