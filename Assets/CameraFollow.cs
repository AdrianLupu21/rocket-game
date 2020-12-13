using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField]    
    Transform target;

    [SerializeField]
    float smoothSpeed = 0.125f;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    Slider mouseSensitivitySlider;


    public bool rotateAroundPlayer = true;

    void FixedUpdate()
    {
        if (rotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivitySlider.value, Vector3.up);
            offset = camTurnAngle * offset;
        }
        Vector3 currentPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, currentPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothPosition;
        transform.LookAt(target);
    }
}
