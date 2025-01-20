using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;
public class DeskTopModeManager : Singleton<DeskTopModeManager>
{
    private enum DesktopModes
    {
       
        Mode1,

        Mode2,
    }
    private GameObject _primaryArPrefabObject, arobject;
    [SerializeField]
    public GameObject[] _prefabArObject;
    [SerializeField]
    public int _mode;
   
    private bool _exmaineing, _movement;


    private DesktopModes _gameModeState;

    public void currentObject(GameObject gameObject)
    {
        arobject = gameObject;
    }
    public void removeCurrentObject()
    {
        arobject = null;
    }
    private void Update()
    {
        //Checks which object that was place so the player wont place more than one of same object
        if (GameObject.FindWithTag("Fridge") == true)
        {
            UiManager.Program._objectSelect[0].interactable = false;
        }
        else
        {
            UiManager.Program._objectSelect[0].interactable = true;
        }
        if (GameObject.FindWithTag("Box") == true)
        {
            UiManager.Program._objectSelect[1].interactable = false;
        }
        else
        {
            UiManager.Program._objectSelect[1].interactable = true;
        }
        if (GameObject.FindWithTag("Car") == true)
        {
            UiManager.Program._objectSelect[2].interactable = false;
        }
        else
        {
            UiManager.Program._objectSelect[2].interactable = true;
        }
    }
    public void DesktopModeSwitch(int Mode)
    {
        if (Mode == 1)
        {
            _gameModeState = DesktopModes.Mode1;
        }
        if (Mode == 2)
        {
            _gameModeState = DesktopModes.Mode2;
        }
        switch (_gameModeState)
        {
            case DesktopModes.Mode1:
                Debug.Log("****" + "mode 1");
                DesktopMode1();
                break;
            case DesktopModes.Mode2:
                Debug.Log("****"+"mode 2");
                DesktopMode2();
                break;
        }

    }
   
    private void DesktopMode1()
    {
        //This Mode is for examineing the objects 
        
        if (_exmaineing == false)
        {
            arobject.GetComponent<ExaminableObject>().Examine();
           

           arobject.GetComponent<ARSelectionInteractable>().selectionVisualization.SetActive(false);
            arobject.GetComponent<ARTranslationInteractable>().maxTranslationDistance = 0;
            _exmaineing = true;
            return;
        }
        else
        {
            arobject.GetComponent<ARSelectionInteractable>().selectionVisualization.SetActive(true);
            arobject.GetComponent<ExaminableObject>().ExitExamine();
            _exmaineing = false;
            return;
        }

    }
    
    private void DesktopMode2()
    {
        //This mode is for Moveing,Scaling,Rotateing
        if (_movement == false)
        {
            arobject.GetComponent<ARTranslationInteractable>().maxTranslationDistance = 10;
            _movement = true;
        }
        else
        {
            _movement = false;
            arobject.GetComponent<ARTranslationInteractable>().maxTranslationDistance = 0;
        }
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
    public void playAnim()
    {

        arobject.GetComponent<Animator>().SetBool("Play", true);
        StartCoroutine(EndAnim());
    }
    IEnumerator EndAnim()
    {

        yield return new WaitForSeconds(4f);
        arobject.GetComponent<Animator>().SetBool("Play", false);
    }
    public void DestroyAllARObject()
    {
        if (GameObject.FindWithTag("Fridge") == true)
        {
            Destroy(GameObject.FindWithTag("Fridge"));
        }
       
        if (GameObject.FindWithTag("Box") == true)
        {
            Destroy(GameObject.FindWithTag("Box"));
        }
       
        if (GameObject.FindWithTag("Car") == true)
        {
            Destroy(GameObject.FindWithTag("Car"));
        }
       
    }
   
}
