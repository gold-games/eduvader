using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class AIzinnen : MonoBehaviour
{
    //LEER GOED CODEREN!!!! ohja, en commenten.... begrijp je code... vraag Djurdjus om betere uitleg.
   
    //  public List<GameObject> wordList = new List<GameObject>();
    [SerializeField]
    TextAsset questions;
    public Transform target;
    public GameObject volcano;
    public GameObject zinvak;
    public GameObject prp;
    public GameObject pas;
    public GameObject prec;
    public GameObject pasc;
    bool hit = false;
    bool next = true;
    bool correct = false;
    string vraag;
    public string levelToLoad = "";
    string antwoord1, antwoord2, antwoord3, antwoord4;
    string goed;
    string attempt4, attempt1, attempt2, attempt3;
    string getAttempt;
    int number;
    int tries = 0;
    XmlDocument doc = new XmlDocument(); // create an empty doc
    XmlNodeList xnList;
    presentcontinuous prc;
    presentperfect pp;
    pastsimpel ps;
    pastcontinuous pc;



    //XmlDocument doc;
    void Awake()
    {

        doc.LoadXml(questions.text);
        XmlNode baseNode = doc.DocumentElement;// load the doc, dbPath is a string
        int nNodes = baseNode.ChildNodes.Count;
        // Use this for initialization
        number = Random.Range(1, 10);
        xnList = doc.SelectNodes("/Questions/Question[@id='" + number + "']");
        while (!hit)
        {
            if (xnList.Count == 0)
            {
                number = Random.Range(1, 10);
                xnList = doc.SelectNodes("/Questions/Question[@id='" + number + "']");
            }
            else
            {
                hit = true;
            }
            if (hit)
            {
                foreach (XmlNode node in xnList)
                {
                    vraag = (node.SelectSingleNode("text").InnerText);
                    antwoord1 = (node.SelectSingleNode("option1").InnerText);
                    antwoord2 = (node.SelectSingleNode("option2").InnerText);
                    antwoord3 = (node.SelectSingleNode("option3").InnerText);
                    antwoord4 = (node.SelectSingleNode("option4").InnerText);
                    goed = (node.SelectSingleNode("answer").InnerText);
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

        Health eh = (Health)volcano.GetComponent("Health");


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
        if (next)
        {
            NewQuestion();
           
        }
        attempt3 = prc.getAttempt();
        attempt2 = pp.getAttempt();
        attempt1 = ps.getAttempt();
        attempt4 = pc.getAttempt();
        if (!correct)
        {
            if (attempt4 != null || attempt1 != null || attempt2 != null || attempt3 != null)
            {
                if (goed == attempt3 || goed == attempt1 || goed == attempt2 || goed == attempt4)
                {
                   
                    next = true;
                    correct = true;
                    Debug.Log("NewQuestion");

                }
                else if (goed != attempt4 && goed != attempt1 && goed != attempt2 && goed != attempt3)
                {
                    Health eh = (Health)volcano.GetComponent("Health");
                    eh.ModifyHealth(-1);
                     next = true;
                    
                    correct = true;
                       if(eh.currentHealth == 0)
                   {
                       Application.LoadLevel(levelToLoad);
                   }
                   
                }

            }


        }


    }
    /**/
    void NewQuestion()
    {
        Debug.Log("HELP ME");
        while (!hit)
        {
            Debug.Log("not hit");
            number = Random.Range(1, 10);
            xnList = doc.SelectNodes("/Questions/Question[@id='" + number + "']");
            if (xnList.Count == 0)
            {
                hit = false;
                Debug.Log("no question");
            }
            else
            {
                Debug.Log("got question");
                hit = true;
            }
            if (hit)
            {
                foreach (XmlNode node in xnList)
                {
                    vraag = (node.SelectSingleNode("text").InnerText);
                    antwoord1 = (node.SelectSingleNode("option1").InnerText);
                    antwoord2 = (node.SelectSingleNode("option2").InnerText);
                    antwoord3 = (node.SelectSingleNode("option3").InnerText);
                    antwoord4 = (node.SelectSingleNode("option4").InnerText);
                    goed = (node.SelectSingleNode("answer").InnerText);
                    Debug.Log("change text");
                }
            }
        }
        next = false;
        hit = false;
        correct = false;
        attempt3 = null;
        attempt1 = null;
        attempt2 = null;
        attempt4 = null;
        pp.setattempt(null);
        prc.setattempt(null);
        ps.setattempt(null);
        pc.setattempt(null);
    }

    void OnGUI()
    {
        Vector3 getPixelPos = Camera.main.WorldToScreenPoint(target.position);
        getPixelPos.y = Screen.height - getPixelPos.y;

        GUI.Label(new Rect(getPixelPos.x + 50, getPixelPos.y - 235, 300f, 300f), vraag);

    }


}
