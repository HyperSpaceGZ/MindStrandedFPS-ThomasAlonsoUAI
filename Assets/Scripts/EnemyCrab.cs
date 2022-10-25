using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCrab : MonoBehaviour
{
    public Text DeadPlayerUI;
    public int CrabHealth = 5;
    void Start()
    {
        DeadPlayerUI.enabled = false;
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
            Time.timeScale = 0;
            DeadPlayerUI.enabled = true;
        }
    }
}
