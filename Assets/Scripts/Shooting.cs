using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float bulletSpawnTime = 1f;
    public GameObject muzzleflash;
    public AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        muzzleflash.SetActive(false);
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Fire()
    {
        Instantiate(playerBullet, spawnPoint1.position, Quaternion.identity);
        Instantiate(playerBullet, spawnPoint2.position, Quaternion.identity);
        /*muzzleflash1.SetActive(true);
        muzzleFlash2.SetActive(true);
        muzzleflash1.SetActive(false);
        muzzleFlash2.SetActive(false);*/
    }
    IEnumerator Shoot() 
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            audioSource.Play();
            muzzleflash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            muzzleflash.SetActive(false);

        }
        //StartCoroutine(Shoot());
    }
}
