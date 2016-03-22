using UnityEngine;
using System.Collections;

public class InputTouchController : MonoBehaviour
{


    private Game myGame;
    private LogicAnimationController logicAnimation;
    // Use this for initialization
    void Start()
    {
        myGame = this.GetComponent<Game>();
        logicAnimation = myGame.GetComponent<LogicAnimationController>();
    }


    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();
                Debug.Log(currentSwipe.x + " " + currentSwipe.y);
                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
             {
                    logicAnimation.Jump();
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
             {
                    logicAnimation.Slide();
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f &&  currentSwipe.y < 0.5f)
             {
                    logicAnimation.Enforce();
                }
                //swipe right
                if (currentSwipe.x > 0  && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                    logicAnimation.Spear();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.Swipe();
    }
}


