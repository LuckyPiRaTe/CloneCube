using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   private PlayerSwape _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    [SerializeField] private float speed = 0f;
    public GameObject startPanel;
    public GameObject winPanel;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<PlayerSwape>();
    }

    private void Update()
    {
        if (transform.position.x < -9.5f){
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 9.5f){
            transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
        }
        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, speed * Time.deltaTime);
        
    }

    public void StartGame(){
        speed = 12f;
        startPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish"){
            speed = 0;
            winPanel.SetActive(true);
        }
    }
}