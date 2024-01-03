using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public PlayerHealthbarScript playerHealthbar;
    public float speed = 10f;
    float minX; 
    float maxX;
    float minY;
    float maxY;
    float padding = 0.8f;
    public GameObject damageEffect;
    public GameObject explosion;
    public float health = 20f;
    float barFillAmount = 1f;
    float damage = 0;
    public CoinCount coinCountScript;
    public GameController gameController;
    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;



    void Start()
    {
        FindBoundries();
        damage = barFillAmount / health;
    }
    void FindBoundries()
    {
        Camera cam = Camera.main;
        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        minY = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding -0.2f;
        maxY = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding + 0.2f;
    }

    // Update is called once per frame
    void Update()
    {


        // android Input SYS
        if (Input.GetMouseButton(0))
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = Vector2.Lerp(transform.position, newPos, 50 * Time.deltaTime);
            
            transform.position = new Vector3(Mathf.Clamp(transform.position.x , minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), -0.2f);
        }
        /*float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // PC Input SYS
        float newXpos = Mathf.Clamp(transform.position.x + deltaX , minX, maxX);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, minY,maxY);


        transform.position = new Vector3 (newXpos, newYPos, -0.13f);*/

        /* Vector3 PlayerPos = transform.position;
         PlayerPos.x = Mathf.Clamp(PlayerPos.x, minX, maxX);
         PlayerPos.y = Mathf.Clamp(PlayerPos.y,minY,maxY);
         transform.position = PlayerPos;*/



        //transform.position = new Vector2 (0, newYPos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ( collision.gameObject.tag == "EnemyBullet") 
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
            DamagePlayerHealthbar();
            Destroy(collision.gameObject);
            
            GameObject damageVFX =  Instantiate(damageEffect,collision.transform.position,Quaternion.identity);
            Destroy(damageVFX,0.05f);

            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound,Camera.main.transform.position, 0.5f);
                Destroy(gameObject);
                GameObject blast = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(blast, 2f);
                gameController.GameOver();
            }
            
            
        }

        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound, 0.5f);
            Destroy(collision.gameObject);
            coinCountScript.AddCount();
        }
    }
    void DamagePlayerHealthbar()
    {
        if (health > 0 )
        {
            health -= 1;
            barFillAmount = barFillAmount - damage;

            playerHealthbar.SetAmount(barFillAmount);
        }
    }
}
