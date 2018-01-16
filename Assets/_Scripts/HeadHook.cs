using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadHook : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            transform.parent.GetComponent<Hook>().TriggerEnter(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            transform.parent.GetComponent<Hook>().TriggerExit(this);
        }
    }
}
