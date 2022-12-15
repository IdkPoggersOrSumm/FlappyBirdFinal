using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
   
{
    private Rigidbody2D rb2d; 
    private bool isDead = false;
    public float upForce = 200f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
     if (isDead == false)
     {
       if (Input.GetMouseButtonDown (0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");

            }
     }
        
    }
    void OnCollisionEnter2D()
    {
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
