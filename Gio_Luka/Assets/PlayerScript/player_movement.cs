 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_movement : MonoBehaviour
{
    public float playerSpeed, RunSpeed;
    public Animator animator;
    public Camera cam;
    public float run_speed_coef;
    public float stamina;
    public Slider staminaBar;
    public SpriteRenderer sR;
    public Player_shoot PSH;
    public Text xpText;
    public int xp = 0;
    void Update()
    {
        Movement();
    }
    private void Start()
    {
        staminaBar.maxValue = 100;
        staminaBar.value = stamina;
    }
    void Movement()
    {
        {
            #region WALKING
            
                    float x = Input.GetAxisRaw("Horizontal");
                    float y = Input.GetAxisRaw("Vertical");
                    

                    Vector3 V3 = new Vector3(x, y, 0).normalized;
            #endregion
            #region run_anim
            if (y > 0)
            {
                animator.SetBool("back", true);
                animator.SetBool("forward", false);
            }
            else if (y < 0)
            {
                animator.SetBool("forward", true);
                animator.SetBool("back", false);
            }
            else
            {
                animator.SetBool("forward", false);
                animator.SetBool("back", false);
            }

            if (x > 0)
            {
                animator.SetBool("right", true);
                sR.flipX = false;
            }

            else if (x < 0)
            {
                animator.SetBool("right", true);
                sR.flipX = true;
            }
            else
            {
                animator.SetBool("right", false);
            }
            


            #endregion
            #region RUNNING
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
                {              
                    transform.position += V3 * playerSpeed * run_speed_coef * Time.deltaTime;
                    stamina -= 5 * Time.deltaTime;
                    stamina = Mathf.Clamp(stamina, 0, 100);
                    staminaBar.value = stamina;

                }
                else
                {
                    transform.position += V3 * playerSpeed * Time.deltaTime;
                    stamina += 2 * Time.deltaTime;
                    stamina = Mathf.Clamp(stamina, 0, 100);
                    staminaBar.value = stamina;
                }
            
        #endregion
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletBox"))
        {
            PSH.bulletCount += 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("XP"))
        {
            xp += 1;
            xpText.text = "" + xp;
            Destroy(collision.gameObject);
        }
    }
}
