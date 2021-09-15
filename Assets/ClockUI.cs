using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{

    public float realSecondsPerDay = 900f;
    private Transform clockHandTransform;
    public float day;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        clockHandTransform = GameObject.Find("ClockHand").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / realSecondsPerDay;

        float dayNormalized = day % 1f;
        float rotationDegreesPerDay = 360f;
        clockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);
    }



}
