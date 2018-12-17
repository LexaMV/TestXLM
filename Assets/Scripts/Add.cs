using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Add : MonoBehaviour {
    public string pathXML = "/Resources/XML/GE_XML_Structure.xml";
    public string assetsPathXml = "Assets/Resources/XML/GE_XML_Structure.xml";
    public string pathXMLAdmiralPart = "/Resources/XML/GE_XML_Admiral_part.xml";
    public string assetsPathXMLAdmiralPart = "Assets/Resources/XML/GE_XML_Admiral_part.xml";
    public string pathXMLCommodPart = "/Resources/XML/GE_XML_Commod_part.xml";
    public string assetsPathXMLCommodPart = "Assets/Resources/XML/GE_XML_Commod_part.xml";
    public string pathXMLShipPart = "/Resources/XML/GE_XML_Ship_part.xml";
    public string assetsPathXMLShipPart = "Assets/Resources/XML/GE_XML_Ship_part.xml";

    public void NewAdd (string mainName, string partName, string name, string nameObject) {

        StreamReader reader = new StreamReader (Application.dataPath + pathXML);
        string s = reader.ReadToEnd ();
        reader.Close ();
        XmlDocument xmlDoc = new XmlDocument ();
        xmlDoc.LoadXml (s);
        XmlElement xRoot = xmlDoc.DocumentElement;
        XmlElement elemFirst = xmlDoc.CreateElement (name);
        XmlElement elemSecond = xmlDoc.CreateElement (partName);
        XmlText text = xmlDoc.CreateTextNode (nameObject);

        foreach (XmlNode xnode in xRoot) {

            foreach (XmlNode childnode in xnode.ChildNodes) {
                if (childnode.Name == mainName) {

                    childnode.AppendChild (elemFirst);
                    elemFirst.AppendChild (elemSecond);
                    elemSecond.AppendChild (text);

                }
            }
        }

        StreamWriter outStream = System.IO.File.CreateText (assetsPathXml);
        xmlDoc.Save (outStream);
        outStream.Close ();

        if (name == "admiral") {
            MyScript.Istance.RemoveAllAdmirals ();
        }

        if (name == "ship") {
            MyScript.Istance.RemoveAllShips ();
        }

        if (name == "commod") {
            MyScript.Istance.RemoveAllСommods ();
        }
    }

    public void Delete (string gameObjectName, string nameObject, string partName) {

        StreamReader reader = new StreamReader (Application.dataPath + pathXML);
        string s = reader.ReadToEnd ();
        reader.Close ();
        XDocument xmlDoc = XDocument.Parse (s);
        xmlDoc.Descendants (nameObject).Where (x => x.Descendants (partName).Any (y => y.Value == gameObjectName)).Remove ();
        StreamWriter outStream = System.IO.File.CreateText (assetsPathXml);
        xmlDoc.Save (outStream);
        outStream.Close ();

        if (nameObject == "admiral") {

            pathXML = pathXMLAdmiralPart;
            assetsPathXml = assetsPathXMLAdmiralPart;
        }

        if (nameObject == "ship") {
            Debug.Log ("11^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ " + nameObject);

            pathXML = pathXMLShipPart;
            assetsPathXml = assetsPathXMLShipPart;
        }

        if (nameObject == "commod") {

            pathXML = pathXMLCommodPart;
            assetsPathXml = assetsPathXMLCommodPart;
        }

        StreamReader readerpart = new StreamReader (Application.dataPath + pathXML);
        string spart = readerpart.ReadToEnd ();
        readerpart.Close ();
        XDocument xmlDocpart = XDocument.Parse (spart);
        xmlDocpart.Root.Descendants (nameObject).Where (x => x.Descendants ("name").Any (y => y.Value == gameObjectName)).Remove ();
        StreamWriter outStreampart = System.IO.File.CreateText (assetsPathXml);
        xmlDocpart.Save (outStreampart);
        outStreampart.Close ();

        if (nameObject == "admiral") {
            MyScript.Istance.RemoveAllAdmirals ();
            pathXML = "/Resources/XML/GE_XML_Structure.xml";
            assetsPathXml = "Assets/Resources/XML/GE_XML_Structure.xml";

        }

        if (nameObject == "ship") {
            MyScript.Istance.RemoveAllShips ();
            pathXML = "/Resources/XML/GE_XML_Structure.xml";
            assetsPathXml = "Assets/Resources/XML/GE_XML_Structure.xml";
        }

        if (nameObject == "commod") {
            MyScript.Istance.RemoveAllСommods ();
            pathXML = "/Resources/XML/GE_XML_Structure.xml";
            assetsPathXml = "Assets/Resources/XML/GE_XML_Structure.xml";
        }
    }

    public void EndRenameAdmiral () {
        string oldName = gameObject.transform.parent.name.ToString ();
        string newName = gameObject.GetComponent<InputField> ().text;
        StreamReader reader = new StreamReader (Application.dataPath + pathXML);
        string s = reader.ReadToEnd ();
        Debug.LogWarning (s);
        reader.Close ();
        XmlDocument xmlDoc = new XmlDocument ();
        xmlDoc.LoadXml (s);
        XmlElement xRoot = xmlDoc.DocumentElement;

        foreach (XmlNode xnode in xRoot) {

            foreach (XmlNode childnode in xnode.ChildNodes) {
                if (childnode.Name == "admirals") {

                    foreach (XmlNode xchildnode in childnode.ChildNodes) {

                        foreach (XmlNode achildnode in xchildnode.ChildNodes) {

                            if (achildnode.InnerText == oldName) {
                                achildnode.InnerText = newName;
                            }
                        }
                    }
                }
            }
        }

        StreamWriter outStream = System.IO.File.CreateText (assetsPathXml);
        xmlDoc.Save (outStream);
        outStream.Close ();
        MyScript.Istance.RemoveAllAdmirals ();
    }
}