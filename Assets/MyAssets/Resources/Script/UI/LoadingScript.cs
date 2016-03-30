using UnityEngine;
using System.Collections;


public class LoadingScript : MonoBehaviour {


    public float speedRotating;

	// Use this for initialization
	
        void Start()
    {
        Time.timeScale = 1;
    }
	// Update is called once per frame
	void Update () {

        foreach(Transform oneImage in this.transform)
        {

            oneImage.RotateAround(this.transform.position,Vector3.forward, speedRotating);

        }
    

	}
}
