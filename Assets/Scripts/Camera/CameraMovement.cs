using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // late update used to make sure camera movement doesnt fire before player movement
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            //linear interpolation
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
