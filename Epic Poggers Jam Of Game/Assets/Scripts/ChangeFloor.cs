using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeFloor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        floorChange();
    }

    private void floorChange()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
