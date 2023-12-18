using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmanger : MonoBehaviour
{
    public int loaderbyfalling;
    public GameObject yourButton;

    public void StartButtooon()
    {
        SceneManager.LoadScene(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(loaderbyfalling);
        }
    }
}
