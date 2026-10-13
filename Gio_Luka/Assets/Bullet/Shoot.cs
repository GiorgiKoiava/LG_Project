using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 25f;
    public float lifeTime = 1f;

    private Vector2 direction;

    public void Shooting(Vector2 dir)
    {
        direction = dir.normalized;

        float angle = Mathf.Atan2(
            dir.y, dir.x
        ) * Mathf.Rad2Deg;

        transform.rotation =
            Quaternion.Euler(0, 0, angle);
    }

    void Update()
    {
        transform.Translate(
            Vector2.right * speed * Time.deltaTime
        );

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
            Destroy(gameObject);
    }
}
