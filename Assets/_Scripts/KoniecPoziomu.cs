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

    private void Kolizja (Collision2D kolider)
    {
        SceneManager.LoadScene("MenuGL", LoadSceneMode.Single);
    }
}
