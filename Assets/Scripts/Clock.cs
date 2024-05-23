using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
public class Clock : MonoBehaviour
{
    private float _day;
    private const float RealSecondsPerIngameDay = 500f;
    [SerializeField] private TextMeshProUGUI clockText;
    string hoursString;
    string minutesString;
    int startHour;
    int startMinute;
    public static Action AfternoonEvent;
    public static Action NightEvent;
    public static Action CloseEvent;
    public static Action CarEvent;


    int firstCarCome;
    int secondCarCome;

    private void Start()
    {
        if (PlayerPrefs.HasKey("hoursString"))
        {
            startHour = PlayerPrefs.GetInt("hoursString");
            Debug.Log("hour data");
        }
        else
        {
            startHour = 9;
        }



        if (PlayerPrefs.HasKey("minutesString"))
        {
            startMinute = PlayerPrefs.GetInt("minutesString");
            Debug.Log("minutedata");
        }
        else
        {
            startMinute = 00;
        }
           


        firstCarCome = UnityEngine.Random.Range(10, 12);
        secondCarCome = UnityEngine.Random.Range(14, 16);
    }
    private void UpdateClockText()
    {
        float dayNormalized = _day % 1f;
        float hoursPerDay = 24f;
        float minutesPerHour = 60 -startMinute;

        hoursString = Mathf.Floor(startHour + dayNormalized * hoursPerDay).ToString("00");
        minutesString = Mathf.Floor( startMinute+((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        PlayerPrefs.SetInt("hoursString",int.Parse(hoursString));
        PlayerPrefs.SetInt("minutesString", int.Parse(minutesString));

        if(int.Parse(minutesString)>= 59)
        {
            startMinute = 0;
        }
            
        // Saat 17:00 olduðunda döngüyü durdur
        if (int.Parse(hoursString) >= 17)
        {
            hoursString = "17";
            minutesString = "00";
        }

        clockText.text = hoursString + ":" + minutesString;



    }
    void Clockevents()
    {
        if (int.Parse(hoursString) == 12)
        {
            AfternoonEvent?.Invoke();
        }
        else if (int.Parse(hoursString) == 15)
        {
            NightEvent?.Invoke();
        }
        else if (int.Parse(hoursString) >= 17)
        {
            CloseEvent?.Invoke();
        }

    }

    void CarEvents()
    {
        if (int.Parse(hoursString) == firstCarCome || int.Parse(hoursString) == secondCarCome)
        {
            CarEvent?.Invoke();
        }

    }
    private void Update()
    {
        _day += Time.deltaTime / RealSecondsPerIngameDay;
        UpdateClockText();
        Clockevents();
        CarEvents();
    }
   

   
    
}
