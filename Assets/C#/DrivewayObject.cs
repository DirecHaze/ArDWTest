using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivewayObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _annotationHolder;
    [SerializeField]
    private Material _objectMaterial;

    private void Start()
    {
        //This is for when player remove the car before emission was reset this reset the emission when its place
        if (this.gameObject.tag == "Car")
        {
            _objectMaterial.SetColor("_EmissionColor", Color.black);
        }
    }
    //Change the color for a object
    public void colorChange(string color)
    {
        if(color == "Red")
        {
            _objectMaterial.color = Color.red;
        }
        if (color == "Green")
        {
            _objectMaterial.color = Color.green;
        }
        if(color == "Blue")
        {
            _objectMaterial.color = Color.blue;
        }
        if (color == "Yellow")
        {
            _objectMaterial.color = Color.yellow;
        }
    }
    
    public void NewAnimationState()
    { 
        //Change the car emission when animation is play
        if(this.gameObject.tag == "Car")
        {
            _objectMaterial.SetColor("_EmissionColor", Color.yellow);
        }
        //Make specific object annotation apper when animation is playing 
        _annotationHolder.SetActive(true);
      //Set the next time when animation is play the animation that would play is the Default state
        DriveWayManager.Program.AnimState(2);
    }
    public void DefaultAniamtion()
    {
        //Change the car emission back
        if (this.gameObject.tag == "Car")
        {
            _objectMaterial.SetColor("_EmissionColor", Color.black);
        }
        //Make specific object annotation desapper when animation is back to Default
        _annotationHolder.SetActive(false);
        //Set the next time when animation is play the animation that would play is the New state
        DriveWayManager.Program.AnimState(1);
    }
}
