using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : Singleton<ExaminableManager>
{
    [SerializeField]
    private Transform _examineArea;
    private GameObject _examinableObj, _examinableObjOrginalParnet;
    private Vector3 _examinableObjOrginalPos;
    private Quaternion _examinableObjOrginalRot;

    private bool _isExamineTure;
    private void Update()
    {
        if(Input.touchCount == 1 && _isExamineTure == true)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {

                _examinableObj.transform.Rotate(touch.deltaPosition.x,0,touch.deltaPosition.y);
               
            }
        }
    }
    public void ExaminingExaminableObject(GameObject ExaminableObject, GameObject ExaminableObjectOrginalParnet)
    {
        _examinableObj = ExaminableObject;

        _examinableObjOrginalParnet = ExaminableObjectOrginalParnet;

        _examinableObjOrginalPos = ExaminableObject.transform.position;

        _examinableObjOrginalRot = ExaminableObjectOrginalParnet.transform.rotation;

        _examinableObj.transform.parent = _examineArea;

        _examinableObj.transform.position = _examineArea.position;

        _isExamineTure = true;
    }
    public void ReturnExaminableObjectPos()
    {
       
        _examinableObj.transform.parent = _examinableObjOrginalParnet.transform;
      
        _examinableObj.transform.rotation = _examinableObjOrginalRot;
     
        _examinableObj.transform.position = _examinableObjOrginalPos;
     
        _isExamineTure = false;
       
        _examinableObj = null;

        _examinableObjOrginalParnet = null;
        
       

    }
}
