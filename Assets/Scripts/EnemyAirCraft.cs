using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirCraft : MonoBehaviour
{
    public GameObject enemy1Bullet;
    public Transform []gunPoint;
    
    public float blulletTimeSpawn = 0.5f;
    public GameObject muzzleFlash;
    public float enemySpeed = 1f;
    public GameObject explosion;
    GameObject enemyExplosion;
    public float health = 10f;
    float barSize = 1f;
    float damage = 0f;
    public HealthBar healthbar;
    public GameObject damageEffect;
    public GameObject coinPrefab;
    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioSource audioSource;





    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash.SetActive(false);
        StartCoroutine(Enemy1Shoot());
        damage = barSize / health;

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * enemySpeed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet") 
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
        HealthbarDamage();
        Destroy(collision.gameObject);
           GameObject damageVFX = Instantiate(damageEffect,collision.transform.position, Quaternion.identity);
            Destroy(damageVFX,0.05f);
            if (health <= 0)
            { 
            AudioSource.PlayClipAtPoint(explosionSound,Camera.main.transform.position,0.5f);
            Destroy(gameObject);
            enemyExplosion = Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(enemyExplosion,0.4f);
            Instantiate(coinPrefab,transform.position, Quaternion.identity);
            }
        }
       
    }

    void HealthbarDamage () 
    {
    if(health > 0)
    {
        health -= 1;
        barSize = barSize - damage;
        healthbar.SetSize(barSize);
    }
    }

    void Enemy1Fire() 
    {
        for (int i = 0; i < gunPoint.Length; i++)
        {
            Instantiate(enemy1Bullet, gunPoint[i].position, Quaternion.identity);


        }
    /*Instantiate(enemy1Bullet,enemyBulletSpawn1.position,Quaternion.identity);
    Instantiate(enemy1Bullet,enemyBulletSpawn2.position,Quaternion.identity);  */ 
    }

    IEnumerator Enemy1Shoot()
    {
        while (true)
        { 
        yield return new WaitForSeconds(blulletTimeSpawn);
        Enemy1Fire();
            audioSource.PlayOneShot(bulletSound, 0.5f);
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.SetActive(false);
        }

        
    }
}
