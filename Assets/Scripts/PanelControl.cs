using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.UI;

public class PanelControl : Add {
	public static string editName;
	public static bool editCompleted;
	public string inputID;
	public string inputName;
	public string inputDescription;
	public string inputPhoto;
	public static string variable;
	public string partPath;
	public string assetPartPath;

	void Start () {
		editCompleted = false;
	}

	public void Enter () {

		inputID = MyScript.Istance.inputID.text;
		inputName = MyScript.Istance.inputName.text;
		inputDescription = MyScript.Istance.inputDescription.text;
		inputPhoto = MyScript.Istance.inputPhoto.text;

		if (editCompleted) {
		
			Delete (editName, variable, variable + "_part");
			editCompleted = false;
		}

		if (variable.Equals ("admiral")) {

			partPath = "/Resources/XML/GE_XML_Admiral_part.xml";
			assetPartPath = "Assets/Resources/XML/GE_XML_Admiral_part.xml";
			NewPanelAdd (variable, inputID, inputName, inputDescription, inputPhoto);
			NewAdd ("admirals", "admiral_part", "admiral", inputName);
		}
		
		else if (variable.Equals ("ship")) {

			partPath = "/Resources/XML/GE_XML_Ship_part.xml";
			assetPartPath = "Assets/Resources/XML/GE_XML_Ship_part.xml";
			NewPanelAdd (variable, inputID, inputName, inputDescription, inputPhoto);
			NewAdd ("ships", "ship_part", "ship", inputName);
		} 
		
		else if (variable.Equals ("commod")) {

			partPath = "/Resources/XML/GE_XML_Commod_part.xml";
			assetPartPath = "Assets/Resources/XML/GE_XML_Commod_part.xml";
			NewPanelAdd (variable, inputID, inputName, inputDescription, inputPhoto);
			NewAdd ("commods", "commod_part", "commod", inputName);
		}

		MyScript.Istance.myPanel.SetActive (false);
	}

	public void PanelActive (string name) {
		variable = name;
		MyScript.Istance.myPanel.SetActive (true);

	}

	public void NewPanelAdd (string element, string id, string name, string description, string photo) {
	
		StreamReader readerPanel = new StreamReader (Application.dataPath + partPath);
		string s = readerPanel.ReadToEnd ();
		readerPanel.Close ();
		XDocument xmlDocPanel = XDocument.Parse (s);

		xmlDocPanel.Root.Add (new XElement (element,
			new XElement ("id", id), new XElement ("name", name), new XElement ("description", description), new XElement ("photo", photo)));

		StreamWriter outStreamPanel = System.IO.File.CreateText (assetPartPath);
		xmlDocPanel.Save (outStreamPanel);
		outStreamPanel.Close ();
	}

	public void EditData (string name) {

		editName = name;
		if (variable.Equals ("admiral")) {

			partPath = "/Resources/XML/GE_XML_Admiral_part.xml";
			assetPartPath = "Assets/Resources/XML/GE_XML_Admiral_part.xml";

		} 
		
		else if (variable.Equals ("ship")) {

			partPath = "/Resources/XML/GE_XML_Ship_part.xml";
			assetPartPath = "Assets/Resources/XML/GE_XML_Ship_part.xml";

		} 
		
		else if (variable.Equals ("commod")) {
	
			partPath = "/Resources/XML/GE_XML_Commod_part.xml";
			assetPartPath = "Assets/Resources/XML/GE_XML_Commod_part.xml";

		}

		StreamReader readerPanel = new StreamReader (Application.dataPath + partPath);
		string s = readerPanel.ReadToEnd ();
		readerPanel.Close ();
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (s);
		XmlElement xRoot = xmlDoc.DocumentElement;

		foreach (XmlNode xnode in xRoot) {

			foreach (XmlNode childnode in xnode.ChildNodes) {

				foreach (XmlNode Xchildnode in childnode.ChildNodes) {

					if (Xchildnode.InnerText == name) {

						MyScript.Istance.inputID.text = xnode.ChildNodes[0].InnerText;
						MyScript.Istance.inputName.text = xnode.ChildNodes[1].InnerText;
						MyScript.Istance.inputDescription.text = xnode.ChildNodes[2].InnerText;
						MyScript.Istance.inputPhoto.text = xnode.ChildNodes[3].InnerText;
					}
				}
			}
		}

		editCompleted = true;
	}
}