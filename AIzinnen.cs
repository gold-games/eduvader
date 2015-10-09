using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class AIzinnen : MonoBehaviour {

 //  public List<GameObject> wordList = new List<GameObject>();
  
    public Transform target;
    bool hit = false;
    string vraag;
    string antwoord1, antwoord2, antwoord3, antwoord4;
    string goed;
    string attempt, attempt1, attempt2, attempt3;
    public GameObject prp;
    public GameObject pas;
    public GameObject prec;
    public GameObject pasc;
    presentcontinuous prc;
    presentperfect pp;
    pastsimpel ps;
    pastcontinuous pc;
    string getAttempt;
    int tries = 0;

    void Awake () {
		var doc = new XmlDocument(); // create an empty doc
		doc.Load("Assets/scripts/questions.xml");
		var baseNode = doc.DocumentElement;// load the doc, dbPath is a string
		int nNodes = baseNode.ChildNodes.Count;
		// Use this for initialization
		var number = Random.Range (1, 10);
		XmlNodeList xnList = doc.SelectNodes("/Questions/Question[@id='"+number+"' and @type='sp']");
		while (!hit){
		if (xnList.Count == 0) {
		number = Random.Range (1, 10);
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
        

        prc = (presentcontinuous)prec.GetComponent("presentcontinuous");
        pp = (presentperfect)prp.GetComponent("presentperfect");
        ps = (pastsimpel)pas.GetComponent("pastsimpel");
        pc = (pastcontinuous)pasc.GetComponent("pastcontinuous");

        /*wordList.Add( new GameObject ("presentcontinuous", ));
        wordList.Add( new GameObject ("presentperfect", ));
        wordList.Add( new GameObject ("pastsimple",antwoord1));
        wordList.Add( new GameObject ("pastcontinuous",antwoord4));*/

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
        attempt = prc.getAttempt();
        attempt1 = pp.getAttempt();
        attempt2 = ps.getAttempt();
        attempt3 = pc.getAttempt();
     /*   if(attempt != goed)
        {
            tries++;
        }
        if (attempt1 != goed)
        {
            tries++;
        }
        if (attempt2 != goed)
        {
            tries++;
        }
        if (attempt3 != goed)
        {
            tries++;
        }*/
       // if (tries <= 3 )
      //  {
            if (goed == attempt || goed == attempt2 || goed == attempt2 || goed == attempt3)
            {
                Destroy(this.gameObject);
        
            }
      // }
     
    }
    

    void OnGUI()
    {
        Vector3 getPixelPos = Camera.main.WorldToScreenPoint(target.position);
        getPixelPos.y = Screen.height - getPixelPos.y;
  
        GUI.Label(new Rect(getPixelPos.x -60, getPixelPos.y+40 + 00, 300f, 300f), vraag);
     
    }

  
}
