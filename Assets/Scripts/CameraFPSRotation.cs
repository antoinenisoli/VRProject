using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraFPSRotation : MonoBehaviour
{
    public float DPI = 200;
    public bool rotate = false;
    [SerializeField]Vector2 turn;
    [SerializeField] InputActionReference CameraRotate;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraRotate.action.performed+= ctr => turn = ctr.ReadValue<Vector2>(); 
        CameraRotate.action.canceled+=ctr=> turn =Vector2.zero;
        CameraRotate.action.Enable();
    }
    private void Update()
    {
        if(rotate)
        {
            if (turn != Vector2.zero)
            {

                Vector3 newRotationValue = Camera.main.transform.localRotation.eulerAngles;

                newRotationValue += new Vector3(-turn.y, turn.x, 0) * Time.deltaTime*DPI;

                Camera.main.transform.localEulerAngles= newRotationValue;
            }
        }
    }
}
