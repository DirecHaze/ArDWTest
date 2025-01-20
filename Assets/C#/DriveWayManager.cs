using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;
public class DriveWayManager : Singleton<DriveWayManager>
{
    [SerializeField]
    private GameObject _primaryArPrefabObject;
    [SerializeField]
    public GameObject[] _prefabArObject;
    private int _animIndex = 1;
    public void AnimState(int index)
    {
        _animIndex = index;
    }
    public void playAnim()
    {
        //If anim index is 1 meaning the object Animation State is the Default State it will set the Animation State of that object to the new Animation State 
        if (_animIndex == 1)
        {

            if (GameObject.FindWithTag("Fridge") == true)
            {
                GameObject.FindWithTag("Fridge").GetComponent<Animator>().SetBool("Play", true);
                UiManager.Program._index = 2;
            }
            if (GameObject.FindWithTag("Car") == true)
            {
                UiManager.Program._index = 2;
                GameObject.FindWithTag("Car").GetComponent<Animator>().SetBool("Play",true);
            }
            if (GameObject.FindWithTag("Bot") == true)
            {
                UiManager.Program._index = 2;
                GameObject.FindWithTag("Bot").GetComponent<Animator>().SetBool("Play", true);
            }
        }
        //If anim index is 2 meaning the object Animation State is the new Animation State it will set the Animation State of that object to the Default State 
        else
        {
            if (GameObject.FindWithTag("Fridge") == true)
            {
                UiManager.Program._index = 1;
                GameObject.FindWithTag("Fridge").GetComponent<Animator>().SetBool("Play", false);
            }
            if (GameObject.FindWithTag("Car") == true)
            {
                UiManager.Program._index = 1;
                GameObject.FindWithTag("Car").GetComponent<Animator>().SetBool("Play", false);
            }
            if (GameObject.FindWithTag("Bot") == true)
            {
                UiManager.Program._index = 1;
                GameObject.FindWithTag("Bot").GetComponent<Animator>().SetBool("Play", false);
            }
        }
       

    }
    public void RemoveGameObject()
    {
        //Reset DriveWay Mode
        if (GameObject.FindWithTag("Fridge") == true)
        {
            Destroy(GameObject.FindWithTag("Fridge"));
        }

        if (GameObject.FindWithTag("Bot") == true)
        {
            Destroy(GameObject.FindWithTag("Bot"));
        }

        if (GameObject.FindWithTag("Car") == true)
        {
            Destroy(GameObject.FindWithTag("Car"));
        }
        UiManager.Program._index = 1;
        _animIndex = 1;

    }
    public void PickGameObject(int objectNumber)
    {
        

        if (objectNumber == 1)
        {
            _primaryArPrefabObject = _prefabArObject[0];
        }
        if (objectNumber == 2)
        {
            _primaryArPrefabObject = _prefabArObject[1];
        }
        if (objectNumber == 3)
        {
            _primaryArPrefabObject = _prefabArObject[2];
        }

        GameObject ARPlacementInteractableObject = GameObject.Find("AR Placement Interactable");
        ARPlacementInteractableObject.GetComponent<ARPlacementInteractable>().placementPrefab = _primaryArPrefabObject;
        
    }
    public void ChangeArObjectColor(string color)
    {
     if(GameObject.FindWithTag("Car") != null)
        {
            GameObject.FindWithTag("Car").GetComponent<DrivewayObject>().colorChange(color);
        }
    }

}
