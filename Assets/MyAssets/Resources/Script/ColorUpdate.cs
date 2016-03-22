using UnityEngine;
using System.Collections;

public class ColorUpdate : MonoBehaviour {

    // Use this for initialization
    private Light light;
	void Start () {
        this.light = this.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (light != null)
            light.color = ColorController.currentColor;
	
	}
}
