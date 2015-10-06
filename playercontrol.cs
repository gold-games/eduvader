using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour {
    private Rigidbody2D m_Rigidbody2D;
    public GameObject bullet;
        int shots=0;
        int maxshots= 3;
    // Use this for initialization
    void Awake () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame

	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
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
        }
       

        if (Input.GetKeyDown(KeyCode.Space) && shots < maxshots)
        {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
            shots++;
        }
      /*  else if (shots >= maxshots && Input.GetKeyDown(KeyCode.R))
        {
            shots = 0;
        }*/
    }
}
