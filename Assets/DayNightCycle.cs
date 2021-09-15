using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

    private ClockUI clock;
    private Color sun;
    public float daySeconds;
    public int days;
    public enum DaylightSegments
    {
        EARLYMORNING,
        MORNING,
        NOON,
        AFTERNOON,
        EVENING,
        NIGHT
    }

    public DaylightSegments daylightSegment;


    // Start is called before the first frame update
    void Start()
    {
        clock = GameObject.Find("ClockHand").GetComponent<ClockUI>();
        daySeconds = 0;
        days = 0;
    }

    // Update is called once per frame
    void Update()
    {
        daySeconds += Time.deltaTime;

        if(daySeconds <= 150)
        {
            daylightSegment = DaylightSegments.EARLYMORNING;
            //Debug.Log("Early Morning");
        }
        else if(daySeconds > 150 && daySeconds <= 300)
        {
            daylightSegment = DaylightSegments.MORNING;
            //Debug.Log("Morning");
        }
        else if (daySeconds > 300 && daySeconds <= 450)
        {
            daylightSegment = DaylightSegments.NOON;
            //Debug.Log("Noon");
        }
        else if (daySeconds > 450 && daySeconds <= 600)
        {
            daylightSegment = DaylightSegments.AFTERNOON;
            //Debug.Log("Afternoon");
        }
        else if (daySeconds > 600 && daySeconds <= 750)
        {
            daylightSegment = DaylightSegments.EVENING;
            //Debug.Log("Evening");
        }
        else if (daySeconds > 750 && daySeconds <= 900)
        {
            daylightSegment = DaylightSegments.NIGHT;
            //Debug.Log("Night");
        }
        else
        {
            daylightSegment = DaylightSegments.MORNING;
        }


        switch (daylightSegment)
        {
            case DaylightSegments.EARLYMORNING:

                break;

            case DaylightSegments.MORNING:

                break;

            case DaylightSegments.NOON:

                break;

            case DaylightSegments.AFTERNOON:

                break;

            case DaylightSegments.EVENING:

                break;

            case DaylightSegments.NIGHT:

                break;

        }



        if (daySeconds >= clock.realSecondsPerDay)
        {
            StartNewDay();
            Debug.Log("Start New Day");
        }
    }

    public void StartNewDay()
    {
        daySeconds = 0;
        daySeconds++;
    }
}
