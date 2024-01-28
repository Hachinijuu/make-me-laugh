using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAnim : MonoBehaviour
{

    public JokebookTracker bookTracker;
    Animator animator;
    [SerializeField]
    private TextMeshProUGUI jokeBookCountText;
    [SerializeField]
    private TextMeshProUGUI outcomeText;
    void Start()
    {
        outcomeText.text = "";
        jokeBookCountText.text = "";
        bookTracker = GameObject.Find("ObjectiveTracker").GetComponent<JokebookTracker>();
        animator = GetComponent<Animator>();
        StartCoroutine(EndAnimation());
        StartCoroutine(CountUpAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EndAnimation()
    {
        Debug.Log("Started Anim");
        if (bookTracker.jokebookCount == 0)
            yield return new WaitForSeconds(3);

        if (bookTracker.jokebookCount == 1)
            yield return new WaitForSeconds(4);

        else if (bookTracker.jokebookCount == 2)
            yield return new WaitForSeconds(5);

        else if (bookTracker.jokebookCount == 3)
            yield return new WaitForSeconds(6);

        if (bookTracker.jokebookCount == 3)
            outcomeText.text = "Congrats! You are funny again!";
        else
            outcomeText.text = "You were unable to become funny again";
        yield return new WaitForSeconds(5);

        animator.SetBool("doAnim", true);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(0);
        bookTracker.jokebookCount = 0;

    }

    private IEnumerator CountUpAnim()
    {
        for (int i = 0; i < bookTracker.jokebookCount + 1; i++)
        {
            yield return new WaitForSeconds(1);
            jokeBookCountText.text = i.ToString() + "/3";
        }


    }
}
