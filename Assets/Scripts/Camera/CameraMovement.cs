using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    public Vector2 maxPos;
    public Vector2 minPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // late update used to make sure camera movement doesnt fire before player movement
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            //target to follow
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            //camera bounds
            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
            //linear interpolation
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
