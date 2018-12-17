using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyScript : MonoBehaviour {

    public InputField inputID;
    public InputField inputName;
    public InputField inputDescription;
    public InputField inputPhoto;
    public static MyScript Istance;
    public TextMeshProUGUI text;
    public List<string> admirals;
    public List<string> ships;
    public List<string> commods;
    public GameObject buttonAdmiral;
    public GameObject buttonShip;
    public GameObject buttonComond;
    public GameObject buttonAddAdmiral;
    public GameObject buttonAddShip;
    public GameObject buttonAddCommod;
    public Vector2 pos;
    public float admiralsx;
    public float admiralsy;
    public float shipsx;
    public float shipsy;
    public float commodsx;
    public float commodsy;
    int admiralsEnd;
    int shipsEnd;
    int commodsEnd;
    public List<GameObject> listAdmiral;
    public List<GameObject> listShips;
    public List<GameObject> listCommods;
    public GameObject panel;
    public GameObject myPanel;

    void Start () {

        myPanel = GameObject.Find ("Panel");
        inputID = myPanel.transform.Find ("InputID").gameObject.GetComponent<InputField> ();
        inputName = myPanel.transform.Find ("InputName").gameObject.GetComponent<InputField> ();
        inputDescription = myPanel.transform.Find ("InputDescription").gameObject.GetComponent<InputField> ();
        inputPhoto = myPanel.transform.Find ("InputPhoto").gameObject.GetComponent<InputField> ();
        inputID.text = "";
        myPanel.SetActive (false);
        Istance = this;
        admiralsEnd = 0;
        shipsEnd = 0;
        commodsEnd = 0;
        admiralsx = -180f;
        admiralsy = 145f;
        shipsx = 0f;
        shipsy = 145f;
        commodsx = 180f;
        commodsy = 145f;
        OpenXML ();
        AddOnGUIAdmiral ();
        AddOnGUIShips ();
        AddOnGUICommod ();

    }

    public void OpenXML () {

        StreamReader reader = new StreamReader (Application.dataPath + "/Resources/XML/GE_XML_Structure.xml");
        string s = reader.ReadToEnd ();
        reader.Close ();
        XmlDocument xmlDoc = new XmlDocument ();
        xmlDoc.LoadXml (s);
        XmlElement xRoot = xmlDoc.DocumentElement;

        foreach (XmlNode xnode in xRoot) {
            Debug.Log (xnode.Name);

            foreach (XmlNode childnode in xnode.ChildNodes) {
                if (childnode.Name == "admirals") {
                    foreach (XmlNode win in childnode.ChildNodes) {
                        admirals.Add (win.InnerText);
                        Debug.Log (win.InnerText);
                    }
                }

                if (childnode.Name == "ships") {
                    foreach (XmlNode win in childnode.ChildNodes) {
                        ships.Add (win.InnerText);
                    }
                }

                if (childnode.Name == "commods") {
                    foreach (XmlNode win in childnode.ChildNodes) {
                        commods.Add (win.InnerText);
                    }
                }
            }
        }
    }
    public void RemoveAllAdmirals () {

        for (int i = listAdmiral.Count - 1; i > -1; i--) {
            Destroy (listAdmiral[i]);
            listAdmiral.RemoveAt (i);
        }

        admiralsEnd = 0;
        admiralsy = 145f;
        admirals.Clear ();
        listAdmiral.Clear ();
        OpenXML ();
        AddOnGUIAdmiral ();
    }

    public void RemoveAllShips () {

        for (int i = listShips.Count - 1; i > -1; i--) {
            Destroy (listShips[i]);
            listShips.RemoveAt (i);
        }

        shipsEnd = 0;
        shipsy = 145f;
        ships.Clear ();
        listShips.Clear ();
        OpenXML ();
        AddOnGUIShips ();
    }

    public void RemoveAllСommods () {

        for (int i = listCommods.Count - 1; i > -1; i--) {
            Destroy (listCommods[i]);
            listCommods.RemoveAt (i);
        }
        commodsEnd = 0;
        commodsy = 145f;
        commods.Clear ();
        listCommods.Clear ();
        OpenXML ();
        AddOnGUICommod ();
    }

    public void AddOnGUIAdmiral () {
        
        foreach (var item in admirals) {
            GameObject myObject = Instantiate (buttonAdmiral, new Vector2 (0, 0), Quaternion.identity);
            myObject.transform.SetParent (panel.transform);
            myObject.transform.localScale = new Vector2 (1f, 1f);
            myObject.GetComponent<RectTransform> ().localPosition = new Vector3 (admiralsx, admiralsy, 0);
            myObject.name = item.ToString ();
            myObject.GetComponentInChildren<Text> ().text = item.ToString ();
            admiralsy -= 35f;
            admiralsEnd++;
            listAdmiral.Add (myObject);

            if (admirals.Count == admiralsEnd) {
                GameObject myObjectBtn = Instantiate (buttonAddAdmiral, new Vector2 (0, 0), Quaternion.identity);
                myObjectBtn.transform.SetParent (panel.transform);
                myObjectBtn.name = "ButtonAddAdmiral";
                myObjectBtn.transform.localScale = new Vector2 (40f, 40f);
                myObjectBtn.transform.localPosition = new Vector3 (admiralsx, admiralsy - 10, 0);
                listAdmiral.Add (myObjectBtn);
            }
        }
    }

    public void AddOnGUIShips () {
        foreach (var item in ships) {
            GameObject myObject = Instantiate (buttonShip, new Vector2 (0, 0), Quaternion.identity);
            myObject.transform.SetParent (panel.transform);
            myObject.transform.localScale = new Vector2 (1f, 1f);
            myObject.GetComponent<RectTransform> ().localPosition = new Vector3 (shipsx, shipsy, 0);
            myObject.name = item.ToString ();
            myObject.GetComponentInChildren<Text> ().text = item.ToString ();
            shipsy -= 35f;
            shipsEnd++;
            listShips.Add (myObject);

            if (ships.Count == shipsEnd) {
                GameObject myObjectBtn = Instantiate (buttonAddShip, new Vector2 (0, 0), Quaternion.identity);
                myObjectBtn.transform.SetParent (panel.transform);
                myObjectBtn.name = "ButtonAddShip";
                myObjectBtn.transform.localScale = new Vector2 (40f, 40f);
                myObjectBtn.transform.localPosition = new Vector3 (shipsx, shipsy - 10, 0);
                listShips.Add (myObjectBtn);

            }
        }
    }

    public void AddOnGUICommod () {
        foreach (var item in commods) {
            GameObject myObject = Instantiate (buttonComond, new Vector2 (0, 0), Quaternion.identity);
            myObject.transform.SetParent (panel.transform);
            myObject.transform.localScale = new Vector2 (1f, 1f);
            myObject.GetComponent<RectTransform> ().localPosition = new Vector3 (commodsx, commodsy, 0);
            myObject.name = item.ToString ();
            myObject.GetComponentInChildren<Text> ().text = item.ToString ();
            commodsy -= 35f;
            commodsEnd++;
            listCommods.Add (myObject);

            if (commods.Count == commodsEnd) {
                GameObject myObjectBtn = Instantiate (buttonAddCommod, new Vector2 (0, 0), Quaternion.identity);
                myObjectBtn.transform.SetParent (panel.transform);
                myObjectBtn.name = "ButtonAddCommod";
                myObjectBtn.transform.localScale = new Vector2 (40f, 40f);
                myObjectBtn.transform.localPosition = new Vector3 (commodsx, commodsy - 10, 0);
                listCommods.Add (myObjectBtn);
            }
        }
    }
}