using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMinion : MonoBehaviour
{
    public int MinionHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PistolBullet"))
        {
            MinionHealth--;

            if (MinionHealth < 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PistolShoot>().WhenEnemyIsKilled();

                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("EnemyCrab").GetComponent<EnemyCrab>().WhenEnemyHitsPlayer();
        }
    }
}
