using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableObject : MonoBehaviour
{
    [SerializeField]
    private ExaminableManager _examinableManager;
    [SerializeField]
    private GameObject _examineableObject;
    [SerializeField]
    private float _scaleAdjuster;
    private Vector3 _orginalExaminableObjectScale;
   

    private void Start()
    {
        
        GameObject examinableManager = GameObject.Find("ExaminableManager");

        _examinableManager = examinableManager.GetComponent<ExaminableManager>();

    }
    public void Examine()
    {
        //Save the Examinable Object Orginal Scale
        _orginalExaminableObjectScale = _examineableObject.transform.localScale;
        //Starts the examine
        _examinableManager.ExaminingExaminableObject(_examineableObject, this.gameObject);
        //Adjust the Object Scale
        Vector3 objectScale = _examineableObject.transform.localScale * _scaleAdjuster;
        _examineableObject.transform.localScale = objectScale;
    }
    public void ExitExamine()
    {
        //Stops Examine
        _examinableManager.ReturnExaminableObjectPos();
        //Adjust the Object Scale to the Orginal Scale
        _examineableObject.transform.localScale = _orginalExaminableObjectScale;
    }
    public void mainObjectThis()
    {
        DeskTopModeManager.Program.currentObject(this.gameObject);

        UiManager.Program.DeskTopArObjectModeUI();
    }
    public void removeMainObject()
    {

        DeskTopModeManager.Program.removeCurrentObject();
    }
   
}
