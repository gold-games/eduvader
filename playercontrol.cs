using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour {
    private Rigidbody2D m_Rigidbody2D;
    public GameObject bullet;
        int shots=0;
        int maxshots= 3;
    public float Speed = 0f;
    private float movex = 0f;
    

    // Use this for initialization
    void Awake () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
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
    
       

        if (Input.GetKeyDown(KeyCode.Space) && shots < maxshots)
        {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
            shots++;
        }
    
    }
}
