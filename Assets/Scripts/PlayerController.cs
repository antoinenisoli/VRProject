using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /// mettre les inputs que tu veux il faut juste faire attention a avoir assez de débug et de bien les parametre
    [SerializeField] private InputActionReference inputLeftHandAction;
    [SerializeField] private InputActionReference inputRightHandAction;

    /// pour les positions de débug 
    [SerializeField] private Transform posReferenceLeftHand;
    [SerializeField] private Transform posReferenceRightHand;

    private void Awake()
    {
        inputLeftHandAction.action.Enable();
        inputRightHandAction.action.Enable();

        inputLeftHandAction.action.started += LeftAction;
        inputRightHandAction.action.canceled += RightAction;
    }

    private void RightAction(InputAction.CallbackContext obj)
    {
        if (Physics.Raycast(new Ray(posReferenceRightHand.position, posReferenceRightHand.up), out RaycastHit hit))
        {
            Debug.Log("HIT" + hit.collider.name + " : Right hand");
        }
    }

    private void LeftAction(InputAction.CallbackContext obj)
    {
        if (Physics.Raycast(new Ray(posReferenceLeftHand.position, posReferenceLeftHand.up), out RaycastHit hit))
        {
            Debug.Log("HIT" + hit.collider.name+" : Left hand");
        }
    }
}
