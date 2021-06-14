using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCube : MonoBehaviour
{
    public int index;

    void Update()
    {
        if (index == 1){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "block"){
            index = 1;
       }
    }
}
