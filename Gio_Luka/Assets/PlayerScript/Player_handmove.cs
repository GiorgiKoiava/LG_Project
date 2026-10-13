using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_handmove : MonoBehaviour
{
    public Animator anim;
    public float rotationSpeed;
    public Camera cam;


    void Update()
    {
        {
            //vigebt sada mausi tamasshi
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            //mimartuleba  xelidan mausisken
            Vector2 direction = mousePos - transform.position;

            //vitvlit xelis brunvas kutxes
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            //xels vatrialebt mausis mimartulebit
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            anim.SetBool("Up", direction.y > Mathf.Abs(direction.x));
            anim.SetBool("Down", -direction.y > Mathf.Abs(direction.x));
            anim.SetBool("Right", direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y));
            anim.SetBool("Left", direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y));
        }
    }
}
