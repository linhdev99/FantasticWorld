using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionSkill : MonoBehaviour
{

    private Rigidbody2D myRgb2DSkill;
    protected Animator animatorSkill;
    protected Vector2 dirSkill = Vector2.right;
    protected int numSkill;
    void Start ()
    {
        myRgb2DSkill = GetComponent<Rigidbody2D>();
        animatorSkill = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        GetInput();
        direcSkill();
    }

    public void direcSkill()
    {
        animatorSkill.SetFloat("x", dirSkill.x);
        animatorSkill.SetFloat("y", dirSkill.y);
        ActivateSkill(numSkill);
    }
    public void ActivateSkill(int num)
    {
        string layerName = "Skill" + num.ToString();
        for (int i = 0; i < animatorSkill.layerCount; i++)
        {
            animatorSkill.SetLayerWeight(i, 0);
        }
        animatorSkill.SetLayerWeight(animatorSkill.GetLayerIndex(layerName), 1);
    }
    public void GetInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dirSkill = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dirSkill = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirSkill = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dirSkill = Vector2.right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            numSkill = 0;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            numSkill = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            numSkill = 2;
        }
        if (Input.GetKey(KeyCode.E))
        {
            numSkill = 3;
        }
        if (Input.GetKey(KeyCode.R))
        {
            numSkill = 4;
        }
    }
}
