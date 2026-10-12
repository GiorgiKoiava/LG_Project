using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float playerSpeed;
    
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 V3 = new Vector3(x, y, 0).normalized;
        transform.position += V3 * playerSpeed * Time.deltaTime;
    }
}
