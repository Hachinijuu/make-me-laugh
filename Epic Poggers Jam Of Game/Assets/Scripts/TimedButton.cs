using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Unity.VisualScripting.StickyNote;

public class TimedButton : MonoBehaviour
{
    private bool inCollider;

    public UnityEvent OnButtonPress;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inCollider = true;
        StartCoroutine(CheckForButtonPress());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollider = false;
        StopCoroutine(CheckForButtonPress());
    }

    private IEnumerator CheckForButtonPress()
    {
        while (inCollider)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Pressed Timed Button");

                OnButtonPress?.Invoke();
            }

            yield return null;
        }
    }
}
