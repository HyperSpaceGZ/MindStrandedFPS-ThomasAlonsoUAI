using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PistolShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletSpawner;
    public float BulletForce;
    public int KillCount = 0;
    public Text KillCountText;
    public Text WinText;
    
    void Start()
    {
        WinText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(Bullet, BulletSpawner.position, BulletSpawner.rotation);
            Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();
            bulletRB.AddRelativeForce(Vector3.forward * BulletForce, ForceMode.Impulse);
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
