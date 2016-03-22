using UnityEngine;
using System.Collections;

public class InputListener : MonoBehaviour {

    private Game myGame;
    private LogicAnimationController logicAnimation;
	// Use this for initialization
	void Start () {
        myGame = this.GetComponent<Game>();
        logicAnimation = myGame.GetComponent<LogicAnimationController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Z))
            logicAnimation.Jump();
        if (Input.GetKey(KeyCode.S))
            logicAnimation.Slide();
        if (Input.GetKey(KeyCode.Q))
            logicAnimation.Enforce();
        if (Input.GetKey(KeyCode.D))
            logicAnimation.Spear();

    }
}
