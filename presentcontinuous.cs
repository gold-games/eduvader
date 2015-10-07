using UnityEngine;
using System.Collections;

public class presentcontinuous : MonoBehaviour
{

    public GameObject zinvak;
    public Transform target;
    AIzinnen ps;
    string presentcontinuous1;
 string attempt;
   // bool poging = false;
    // Use this for initialization
    void Start()
    {
        ps = (AIzinnen)zinvak.GetComponent("AIzinnen");
        presentcontinuous1 = ps.presentcontinuous();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        Vector3 getPixelPos = Camera.main.WorldToScreenPoint(target.position);
        getPixelPos.y = Screen.height - getPixelPos.y;
        // getPixelPos.x = Screen.width - getPixelPos.x;
        GUI.Label(new Rect(getPixelPos.x - 50, getPixelPos.y - 55, 300f, 300f), presentcontinuous1);
    }
   
    void OnCollisionEnter2D(Collision2D Collision)
    {

        GameObject.Destroy(Collision.gameObject);
      //  GameObject.Destroy(this.gameObject);
        //attempt = presentcontinuous1;
        //poging = true;
        setattempt(presentcontinuous1);
       

    }
    void setattempt(string atwrd)
    {
            attempt = atwrd;
        Debug.Log(attempt);
    }

    public string getAttempt()
    {
        Debug.Log(attempt);
        return attempt;
    }
   
}