using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    private float _day;
    private const float RealSecondsPerIngameDay = 5f;
    [SerializeField] private TextMeshProUGUI clockText;
    string hoursString;
    string minutesString;
    private void UpdateClockText()
    {
        float dayNormalized = _day % 1f;
        float hoursPerDay = 24f;
        float minutesPerHour = 60f;

         hoursString = Mathf.Floor(9 + dayNormalized * hoursPerDay).ToString("00");
         minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        // Saat 17:00 olduðunda döngüyü durdur
        if (int.Parse(hoursString) >= 17)
        {
            hoursString = "17";
            minutesString = "00";
            Debug.Log("Day End");
            DayManager.instance.dayEnd = true;
            enabled = false;
        }
        
        clockText.text = hoursString + ":" + minutesString;
        
    }
   
    private void Update()
    {
        _day += Time.deltaTime / RealSecondsPerIngameDay;
        UpdateClockText();
    }
}
