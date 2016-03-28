using UnityEngine;
using System.Collections;

public class ScrollBarAutoValue1 : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        UnityEngine.UI.Scrollbar scrollbar = this.GetComponent<UnityEngine.UI.Scrollbar>();
        scrollbar.value = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
