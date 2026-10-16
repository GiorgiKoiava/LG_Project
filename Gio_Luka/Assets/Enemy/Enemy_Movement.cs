using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_Movement : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public Slider health;
    public GameObject Explousen;
    public GameObject xpPrefab;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health.maxValue = 4;
        health.value = 4;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GunBullet"))
        {
            if (collision.CompareTag("GunBullet"))
            {
                StartCoroutine(SmoothDamage());
                Destroy(collision.gameObject);
            }
        }
    }

    IEnumerator SmoothDamage()
    {
        float newValue = Mathf.Max(0, health.value - 1);

        while (health.value > newValue)
        {
            health.value = Mathf.MoveTowards(health.value, newValue, 7f * Time.deltaTime);

            yield return null;
        }

        if (health.value <= 0)
        {
            int orbCount = Random.Range(1, 5); 

            //meordeba imdenjer ramdeni xpc unda gachndes
            for (int i = 0; i < orbCount; i++)
            {
                //qmnis dashorebas chonchixs pozicidan
                Vector2 randomOffset = Random.insideUnitCircle * 0.5f;

                GameObject xp = Instantiate(xpPrefab, (Vector2)transform.position + randomOffset, Quaternion.identity);

                Rigidbody2D rb = xp.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    Vector2 direction = Random.insideUnitCircle.normalized;

                    rb.AddForce(direction * Random.Range(1.5f, 3f), ForceMode2D.Impulse);
                }
            }

            Instantiate(Explousen, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
