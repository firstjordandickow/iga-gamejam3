using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public int sceneNumber;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(collision.GetComponent<PlayerMovement>().pickup1Counter == collision.GetComponent<PlayerMovement>().totalItem1
                && collision.GetComponent<PlayerMovement>().pickup2Counter == collision.GetComponent<PlayerMovement>().totalItem2)
            {
                SceneManager.LoadScene(sceneNumber);
            }
        }
    }
}
