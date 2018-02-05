using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject particle;
    public float boomTime;
    private float currentBoomTime;
    private bool boom;

    void Start()
    {
        boom = false;
        currentBoomTime = 0;
        particle.SetActive(false);
        particle.transform.position = new Vector3(0,0,0);
        particle.transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if(boom)
        {
            if(currentBoomTime < boomTime)
            {
                particle.transform.localScale = new Vector3(currentBoomTime*15, currentBoomTime*15, currentBoomTime*15);

                currentBoomTime += Time.deltaTime;
            }else
            {
                gameObject.SetActive(false);
                boom = false;
                currentBoomTime = 0;
                particle.SetActive(false);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        particle.transform.position = gameObject.transform.position;
        particle.SetActive(true);
        boom = true;
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
