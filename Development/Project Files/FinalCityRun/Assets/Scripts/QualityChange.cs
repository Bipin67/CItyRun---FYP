using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityChange : MonoBehaviour
{
    public void SetLow()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void SetHigh()
    {
        QualitySettings.SetQualityLevel(2);
    }

    public void SetUltra()
    {
        QualitySettings.SetQualityLevel(10);
    }

}
