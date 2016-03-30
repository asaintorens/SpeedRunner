using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class UIApplyDesign : MonoBehaviour
{

    // Use this for initialization

    public Sprite backgroundImage;
    public Color textColor;
    public Color pressedButtonColor;
    public Color buttonHighLight;
    public bool ApplyTexture;
    public List<UIDesignApplyer> listUIElements = new List<UIDesignApplyer>();
    private List<GameObject> childsOfGameobject = new List<GameObject>();


    
    // Update is called once per frame
    void Update()
    {
        if (ApplyTexture)
        {
            ApplyTexture = false;
            this.GetAllUIApplyer();
        }
    }

    public void GetAllUIApplyer()
    {
        this.childsOfGameobject = new List<GameObject>();
        listUIElements = new List<UIDesignApplyer>();
        this.GetAllChilds(this.gameObject);
        foreach (GameObject oneUiGameObject in childsOfGameobject)
        {
            UIDesignApplyer oneUI = oneUiGameObject.GetComponent<UIDesignApplyer>();
            if(oneUI != null)
            {
                this.listUIElements.Add(oneUI);
            }
        }

        foreach (UIDesignApplyer oneComponent in listUIElements)
        {
            oneComponent.ApplyDesign(this.backgroundImage, this.buttonHighLight, this.pressedButtonColor, textColor);
        }

    }



    private List<GameObject> GetAllChilds(GameObject transformForSearch)
    {
        List<GameObject> getedChilds = new List<GameObject>();

        foreach (Transform trans in transformForSearch.transform)
        {
            //Debug.Log (trans.name);
            GetAllChilds(trans.gameObject);
            childsOfGameobject.Add(trans.gameObject);
        }
        return getedChilds;
    }

}
