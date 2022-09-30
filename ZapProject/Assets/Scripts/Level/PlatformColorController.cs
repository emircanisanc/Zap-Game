using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColorController : MonoBehaviour
{

    [SerializeField]
    private Material material;

    [SerializeField]
    private Color[] colors;

    private int colorIndex = -1;

    [SerializeField]
    private float lerpValue;

    [SerializeField]
    private float time;

    private float currentTime;

    void Update()
    {
        setColorChangeTime();
        setMaterialSmoothColorChange();
    }

    private void setColorChangeTime()
    {
        if(currentTime <= 0)
        {
            checkColorIndexValue();
            currentTime = time;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void checkColorIndexValue()
    {
        colorIndex++;
        if(colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }

    private void setMaterialSmoothColorChange()
    {
        material.color = Color.Lerp(material.color, colors[colorIndex], lerpValue * Time.deltaTime);
    }

    void OnDestroy()
    {
        material.color = colors[0];
    }
}
