using UnityEngine;
using System.Collections;
using System;

public class LogicAnimationController : MonoBehaviour {

    private Animator animator;
    public Game game;

    private static String jumpParameter ="Jump";
    private static String spearParameter = "Spear";
    private static String slideParameter = "Slide";

    public bool animationEnforce;

    private int RunState, JumpState, SpearState,SlideState;

    // Use this for initialization
    void Start () {
        this.animator = game.Player.GetComponent<Animator>();

        this.RunState = Animator.StringToHash("Base.Run");
        this.JumpState = Animator.StringToHash("Base.Jump");
        this.SpearState = Animator.StringToHash("Base.Spear");
        this.SlideState = Animator.StringToHash("Base.Slide");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void Jump()
    {
        if(!this.animationEnforce)
        this.StartCoroutine("CoroutineLunchAnimation", EnumerationInput.Jump);
    }

    internal void Slide()
    {
        if (!this.animationEnforce)
            this.StartCoroutine("CoroutineLunchAnimation", EnumerationInput.Slide);
    }

    internal void Enforce()
    {
        EnumerationInput current = this.GetAnimationRunning();
        if(!animationEnforce)
            if(current == EnumerationInput.Run)
            {
                this.animationEnforce = true;
                this.StartCoroutine("CoroutineEnforce");
            }

    }

    internal void Spear()
    {
        if (!this.animationEnforce)
            this.StartCoroutine("CoroutineLunchAnimation", EnumerationInput.Spear);
    }

    IEnumerator CoroutineEnforce()
    {
        animator.SetLayerWeight(1,1);
        yield return new WaitForSeconds(0.85f);
        animator.SetLayerWeight(1, 0);
        this.animationEnforce = false;

    }

    IEnumerator CoroutineLunchAnimation(EnumerationInput input)
    {
        string animationToActivate = "";
        float timeStart = Time.time;
        switch (input)
        {
            case EnumerationInput.Jump:
                animationToActivate = LogicAnimationController.jumpParameter;
                break;
            case EnumerationInput.Slide:
                animationToActivate = LogicAnimationController.slideParameter;
                break;
            case EnumerationInput.Spear:
                animationToActivate = LogicAnimationController.spearParameter;
                break;
         
        }
        this.animator.SetBool(jumpParameter, false);
        this.animator.SetBool(spearParameter, false);
        this.animator.SetBool(slideParameter, false);
        if (!animationEnforce)
        {
            this.animator.SetBool(animationToActivate, true);
            do
            {
                yield return null;
            } while (Time.time < timeStart + 0.30f);
            this.animator.SetBool(animationToActivate, false);
        }

    }

    internal EnumerationInput GetAnimationRunning()
    {
        AnimatorStateInfo currentState = this.animator.GetCurrentAnimatorStateInfo(0);
        int myCurrentState = currentState.fullPathHash;
        EnumerationInput myInputPlaying = EnumerationInput.Run;
        if (myCurrentState == this.SpearState)
            myInputPlaying = EnumerationInput.Spear;
        if (myCurrentState == this.JumpState)
            myInputPlaying = EnumerationInput.Jump;
        if(myCurrentState == this.SlideState)
            myInputPlaying = EnumerationInput.Slide;
        if (animationEnforce)
            myInputPlaying = EnumerationInput.Enforce;

        return myInputPlaying;
    }
}
