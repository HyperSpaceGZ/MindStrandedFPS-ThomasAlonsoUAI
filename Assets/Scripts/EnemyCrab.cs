using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCrab : MonoBehaviour
{
    public Text DeadPlayerUI;
    public int CrabHealth = 8;

    //Player Lives Info
    public int Lives;
    public Text LivesNumberText;
    void Start()
    {
        DeadPlayerUI.enabled = false;
        Lives = 3;
    }

    void Update()
    {
        LivesNumberText.text = "" + (int)Lives;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PistolBullet"))
        {
            CrabHealth--;
            
            if(CrabHealth < 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PistolShoot>().WhenEnemyIsKilled();

                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            WhenEnemyHitsPlayer();
        }
    }

    public void WhenEnemyHitsPlayer()
    {
        Lives--;

        if (Lives < 0)
        {
            Time.timeScale = 0;
            DeadPlayerUI.enabled = true;
        }
    }
}


