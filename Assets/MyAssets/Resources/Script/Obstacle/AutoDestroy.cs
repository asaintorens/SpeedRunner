using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.StartCoroutine("destroyAfter");
	}
	
    public IEnumerator destroyAfter()
    {
        yield return new WaitForSeconds(0.85f);
        Destroy(this.gameObject);
        yield return null;
    }
         
}
