using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

   public EnumerationInput inputWaited;
    // Use this for initialization
   public GameObject colliderToActive1;
    public GameObject colliderToActive2;
    public GameObject colliderTrigger;
    public bool enableCollider;
    private bool colliderEnabled;
    public BreakableObject breakableObj;

    void Start()
    {
        GameObject ground = Instantiate(Resources.Load("Obstacles/ground")) as GameObject;
        ground.transform.SetParent(this.gameObject.transform);
        ground.transform.localPosition = new Vector3(0,0,0);

    }

    public void BreakObject()
    {
        if (this.breakableObj != null)
        {
            this.breakableObj.triggerBreak();
        }
    }

    void Update()
    {
        if(enableCollider && !colliderEnabled)
        {
            colliderEnabled = true;
            if(this.colliderToActive1 != null)
            {
               BoxCollider box1 = this.colliderToActive1.GetComponent<BoxCollider>();
                if(box1 != null)
                {
                    box1.enabled = true;
                }
            }
            if (this.colliderToActive2 != null)
            {
                BoxCollider box2 = this.colliderToActive2.GetComponent<BoxCollider>();
                if (box2 != null)
                {
                    box2.enabled = true;
                }
            }

            if(this.colliderTrigger != null)
            {
                BoxCollider box3 = this.colliderTrigger.GetComponent<BoxCollider>();
                box3.enabled = true;
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag=="Player")
        {
            if(Game.GameOver)
            {
                collider.GetComponent<RagdollHelper>().ragdollMode = true;
            }
        }
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (Game.GameOver)
            {
                collider.GetComponent<RagdollHelper>().ragdollMode = true;
            }
        }
    }

}
