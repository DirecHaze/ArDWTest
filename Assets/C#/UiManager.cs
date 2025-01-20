using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;
public class UiManager : Singleton<UiManager>
{
    public Button[] _objectSelect;
    public Button _animButton;
    public int _index = 1;
    public GameObject _desktopArObjectModeStateUi, _colorChangeUi;
    public bool _hidePlane;
    public void DeskTopArObjectModeUI()
    {
        _desktopArObjectModeStateUi.SetActive(true);
    }
    public void hideplane()
    {
    //Disable Plane
           _hidePlane = true;
        
    }
    public void Showplane()
    {
        //Enable Plane
        _hidePlane = false;


    }
    private void Update()
    { //Change Animation button Text
        if (GameObject.FindWithTag("Fridge") && _index == 1)
        {

            _animButton.transform.GetComponentInChildren<TMP_Text>().text = "Open";
        }
        else if (_index == 2)
        {
            _animButton.transform.GetComponentInChildren<TMP_Text>().text = "Close";
        }

        if (GameObject.FindWithTag("Car") && _index == 1)
        {
            _colorChangeUi.SetActive(true);
            _animButton.transform.GetComponentInChildren<TMP_Text>().text = "Turn On";
        }
        else if(_index == 2)
        {
            _animButton.transform.GetComponentInChildren<TMP_Text>().text = "Turn Off";
        }
        if (GameObject.FindWithTag("Car") == null)
        {
            _colorChangeUi.SetActive(false);
        }

        if (GameObject.FindWithTag("Bot") && _index == 1)
        {
            
            _animButton.transform.GetComponentInChildren<TMP_Text>().text = "Turn On";
        }
        else if (_index == 2)
        {
            _animButton.transform.GetComponentInChildren<TMP_Text>().text = "Turn Off";
        }
        //ReEnable or Remove Plane from being seen
        if(GameObject.FindWithTag("Plane") != null && _hidePlane == false)
        {
            foreach (var plane in GameObject.FindGameObjectsWithTag("Plane"))
            {
                plane.GetComponent<ARPlaneMeshVisualizer>().enabled = true;

            }
        }
        else if(_hidePlane == true) 
        {
            foreach (var plane in GameObject.FindGameObjectsWithTag("Plane"))
            {
                plane.GetComponent<ARPlaneMeshVisualizer>().enabled = false;

            }
        }
    }
}
