using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabItem : MonoBehaviour
{
    XRRig mainController;
    XRRayInteractor rayInteractor;
    [SerializeField] InputDevice device;

    private void Awake()
    {
        mainController = FindObjectOfType<XRRig>();
        rayInteractor = GetComponent<XRRayInteractor>();
    }

    void Update()
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            /*Gun gun = hit.transform.GetComponentInParent<Gun>();
            if (gun)
                print(gun);
            else
            {
                bool triggerValue;
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
                {
                    Debug.Log("Trigger button is pressed." + " // " + hit.transform);
                    mainController.transform.position = new Vector3(hit.point.x, mainController.transform.position.y, hit.point.z);
                }
            }*/
        }
    }
}
