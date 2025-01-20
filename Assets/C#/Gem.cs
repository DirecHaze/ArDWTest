using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField]
    private Material _gemMaterial;
    private Color _originalEmission;
    public string _gemName;
    public int R,G,B;

    private void Start()
    {

        _originalEmission = new Color(R, G, B);


        _gemMaterial.SetColor("_EmissionColor", Color.black);
    }

    public void Emission(bool emissionOn)
    {
        Debug.Log("Call");
        if(emissionOn == false)
        {
            _gemMaterial.SetColor("_EmissionColor", Color.black);
           
        }
        else
        {
           
             
            _gemMaterial.SetColor("_EmissionColor", _originalEmission);
           
          
           
        }
    }
  
}
