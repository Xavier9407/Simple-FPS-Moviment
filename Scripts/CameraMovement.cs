using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Body;
    public Transform Head;

    float rotationX = 0;
    float rotationY = 0;

    float sensivity = 1f;

    float angleYmax = 90f;
    float angleYmin = -90f;

    [Header("Enable camera smooth")]
    [SerializeField] bool smooth;

    float smoothRotx = 0;
    float smoothRoty = 0;

    [Header("Smooth coefficient")]
    [SerializeField] float smoothCoefx = 0.003f;
    [SerializeField] float smoothCoefy = 0.003f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        transform.position = Head.position;
    }

    void Update()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensivity;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensivity;

        if (smooth)
        {
            smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
            smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

            rotationX += smoothRotx;
            rotationY += smoothRoty;
        }
        else
        {
            rotationX += horizontalDelta;
            rotationY += verticalDelta;
        }

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        Body.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        


    }
}
