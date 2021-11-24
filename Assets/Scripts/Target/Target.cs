using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Target : MonoBehaviour
{
    public enum AttachedTo
    {
        Ground,
        Ceiling,
        Left,
        Right
    }

    public AttachedTo Pivot;
    public int Points;
    public bool Hit = false;

    [Space]
    [Header("Ready Animation Settings")]
    public float ReadyRotateDuration = 0.5f;

    [Space]
    [Header("Kill Animation Settings")]
    public float KillRotateDuration = 0.25f;
    public float KillShakeDuration = 0.1f;
    public float KillShakeStrength = 15;
    public int KillShakeVibrato = 20;

    [HideInInspector] public UnityEvent hit;
    [HideInInspector] public UnityEvent ready;

    private Vector3 axis;


    private void Start()
    {
        TargetManager.Instance.AddTarget(this);

        if (hit == null)
            hit = new UnityEvent();

        if (ready == null)
            ready = new UnityEvent();

        hit.AddListener(Kill);
        ready.AddListener(Ready);

        SetPivotAxis();
    }

    private void Update()
    {
        if (Hit == true && hit != null)
        {
            hit.Invoke();        
        }
    }

    private void SetPivotAxis()
    {
        switch (Pivot)
        {
            case AttachedTo.Ground:
                axis = new Vector3(1, 0, 0);
                break;
            case AttachedTo.Ceiling:
                axis = new Vector3(1, 0, 0);
                break;
            case AttachedTo.Right:
                axis = new Vector3(0, 0, 1);
                break;
            case AttachedTo.Left:
                axis = new Vector3(0, 0, -1);
                break;
        }
    }

    public void Ready()
    {
        transform.DOLocalRotate(-axis * 90, ReadyRotateDuration, RotateMode.LocalAxisAdd);
        ready.RemoveListener(Ready);
    }

    public void Kill()
    {
        hit.RemoveListener(Kill);

        TargetManager.Instance.CheckAllTargets();

        transform.DOShakeRotation(KillShakeDuration, axis * KillShakeStrength, KillShakeVibrato, 90, false).OnComplete(() =>
        {
            transform.DOLocalRotate(axis * 90, KillRotateDuration, RotateMode.LocalAxisAdd);
        });
    }
}
