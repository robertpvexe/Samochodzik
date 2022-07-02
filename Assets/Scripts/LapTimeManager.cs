using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static int MilliCount;
    public static string MilliDisplay;
    public double MilliSum; 

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;
    private TextMeshProUGUI MinuteMP;
    private TextMeshProUGUI SecondMP;
    private TextMeshProUGUI MilliMP;

    private void Start()
    {
        MinuteMP = MinuteBox.GetComponent<TextMeshProUGUI>();
        SecondMP = SecondBox.GetComponent<TextMeshProUGUI>();
        MilliMP = MilliBox.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        MilliSum += Time.deltaTime * 100;
        MilliCount = (int)MilliSum;

        if (MilliCount < 10)
        {
            MilliDisplay = "0";
        }
        else
        {
            MilliDisplay = MilliCount.ToString()[0].ToString();
        }
        
        
        MilliMP.text = "" + MilliDisplay;
        
    
        if (MilliCount >= 100)
        {
            MilliCount = 0;
            MilliSum = 0;
            SecondCount += 1;
        }
    
        if (SecondCount <= 9)
        {
            SecondMP.text = "0" + SecondCount + ".";
        }
        else
        {
            SecondMP.text = SecondCount + ".";
        }
    
        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }
        
        if (MinuteCount <= 9)
        {
            MinuteMP.text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteMP.text = MinuteCount + ":";
        }
    }
}
