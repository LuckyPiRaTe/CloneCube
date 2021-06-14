using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject losePanel;
    public Animator animator;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "flor"){
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "block"){
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
