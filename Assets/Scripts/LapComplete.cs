using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;

    //public GameObject LapTimeBox;
    
    private TextMeshProUGUI MinuteMP;
    private TextMeshProUGUI SecondMP;
    private TextMeshProUGUI MilliMP;

    private void Start()
    {
        MinuteMP = MinuteDisplay.GetComponent<TextMeshProUGUI>();
        SecondMP = SecondDisplay.GetComponent<TextMeshProUGUI>();
        MilliMP = MilliDisplay.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        setBestTime();
        
        PlayerPrefs.SetInt("MinSave", LapTimeManager.MinuteCount);
        PlayerPrefs.SetInt("SecSave", LapTimeManager.SecondCount);
        PlayerPrefs.SetInt("MilliSave", LapTimeManager.MilliCount);
        
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MilliCount = 0;

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }

    private void setBestTime()
    {
        if (LapTimeManager.SecondCount <= 9)
        {
            SecondMP.text = "0" + LapTimeManager.SecondCount + ".";
        }
        else
        {
            SecondMP.text = "" + LapTimeManager.SecondCount + ".";
        }
        
        if (LapTimeManager.MinuteCount <= 9)
        {
            MinuteMP.text = "0" + LapTimeManager.MinuteCount + ":";
        }
        else
        {
            MinuteMP.text = "" + LapTimeManager.MinuteCount + ":";
        }

        MilliMP.text = "" + LapTimeManager.MilliDisplay + "";
    }
}
