using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFactory : MonoBehaviour
{
    public GameObject original;
    public int count = 10;
    private void OnMouseDown() {
        for(int i  = 0;  i < count; ++i)
        {
            GameObject clone = Instantiate(original);
            clone.transform.position = new Vector3(0, i, 0);
        }
    }
}
