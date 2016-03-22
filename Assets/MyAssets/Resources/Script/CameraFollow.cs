using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    private float initialTargetY;
    public float smooth;
    // Use this for initialization
    void Start () {
        initialTargetY = target.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(target != null)
        {
            this.transform.position =  Vector3.Lerp  (this.transform.position,new Vector3(target.transform.position.x + this.offsetX,   initialTargetY + this.offsetY, this.target.transform.position.z + this.offsetZ),smooth*Time.deltaTime);
        }

	}
}
