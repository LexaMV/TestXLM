using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonControl : PanelControl {

    public void OnButtonClick () {
        var go = EventSystem.current.currentSelectedGameObject;

        if (go.name.Contains ("AddAdmiral")) {
            Debug.Log ("Clicked on : " + go.name);
            PanelActive ("admiral");
        }
        
        else if (go.name.Contains ("AddShip")) {
            Debug.Log ("Clicked on : " + go.name);
            PanelActive ("ship");
        } 
        
        else if (go.name.Contains ("AddCommod")) {
            Debug.Log ("Clicked on : " + go.name);
            PanelActive ("commod");
        }
        
        else if (go.name.Contains ("DelAdmiral")) {
            Delete (go.transform.parent.gameObject.name, "admiral", "admiral_part");

        }
        
        else if (go.name.Contains ("DelShip")) {
            Delete (go.transform.parent.gameObject.name, "ship", "ship_part");

        }
        
        else if (go.name.Contains ("DelCommod")) {
            Delete (go.transform.parent.gameObject.name, "commod", "commod_part");

        }
        
        else if (go.name.Contains ("EditAdmiral")) {
            Debug.Log ("Clicked on : " + go.name);
            PanelActive ("admiral");
            EditData (go.transform.parent.gameObject.name);
        }
        
        else if (go.name.Contains ("EditShip")) {
            Debug.Log ("Clicked on : " + go.name);
            PanelActive ("ship");
            EditData (go.transform.parent.gameObject.name);
        }
        
        else if (go.name.Contains ("EditCommod")) {
            Debug.Log ("Clicked on : " + go.name);
            PanelActive ("commod");
            EditData (go.transform.parent.gameObject.name);
        }
    }
}