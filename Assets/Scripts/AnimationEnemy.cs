using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationEnemy : MonoBehaviour
{
    private Animator myAnimator;

    protected Vector2 direction;

    // Use this for initialization
    protected virtual void Start()
    {
        myAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetFloat("x", direction.x);
        myAnimator.SetFloat("y", direction.y);
        
    }
   
}
