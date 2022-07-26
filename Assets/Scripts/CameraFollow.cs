using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.2f;
    public Vector3 offsetPos = new Vector3(30f, 25f, -40f);

    void LateUpdate() {
        Vector3 desiredPos = target.position + offsetPos;
        Vector3 smoothedPos = Vector3.Lerp(target.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;   

        transform.LookAt(target); 
    }
}
