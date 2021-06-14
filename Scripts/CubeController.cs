using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    public GameObject cube;
    public GameObject player;
    public GameObject road;
    public int money;
    public Text moneyText;
    public int index;
    public GameObject pl;
    public Animator plAnim;
    public Animator floarAnim;
    

    void Update()
    {
        moneyText.text = "" + money;
        index = transform.childCount - 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cube"){
            index += 1;
            pl.transform.position = new Vector3(transform.position.x, 2f * (index + 2), transform.position.z);
            GameObject a = Instantiate(cube, new Vector3(player.transform.position.x, 2f * index , player.transform.position.z), Quaternion.identity);
            a.transform.SetParent(player.transform);

            Destroy(other.gameObject);
            plAnim.Play("jump-float");
        }
        
        if (other.tag == "money"){
            money++;
            Destroy(other.gameObject);
        }
        if (other.tag == "rotate" ){
            floarAnim.SetBool("isAnim" , true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "rotate" ){
            floarAnim.SetBool("isAnim" , false);
        }
    }   
}
