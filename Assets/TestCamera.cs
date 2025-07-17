using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    public GameObject testPlayer;
    public GameObject cameraMovement;
    public float cameraPosition;
    private void Awake()
    {
        cameraPosition = cameraMovement.transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        if(testPlayer != null)
        {
            cameraMovement.transform.position = new Vector3(testPlayer.transform.position.x, testPlayer.transform.position.y, cameraPosition);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Display.displays[0].Activate();
            return;
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            Display.displays[1].Activate();
            return;
        }
    }
    public void ChangeDisplay(Camera camera)
    {
    }
}
