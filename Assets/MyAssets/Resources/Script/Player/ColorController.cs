using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorController : MonoBehaviour
{

    public List<Color> listColor = new List<Color>();
    public Material theMaterial;
    public int indexColor=0;
    public float speedColorChange;
    public static Color currentColor = new Color();
    public float offset;
    void Start()
    {

       // listColor.Insert(0,(new Color(theMaterial.color.r, theMaterial.color.g, theMaterial.color.b)));
        currentColor = listColor[0];
    }

    // Update is called once per frame
    void Update()
    {

        Color nextColor = listColor[indexColor];
        Color nextColorAdditioned = Color.Lerp(currentColor, nextColor, Time.deltaTime*speedColorChange*Time.timeScale);
        currentColor = nextColorAdditioned;

        if (IsEqualColor(currentColor, nextColor))
        {
            indexColor++;
            if(indexColor+1 > this.listColor.Count)
            {
                indexColor = 0;
            }
        }
        theMaterial.color = nextColorAdditioned;



    }

    public bool IsEqualColor(Color a, Color b)
    {
        return ((a.r -offset < b.r && b.r <a.r+ offset) && (a.g- offset <  b.g && a.g< b.g+ offset) && (a.b- offset < b.b && a.b< b.b+ offset));

    }
}
