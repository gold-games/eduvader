﻿using UnityEngine;
using System.Collections;

public class presentperfect : MonoBehaviour
{
    public GameObject zinvak;
    public Transform target;
    AIzinnen ps;
    string presentperfect1;
    string attempt;
    // Use this for initialization
    void Start()
    {
        ps = (AIzinnen)zinvak.GetComponent("AIzinnen");
        presentperfect1 = ps.presentperfect();

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
        GUI.Label(new Rect(getPixelPos.x - 35, getPixelPos.y - 55, 300f, 300f), presentperfect1);
    }
    void OnCollisionEnter(Collision Collision)
    {

        GameObject.Destroy(Collision.gameObject);
        //  GameObject.Destroy(this.gameObject);
        //attempt = presentcontinuous1;
        //poging = true;
        setattempt(presentperfect1);


    }
    public void setattempt(string atwrd)
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
