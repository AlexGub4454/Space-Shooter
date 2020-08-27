using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int healthPoint = 500;
    [SerializeField] float minTime = 0.2f;
    [SerializeField] float maxTime = 1f;
    [SerializeField] int score=150;
    [SerializeField] float currentTime;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletVelocity=10f;
    [SerializeField] AudioClip Clip;
    [SerializeField] [Range(0, 1)] float VoiceSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            if (!damageDealer)
                return;
            healthPoint -= damageDealer.GetDamage();
            if (healthPoint <= 0)
            {
                GameSession session = FindObjectOfType<GameSession>();
                session.AddScore(150);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position, VoiceSound);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        Fire();   
    }

    private void Fire()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            GameObject laser = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            laser.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletVelocity );
            currentTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
