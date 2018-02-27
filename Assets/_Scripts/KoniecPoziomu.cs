using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoniecPoziomu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "Poziom1")
            {
                SceneManager.LoadScene("Poziom2", LoadSceneMode.Single);
            }
            if (SceneManager.GetActiveScene().name == "Parkour")
            {
                SceneManager.LoadScene("Parkour 2", LoadSceneMode.Single);
            }
            if (SceneManager.GetActiveScene().name == "Parkour 2")
            {
                SceneManager.LoadScene("MenuGL", LoadSceneMode.Single);
            }
        }
    }
}
