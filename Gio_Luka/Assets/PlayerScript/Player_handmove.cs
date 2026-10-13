using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_handmove : MonoBehaviour
{
    public Animator anim;
    public float rotationSpeed;
    public Camera cam;
    public SpriteRenderer hand, pl;
   


    void Update()
    {
        //vigebt sada mausi tamasshi
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.y < transform.parent.position.y)
        {
            hand.sortingOrder = 1;
        }
        else
        {
            hand.sortingOrder = -1;
        }

        if(mousePos.x < transform.parent.position.x)
        {
            hand.transform.localScale = new Vector2(1.150901f, 1.134248f);
        }
        else
        {
            hand.transform.localScale = new Vector2(-1.150901f, 1.134248f);
        }

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
