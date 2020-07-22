using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float currentTime;
    private float maxTime;

    public float CurrentTime { get => currentTime; }

    public void SetTimer(float time)
    {
        maxTime = time;
        currentTime = time;
    }

    public void Tick()
    {
        currentTime -= Time.deltaTime;
    }

    public void Reset()
    {
        currentTime = maxTime;
    }
}