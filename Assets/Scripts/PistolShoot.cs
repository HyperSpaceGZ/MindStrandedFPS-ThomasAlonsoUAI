using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PistolShoot : MonoBehaviour
{
    //GameObjects
    public GameObject Bullet;
    public Transform BulletSpawner;
    public GameObject AmmoPack;

    //Bullet Info
    public float BulletForce;
    public int Bullets;
    public Text BulletText;

    //Kills Info
    public int KillCount = 0;
    public Text KillCountText;

    //Lives Info
    public int Lives;
    public Text LivesNumberText;

    //Win Text
    public Text WinText;
    
    void Start()
    {
        WinText.enabled = false;
        Bullets = 20;
        Lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        BulletText.text = "Bullets: " + (int)Bullets;

        if (Input.GetMouseButtonDown(0) && Bullets>0)
        {
            Bullets--;

            if(Bullets > 0)
            {
                GameObject bulletClone = Instantiate(Bullet, BulletSpawner.position, BulletSpawner.rotation);
                Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();
                bulletRB.AddRelativeForce(Vector3.forward * BulletForce, ForceMode.Impulse);

            }

        }

        if (Input.GetKeyDown("r"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
            KillCount = 0;
            Cursor.lockState = CursorLockMode.None;

        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            Application.Quit();
        }
    }

    public void WhenPicksUpAmmo()
    {
        Bullets = 20;
    }

    public void WhenEnemyIsKilled()
    {
        KillCount++;
        KillCountText.text = "Kills: " + (int)KillCount;

        if (KillCount == 6)
        {
            Time.timeScale = 0;
            WinText.enabled = true;
        }
    }

}
