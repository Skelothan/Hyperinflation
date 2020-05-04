using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public GameObject timerBar;
    private Transform timerBarTransform;

    private int time;
    private int dayLength;
    private int timerBarMaxLength;
    private int timeSeconds;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timeSeconds = 0;
        // 240 seconds = 1 minute
        dayLength = 240;
        timerBarMaxLength = 1250;

        timerBarTransform = timerBar.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        time++;

        if (time % 60 == 0)
        {
            timeSeconds++;

            // update visual timer
            float timePercent = timeSeconds / (float)dayLength;
            int timerBarNewLength = (int)(timePercent * timerBarMaxLength);

            Vector2 newScale = new Vector2(timerBarNewLength, timerBarTransform.localScale.y);
            timerBarTransform.localScale = newScale;

            Vector2 newPos = new Vector2(0.5f * timerBarNewLength - 625, timerBarTransform.localPosition.y);
            timerBarTransform.localPosition = newPos;

        }

        // TODO: end day at day's end

    }

    public void resetTimer()
    {
        time = 0;
        timeSeconds = 0;
        Vector2 newScale = new Vector2(0, 10);
        timerBarTransform.localScale = newScale;

        Vector2 newPos = new Vector2(-625, -350);
        timerBarTransform.localPosition = newPos;
    }
}
