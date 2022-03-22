using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public bool upButton;
    public Elevator elevator;
    public bool characterStay;
    public Canvas canvas;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            characterStay = true;
        }
        /*
        if(upButton){
            elevator.SetGround(false);
        }else{
            elevator.SetGround(true);
        }
        */
    }
    // Start is called before the first frame update
    void Start()
    {
        //canvas = GetComponentInChildren<Canvas>();
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas != null){
            canvas.gameObject.SetActive(characterStay);
        }
        
        if(characterStay && Input.GetKeyDown(KeyCode.E)){
            if(elevator.ground){
                elevator.SetGround(false);
            }else{
                elevator.SetGround(true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            characterStay = false;
        }
    }
}
