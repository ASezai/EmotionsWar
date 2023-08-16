using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform Target;
    public float SmoothSpeed = 0.5f;

    private void LateUpdate()
    {
        if (Target != null)
        {
            Vector3 desiredPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
