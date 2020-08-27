using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float movespeed;
    [SerializeField]
    float padding=1f;
    [SerializeField]
    GameObject LaserPrefab;
    [SerializeField]
    float LaserSpeed = 20f;
    Coroutine coroutine;
    [SerializeField] int healthPoint = 500;
    [SerializeField] float timeBetweenShots=0.01f;
    [SerializeField] AudioClip Clip;
    [SerializeField] [Range(0, 1)] float VoiceSound;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            if (!damageDealer)
                return;
            healthPoint -= damageDealer.GetDamage();
            if (healthPoint <= 0)
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position, VoiceSound);
                StartCoroutine(Level.Wait());
                SceneManager.LoadScene(2);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

        Move();
         Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
         coroutine = StartCoroutine(FireCorountine());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(coroutine);
        }


    }

    IEnumerator FireCorountine()
    {
        while (true)
        {
            GameObject laser = Instantiate(LaserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, LaserSpeed);
            yield return new WaitForSeconds(timeBetweenShots);
        }
        
    }

    void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movespeed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }
    void SetUpMoveBoundaries()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
