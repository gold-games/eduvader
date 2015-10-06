using UnityEngine;
using System.Collections;

public class pastcontinuous : MonoBehaviour {

    public GameObject zinvak;
    public Transform target;
    AIzinnen ps;
    string attempt;
    string pastcontinuous1;
    
    // Use this for initialization
    void Start()
    {
        ps = (AIzinnen)zinvak.GetComponent("AIzinnen");
        pastcontinuous1 = ps.pastcontinuous();
       
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
        GUI.Label(new Rect(getPixelPos.x, getPixelPos.y + 00, 300f, 300f), pastcontinuous1);
    }
    void OnCollisionEnter2D(Collision2D Collision)
    {

        GameObject.Destroy(Collision.gameObject);
        //  GameObject.Destroy(this.gameObject);
        //attempt = presentcontinuous1;
        //poging = true;
        setattempt(pastcontinuous1);


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
