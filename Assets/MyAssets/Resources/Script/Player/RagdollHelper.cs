using UnityEngine;
using System.Collections;

public class RagdollHelper : MonoBehaviour {

    public CharacterController characterController;
    public Rigidbody rigidbodyPlayer;
    public Animator animator;

    public bool ragdollMode;
	// Use this for initialization
	void Start () {
        this.characterController = this.GetComponent<CharacterController>();
        this.rigidbodyPlayer = this.GetComponent<Rigidbody>();
        this.animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	if(ragdollMode)
        {
            this.rigidbodyPlayer.velocity = this.rigidbodyPlayer.velocity / 2;
            this.characterController.enabled = false;
            this.rigidbodyPlayer.isKinematic = true;
            this.animator.enabled = false;
        }
	}
}
