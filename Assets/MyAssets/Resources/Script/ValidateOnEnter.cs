using UnityEngine;
using System.Collections;

public class ValidateOnEnter : MonoBehaviour {

    // Use this for initialization
    UnityEngine.UI.Button buttonToValidate;
	void Start () {
        buttonToValidate = this.gameObject.GetComponent<UnityEngine.UI.Button>();
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown("enter"))
        {
            if(this.buttonToValidate != null)
            {
                this.buttonToValidate.onClick.Invoke();
            }
        }

	}
}
