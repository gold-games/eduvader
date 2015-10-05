using UnityEngine;
using System.Collections;
using System.Xml;

public class AIzinnen : MonoBehaviour {

    public Transform target;
    bool hit = false;
    string vraag;
    string antwoord1;
    string antwoord2;
    string antwoord3;
    string antwoord4;
    string goed;
    string attempt;
    public GameObject pp;
    public GameObject ps;
    public GameObject prc;
    public GameObject psc;

    void Awake () {
		var doc = new XmlDocument(); // create an empty doc
		doc.Load("Assets/Resources/questions.xml");
		var baseNode = doc.DocumentElement;// load the doc, dbPath is a string
		int nNodes = baseNode.ChildNodes.Count;
		// Use this for initialization
		var number = Random.Range (1, 5);
		XmlNodeList xnList = doc.SelectNodes("/Questions/Question[@id='"+number+"' and @type='sp']");
		while (!hit){
		if (xnList.Count == 0) {
		number = Random.Range (1, 5);
		xnList = doc.SelectNodes("/Questions/Question[@id='"+number+"' and @type='sp']");
		} else {
				hit = true;
			}
		if (hit) {
			foreach (XmlNode node in xnList) {
			       /*Debug.Log(node.Name);
                   Debug.Log(node.SelectSingleNode("text").InnerText);
                   Debug.Log(node.SelectSingleNode("option1").InnerText);
                   Debug.Log(node.SelectSingleNode("option2").InnerText);
                   Debug.Log(node.SelectSingleNode("option3").InnerText);
                   Debug.Log(node.SelectSingleNode("option4").InnerText);
                   Debug.Log(node.SelectSingleNode("answer").InnerText);*/
                    vraag = (node.SelectSingleNode ("text").InnerText);
				antwoord1 = (node.SelectSingleNode ("option1").InnerText);
                antwoord2 = (node.SelectSingleNode ("option2").InnerText);
                antwoord3 = (node.SelectSingleNode ("option3").InnerText);
                antwoord4 = (node.SelectSingleNode("option4").InnerText);
                     goed = (node.SelectSingleNode ("answer").InnerText);
                    Debug.Log(antwoord1);

                }
		}
		}
	}
    void Start()
    {
        prc = ()prc.GetComponent("presentcontinuous");
    }

    public string pastsimple()
    {
        Debug.Log(antwoord1);
        return antwoord1;
    }
    public string presentperfect()
    {
        Debug.Log(antwoord2);
        return antwoord2;
    }
    public string presentcontinuous()
    {
        Debug.Log(antwoord3);
        return antwoord3;
    }
    public string pastcontinuous()
    {
        Debug.Log(antwoord4);
        return antwoord4;
    }

    // Update is called once per frame
    void Update()
    {
        
        attempt = getAttempt;

        if (goed == attempt)
        {
            Destroy(this.gameObject);
            Time.timeScale = 1;
        }
       /* if ()
        {
            attempt = antwoord1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            attempt = antwoord2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            attempt = antwoord3;

        }*/
    }
    void OnGUI()
    {
        Vector3 getPixelPos = Camera.main.WorldToScreenPoint(target.position);
        getPixelPos.y = Screen.height - getPixelPos.y;
       // getPixelPos.x = Screen.width - getPixelPos.x;
        GUI.Label(new Rect(getPixelPos.x, getPixelPos.y + 00, 300f, 300f), vraag);
       /* GUI.Label(new Rect(getPixelPos.x-150, getPixelPos.y +25, 250f, 250f), antwoord1);
        GUI.Label(new Rect(getPixelPos.x, getPixelPos.y+25, 200f, 200f), antwoord2);
        GUI.Label(new Rect(getPixelPos.x+150, getPixelPos.y+25, 150f, 150f), antwoord3);
        GUI.Label(new Rect(getPixelPos.x+300, getPixelPos.y+25, 100f, 100f), antwoord4);*/
    }
}
