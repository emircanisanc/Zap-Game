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





    public void startChangingColor(){
        StartCoroutine(changeColorRoutine());
    }

    IEnumerator changeColorRoutine(){
        while(true){
            setColorChangeTime();
            setMaterialSmoothColorChange();
            yield return new WaitForSeconds(0);
        }
    }
}
