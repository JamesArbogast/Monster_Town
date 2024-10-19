using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, +1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(+1, 0);
        }
    }
}
