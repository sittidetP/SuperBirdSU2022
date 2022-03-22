using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator animator;
    public bool ground = true;

    public void GoUp(){
        animator.SetTrigger("GoUp");
        
    }

    public void GoDown(){
        animator.SetTrigger("GoDown");
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Ground", true);
    }

    public void SetGround(bool value){
        animator.SetBool("Ground", value);
        ground = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
