using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpecialObject : MonoBehaviour
{

    public bool toggle = false;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    [SerializeField] private List<Switch> switchList = new List<Switch>();

    [Serializable]
    public class Switch
    {
        public GameManage.Colour color;
        public bool isOn;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void checkAction(GameManage.Colour buttonColour, bool isOn)
    {
        foreach (var switcheroo in switchList)
        {
            if (switcheroo.color == buttonColour)
                switcheroo.isOn = isOn;
        }

        foreach (var switcheroo in switchList)
        {
            if (!switcheroo.isOn)
            {
                TurnOff();
                return;
            }
        }

        TurnOn();
    }

    private void TurnOn()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
        boxCollider.enabled = !boxCollider.enabled;
    }

    private void TurnOff()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = !spriteRenderer.enabled;
    }
}
