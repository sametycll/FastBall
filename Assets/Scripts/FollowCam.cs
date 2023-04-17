using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform ball;
    [SerializeField][Range(0f, 1f)] float camSpeed;
    [SerializeField] Rigidbody rb;
    float camVelocity_x,camVelocity_y;
    
  
    void LateUpdate()
    {
        if (rb.isKinematic)
        {
            var cameraNewPos = transform.position;
            transform.position = new Vector3(Mathf.SmoothDamp(cameraNewPos.x, ball.transform.position.x, ref camVelocity_x, camSpeed)
                , Mathf.SmoothDamp(cameraNewPos.y, ball.transform.position.y +3f, ref camVelocity_y, camSpeed), cameraNewPos.z);
        }
        
    }
}
