using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabItem : MonoBehaviour
{
    [SerializeField] XRRayInteractor rayInteractor;
    
    void Update()
    {
        rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit);
        print(hit);
    }
}
