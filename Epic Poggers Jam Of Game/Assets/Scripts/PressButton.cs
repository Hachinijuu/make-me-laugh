using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using static GameManage;

public class PressButton : MonoBehaviour
{
    public UnityEvent<Colour, bool> OnButtonPress;

    public Colour colourEnum;
    bool isOn = false;

    private bool inCollider;

    public GameObject highlightObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        inCollider = true;
        highlightObject.SetActive(true);
        StartCoroutine(CheckForButtonPress());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollider = false;
        highlightObject.SetActive(false);
        StopCoroutine(CheckForButtonPress());
    }

    private IEnumerator CheckForButtonPress()
    {
        while (inCollider)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isOn = !isOn;
                OnButtonPress?.Invoke(colourEnum, isOn);
            }

            yield return null;
        }
    }
}
