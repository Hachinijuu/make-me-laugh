using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.StickyNote;

public class TextInteractable : MonoBehaviour
{
    public GameObject dialogueBox;
    public JokebookTracker bookTracker;

    [SerializeField]
    private string text;

    public TextMeshProUGUI textObject;

    [SerializeField]
    private GameObject objectHighlight;
    // Start is called before the first frame update
    private void Start()
    {
        bookTracker = GameObject.Find("ObjectiveTracker").GetComponent<JokebookTracker>();
    }



    private bool inCollider;

    public float textSpeed;

    [SerializeField]
    public bool giveCollectable;


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
                if (giveCollectable)
                {
                    bookTracker.jokebookCount++;
                    giveCollectable = false;
                }
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
