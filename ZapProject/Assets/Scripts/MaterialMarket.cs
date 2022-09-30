using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct BallMaterial{
    public Material material;
    public int price;
    public Sprite marketImage;
}

public class MaterialMarket : MonoBehaviour
{
    [SerializeField]
    private BallMaterial[] materials;

    [SerializeField]
    private Renderer ballRenderer;

    [SerializeField]
    private MarketBlock[] marketBlocks;

    [SerializeField]
    private GameObject marketPanelGameObject;

    [SerializeField]
    private GameObject menuPanelGameObject;

    [SerializeField]
    private GameObject gamePanelObject;

    [SerializeField]
    private Text diamondText;

    [SerializeField]
    private AudioClip openNewMaterialClip;

    private bool isDone;

    void Awake(){
        openMaterial(0);
        ballRenderer.material = getMaterialAt(PlayerPrefs.GetInt("lastMaterial", 0));
    }

    public void toggleMaterialMarket(){
        if(marketPanelGameObject.gameObject.activeSelf){
            marketPanelGameObject.SetActive(false);
            menuPanelGameObject.SetActive(true);
            gamePanelObject.SetActive(true);
        }else{
            menuPanelGameObject.SetActive(false);
            gamePanelObject.SetActive(false);
            marketPanelGameObject.gameObject.SetActive(true);
            diamondText.text = PlayerPrefs.GetInt("diamond", 0).ToString();
            if(!isDone){
                isDone = true;
                BallMaterial tempMaterial;
                for(int index = 0; index < materials.Length; index++){
                    tempMaterial = getBallMaterialAt(index);
                    marketBlocks[index].setImage(tempMaterial.marketImage);
                    marketBlocks[index].setIndex(index);
                    marketBlocks[index].setOpen(isOpen(index));
                    marketBlocks[index].setPrice(tempMaterial.price);
                }
            }
        }
    }


    public void selectMaterial(int id){
        if(PlayerPrefs.GetInt("material"+id, 0) == 1){
            setBallMaterial(id);
        }else if(PlayerPrefs.GetInt("diamond", 0) >= getPriceAt(id)){
            reduceDiamond(getPriceAt(id));
            setBallMaterial(id);
            openMaterial(id);
            marketBlocks[id].setOpen(true);
            AudioSource.PlayClipAtPoint(openNewMaterialClip, transform.position);
        }
    }

    private bool isOpen(int id){
        return PlayerPrefs.GetInt("material"+id, 0) == 1;
    }


    private void reduceDiamond(int price){
        var lastDiamond = PlayerPrefs.GetInt("diamond", 0);
        PlayerPrefs.SetInt("diamond", lastDiamond - price);
        diamondText.text = (lastDiamond - price).ToString();
    }

    private void setBallMaterial(int id){
        ballRenderer.material = getMaterialAt(id);
        PlayerPrefs.SetInt("lastMaterial", id);
    }

    private Material getMaterialAt(int id){
        return materials[id].material;
    }

    private int getPriceAt(int id){
        return materials[id].price;
    }
    
    private void openMaterial(int id){
        PlayerPrefs.SetInt("material"+id, 1);
    }

    private Sprite getImageAt(int id){
        return materials[id].marketImage;
    }

    private BallMaterial getBallMaterialAt(int id){
        return materials[id];
    }
}
