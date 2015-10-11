using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour {
    private Rigidbody2D m_Rigidbody2D;
    public GameObject bullet;
    Animator anim;
    public float Speed = 0f;
    private float movex = 0f;
    bool facingRight = true;
    bool walking;
    bool throwing;

    // Use this for initialization
    void Awake () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame

	void Update () {
        /*  if (Input.GetKeyDown(KeyCode.LeftArrow))
          {
              Vector3 position = this.transform.position;
              position.x--;
              this.transform.position = position;
          }
          if (Input.GetKeyDown(KeyCode.RightArrow))
          {
              Vector3 position = this.transform.position;
              position.x++;
              this.transform.position = position;
          }*/
       
        movex = Input.GetAxis("Horizontal");
       
        m_Rigidbody2D.velocity = new Vector2(movex * Speed, 0);
        //walking = false;
        if (movex > 0 && facingRight)
        {
            anim.SetBool("walking", true);
            Flip();
        }
        else if (movex < 0 && !facingRight)
        {
            anim.SetBool("walking", true);
            Flip();
        }
        else if(movex == 0)
        {
            anim.SetBool("walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("throwing", true);
            Instantiate(bullet, this.transform.position, Quaternion.identity);
        }
        else
        {
            anim.SetBool("throwing", false);
        }
    
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
