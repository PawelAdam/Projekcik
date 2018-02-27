using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

    public GameObject ordinary;
    public GameObject premium;

    private bool premiumStatus;

    void Start() {
        premiumStatus = false;
        premium.SetActive(false);
    }

    private void Switch()
    {
        if(premiumStatus)
        {
            premium.SetActive(false);
            ordinary.SetActive(true);
            premiumStatus = false;
        }else
        {
            premium.SetActive(true);
            ordinary.SetActive(false);
            premiumStatus = true;
        }
    }
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Switch();
        }
    }
}
