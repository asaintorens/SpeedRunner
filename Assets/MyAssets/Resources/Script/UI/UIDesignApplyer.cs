using UnityEngine;
using System.Collections;

public class UIDesignApplyer : MonoBehaviour {

	// Use this for initialization
public void ApplyDesign(Sprite backgroundImg,Color buttonHighlited, Color buttonDisabled, Color textColor)
    {
        UnityEngine.UI.Button button= this.GetComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Text text = this.GetComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Image image = this.GetComponent<UnityEngine.UI.Image>();



        if(button != null)
        {
            
            UnityEngine.UI.ColorBlock blockColor= button.colors;
           blockColor.disabledColor = buttonDisabled;
            blockColor.highlightedColor = buttonHighlited;
            button.colors = blockColor;
        }
        if(text != null)
        {
            text.color = textColor;
        }
        if(image != null)
        {
            image.sprite = backgroundImg;
        }
    }
}
