﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Umrzyj : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Umrzyj")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}