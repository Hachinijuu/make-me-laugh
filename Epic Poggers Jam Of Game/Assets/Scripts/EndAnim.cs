using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        yield return new WaitForSeconds(15);

        if (bookTracker.jokebookCount == 3)
            outcomeText.text = "Congrats! You are funny again!";
        else
            outcomeText.text = "You were unable to become funny again";
        yield return new WaitForSeconds(5);

        animator.SetBool("doAnim", true);

    }

    private IEnumerator CountUpAnim()
    {
        for(int i = 0; i < bookTracker.jokebookCount; i++)
        {
            yield return new WaitForSeconds(3);
            jokeBookCountText.text = i.ToString() + "/3";
        }


    }
}
