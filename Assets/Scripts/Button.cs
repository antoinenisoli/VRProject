using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public GameObject ButtonPress;
    public bool IsPressed = false;

    [Space]
    [Header("Press Animation Settings")]
    public float PressDepth = 15;
    public float PressDuration = 1;

    [HideInInspector] public UnityEvent pressed;

    public delegate void PressDelegate();
    public PressDelegate pressMethod;

    private void Start()
    {
        if (pressed == null)
            pressed = new UnityEvent();

        pressed.AddListener(Press);
    }


    private void Update()
    {
        if (Input.GetKeyDown("space") || IsPressed)
        {
            pressed.Invoke();
        }
    }

    public void Press()
    {
        IsPressed = false;
        ButtonPress.transform.DOMoveZ(ButtonPress.transform.position.z - PressDepth, PressDuration).OnComplete(() =>
        {
            ButtonPress.transform.DOMoveZ(ButtonPress.transform.position.z + PressDepth, PressDuration);
        });
        pressMethod();
    }
}
