using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public Camera cam;

    void Update()
    {
        //vigebt mausis pozicias
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);

        //vigebt ra mimartulebit gvinda srola
        Vector3 direction = mouse - firePoint.position;
        
        //mimartulebas kutxes vucvlit
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //da am firepoints mausisken vatrialebt
        firePoint.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
