using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance;

    public bool ToStartCycle = false;
    public Button StartButton;

    public List<Target> Targets = new List<Target>();


    private void Awake()
    {
        Instance = this;

        StartButton.pressMethod = StartCycle;
    }

    private void Update()
    {
        if (ToStartCycle)
        {
            StartCycle();
        }
    }

    public void AddTarget(Target target)
    {
        Targets.Add(target);
    }

    public void StartCycle()
    {
        foreach (Target target in Targets)
        {           
            target.ready.Invoke();
        }
    }

    public void CheckAllTargets()
    {
        foreach (Target target in Targets)
        {
            if (target.Hit == false)
                return;
        }

        ResetCycle();
    }

    public void ResetCycle()
    {
        foreach (Target target in Targets)
        {
            target.Hit = false;

            target.ready.AddListener(target.Ready);
            target.hit.AddListener(target.Kill);
        }
    }
}
