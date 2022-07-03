using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightSystem : MonoBehaviour
{
    public float currentTime;
    public float dayLengthMinutes;
    public TextMeshProUGUI timeText;

    float rotationSpeed;
    float midday;
    float translateTime;
    string AMPM = "AM";
    
    void Start()
    {
        rotationSpeed = 360 / dayLengthMinutes / 60;
        midday = dayLengthMinutes * 60 / 2;
    }

    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        translateTime = (currentTime / (midday * 2));

        float t = translateTime * 24f;

        float hours = Mathf.Floor(t);

        string displayHours = hours.ToString();
        if (hours == 0) 
        {
            displayHours = "12";
        }
        if (hours > 12) 
        {
            displayHours = (hours - 12).ToString();
        }
        if (currentTime >= midday) 
        {
            if (AMPM != "PM") 
            {
                AMPM = "PM";
            }
        }
        if (currentTime >= midday * 2)
        {
            if (AMPM != "AM") 
            {
                AMPM = "AM";
            }
            currentTime = 0;
        }


        string displayTime = displayHours + AMPM;
        timeText.text = hours.ToString();

        transform.Rotate(new Vector3(1, 0, 0) * rotationSpeed * Time.deltaTime);
    }
}
