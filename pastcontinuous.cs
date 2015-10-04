using UnityEngine;
using System.Collections;

public class pastcontinuous : MonoBehaviour {

    public GameObject zinvak;
    public Transform target;
    AIzinnen ps;
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
}
