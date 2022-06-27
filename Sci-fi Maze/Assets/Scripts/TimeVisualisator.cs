using TMPro;
using UnityEngine;
using System;

public class TimeVisualisator : MonoBehaviour
{
    private int CurrentTime = 360;
    private void Update()
    {
        GetComponent<TMP_Text>().text = TransferedTime();
    }

    private string TransferedTime()
    {
        if (CurrentTime % 60 >= 10)
            return ((Convert.ToInt32(CurrentTime / 60)).ToString() + ":" + (CurrentTime % 60).ToString());
        else
            return ((Convert.ToInt32(CurrentTime / 60)).ToString() + ":0" + (CurrentTime % 60).ToString());
    }

    public void CurrentTimeUpdate(int UpdatedTime)
    {
        CurrentTime = UpdatedTime;
    }
}
