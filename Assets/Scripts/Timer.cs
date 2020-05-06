using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public static Timer instance;

    public GameObject timerBar;
    private Transform timerBarTransform;

    public GameObject timerTextObject;
    private TextMeshProUGUI timerTMPro;

    private int time;
    private int dayLength;
    private int timerBarMaxLength;
    private int timeHalfSeconds;
    private int timeSeconds;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timeHalfSeconds = 0;
        timeSeconds = 0;
        // 240 seconds = 1 minute
        dayLength = 240;
        timerBarMaxLength = 1250;

        timerBarTransform = timerBar.GetComponent<Transform>();
        timerTMPro = timerTextObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.instance.GetState() == "day")
        {
            time++;

            if (time % 30 == 0)
            {
                timeHalfSeconds++;
                timerTMPro.SetText(GetTimeOfDay());
            }
            if (time % 60 == 0)
            {
                timeSeconds++;
                UpdateVisualTimer();
            }

            // TODO: end day at day's end
            if (timeSeconds == dayLength)
            {
                GameState.instance.ChangeState("night");
                BuildingItems.instance.ConsumeBread();
            }
        }
    }

    public void ResetTimer()
    {
        time = 0;
        timeHalfSeconds = 0;
        timeSeconds = 0;
        Vector2 newScale = new Vector2(0, 10);
        timerBarTransform.localScale = newScale;

        Vector2 newPos = new Vector2(-625, -350);
        timerBarTransform.localPosition = newPos;
    }

    public string GetTimeOfDay()
    {
        int hours = (timeHalfSeconds / 60 + 8) % 12 + 1;
        int minutes = timeHalfSeconds % 60;
        string period = "";
        if (hours > 6 && hours <= 11)
            period = "A.M.";
        else
            period = "P.M.";

        return string.Format("{0}:{1:00} {2}", hours, minutes, period);
    }

    public void UpdateVisualTimer()
    {
        float timePercent = timeSeconds / (float)dayLength;
        int timerBarNewLength = (int)(timePercent * timerBarMaxLength);

        Vector2 newScale = new Vector2(timerBarNewLength, timerBarTransform.localScale.y);
        timerBarTransform.localScale = newScale;

        Vector2 newPos = new Vector2(0.5f * timerBarNewLength - 625, timerBarTransform.localPosition.y);
        timerBarTransform.localPosition = newPos;
    }
}
