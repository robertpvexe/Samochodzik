using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadLapTime : MonoBehaviour
{
    public int MinuteCount;
    public int SecondCount;
    public int MilliCount;
    
    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MilliDisplay;
    
    private TextMeshProUGUI MinuteMP;
    private TextMeshProUGUI SecondMP;
    private TextMeshProUGUI MilliMP;
    void Start()
    {
        MinuteMP = MinDisplay.GetComponent<TextMeshProUGUI>();
        SecondMP = SecDisplay.GetComponent<TextMeshProUGUI>();
        MilliMP = MilliDisplay.GetComponent<TextMeshProUGUI>();
        
        MinuteCount = PlayerPrefs.GetInt("MinSave");
        SecondCount = PlayerPrefs.GetInt("SecSave");
        MilliCount = PlayerPrefs.GetInt("MilliSave");
        
        setBestTime();
    }
    
    private void setBestTime()
    {
        if (SecondCount <= 9)
        {
            SecondMP.text = "0" + SecondCount + ".";
        }
        else
        {
            SecondMP.text = "" + SecondCount + ".";
        }
        
        if (MinuteCount <= 9)
        {
            MinuteMP.text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteMP.text = "" + MinuteCount + ":";
        }

        if (MilliCount < 10)
        {
            MilliMP.text = "0";
        }
        else
        {
            MilliMP.text = "" + MilliCount.ToString()[0] + "";
        }
        
    }
}
