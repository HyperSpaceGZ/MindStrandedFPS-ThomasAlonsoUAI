using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    public float BulletDespawnTime = 0f;
    // Update is called once per frame
    void Update()
    {
        BulletDespawnTime += Time.deltaTime;
        if (BulletDespawnTime >= 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
