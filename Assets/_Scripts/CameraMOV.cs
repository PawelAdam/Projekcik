﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMOV : MonoBehaviour {

    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0,speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            transform.Translate(new Vector3(0,-speed * Time.deltaTime));
        }

    }
}
