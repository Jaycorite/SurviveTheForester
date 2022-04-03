using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{
    public WinHud winHud;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            winHud.gameObject.SetActive(true);
            StartCoroutine(waitSec());

        }
    }


    public IEnumerator waitSec()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            winHud.gameObject.SetActive(true);
        }
    }*/
}
