using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MarketBlock : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private Text priceText;

    [SerializeField]
    private Image lockedImage;

    private int index;

    [SerializeField]
    private MaterialMarket market;

    public void setImage(Sprite sprite){
        image.sprite = sprite;
    }
    public void setOpen(bool open){
        if(open){
            lockedImage.color = new Color(lockedImage.color.r, lockedImage.color.g, lockedImage.color.b, 0);
        }else{
            lockedImage.color = new Color(lockedImage.color.r, lockedImage.color.g, lockedImage.color.b, 0.5f);
        }
    }
    public void setIndex(int index){
        this.index = index;
    }
    public void setPrice(int price){
        priceText.text = price.ToString();
    }


    public void clickMarketBlock(){
        market.selectMaterial(index);
    }
}
