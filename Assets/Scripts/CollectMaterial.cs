using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectMaterial : MonoBehaviour
{
    public TextMeshProUGUI pickupText;
    public GameObject player;
    public string objectType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (objectType == "Circle")
            {
                player.GetComponent<PlayerMovement>().pickup1Counter += 1;
                pickupText.text = player.GetComponent<PlayerMovement>().pickup1Counter.ToString() + "/2";
                this.gameObject.SetActive(false);
            }
            else if(objectType == "Square")
            {
                player.GetComponent<PlayerMovement>().pickup2Counter += 1;
                pickupText.text = player.GetComponent<PlayerMovement>().pickup2Counter.ToString() + "/2";
                this.gameObject.SetActive(false);
            }
        }
    }
}
