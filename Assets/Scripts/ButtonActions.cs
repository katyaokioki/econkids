using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    private Button _button;
    public int index;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(showLog);
    }
    private void showLog()
    {
        Debug.Log("падам");
    }

}
