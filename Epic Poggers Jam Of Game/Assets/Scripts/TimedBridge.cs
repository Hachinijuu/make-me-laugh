using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.StickyNote;

public class TimedBridge : MonoBehaviour
{
    [SerializeField]
    private int timer;

    public void startBridge()
    {
        StartCoroutine(startTimer());
    }

    public IEnumerator startTimer()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(timer);
        Debug.Log("Done Timer");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }



}
