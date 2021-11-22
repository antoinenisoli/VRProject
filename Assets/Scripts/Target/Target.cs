using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Target : MonoBehaviour
{
    public GameObject Pivot;
    public int Points;
    public bool Hit = false;

    [Space]
    [Header("Ready Animation Settings")]
    public float ReadyRotateDuration = 0.5f;

    [Space]
    [Header("Kill Animation Settings")]
    public float KillRotateDuration = 0.25f;
    public float KillShakeDuration = 0.1f;
    public float KillShakeStrengthY = 15;
    public int KillShakeVibrato = 20;

    [HideInInspector] public UnityEvent hit;
    [HideInInspector] public UnityEvent ready;


    private void Start()
    {
        TargetManager.Instance.AddTarget(this);

        if (hit == null)
            hit = new UnityEvent();

        if (ready == null)
            ready = new UnityEvent();

        hit.AddListener(Kill);
        ready.AddListener(Ready);  
    }

    private void Update()
    {
        if (Hit == true && hit != null)
        {
            hit.Invoke();        
        }
    }

    public void Ready()
    {
        Pivot.transform.DORotate(new Vector3(0, -90, 0), ReadyRotateDuration, RotateMode.WorldAxisAdd);
        ready.RemoveListener(Ready);
    }

    public void Kill()
    {
        hit.RemoveListener(Kill);

        TargetManager.Instance.CheckAllTargets();

        Pivot.transform.DOShakeRotation(KillShakeDuration, new Vector3(0, KillShakeStrengthY, 0), KillShakeVibrato, 90, false).OnComplete(() =>
        {
            Pivot.transform.DORotate(new Vector3(0, 90, 0), KillRotateDuration, RotateMode.WorldAxisAdd);
        });
    }
}
