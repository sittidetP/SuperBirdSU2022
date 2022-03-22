using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myGoal : MonoBehaviour
{
    public int score = 0;
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.tag == "Ball")
        {
            score++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            score++;
            Destroy(other.gameObject);
        }
    }
}
