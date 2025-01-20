using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BoxManager : MonoBehaviour
{
    private string _rightGemOrder = "BRG", _inputGemOrder;

    public Animator _boxAnimator;
    public Gem[] _gems;
    public TMP_Text _winText;

    public void GemOrder(Gem gempick)
    {

        _inputGemOrder += gempick._gemName;
        gempick.Emission(true);
        if (_inputGemOrder.Length == 3)
        {
            CheckGemOrder();

        }
    }



    private void CheckGemOrder()
    {
        if (_inputGemOrder == _rightGemOrder)
        {
            Debug.Log("Win");
            _boxAnimator.SetTrigger("Open");
            _winText.text = "Yes you won";
            StartCoroutine(GameWonReset());
        }
        else
        {
            foreach (var gem in _gems)
            {
                gem.Emission(false);
               
               
            }
            _winText.text = "Nope Wrong";
            StartCoroutine(TextReset());
            _inputGemOrder = "";
        }
    }

    IEnumerator GameWonReset()
    {
        yield return new WaitForSeconds(3.5f);


        _inputGemOrder = "";
        foreach (var gem in _gems)
        {
            gem.Emission(false);
        }
        SceneManager.LoadScene(0);
    }
    IEnumerator TextReset()
    {
        yield return new WaitForSeconds(2.5f);
        _winText.text = "";
       
    }
}
