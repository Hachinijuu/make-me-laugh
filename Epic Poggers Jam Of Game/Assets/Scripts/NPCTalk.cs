using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{

    [SerializeField]
    private string text;

    public TextMeshProUGUI npcText;

    private void Start()
    {
        npcText.text = text;
        npcText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        npcText.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npcText.enabled = false;
    }
}
