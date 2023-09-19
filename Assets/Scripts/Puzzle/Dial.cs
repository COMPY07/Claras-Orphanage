using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dial : MonoBehaviour
{
    
    
    int[] answer, inputs;
    public bool isComplete;
    private int idx;


    [SerializeField] private TMP_Text text;
    
    
    private void Start()
    {
        isComplete = false;
        answer = new int[] { 0,8,2,1};
        inputs = new int[4];
        idx = 0;
        text.text = "";
    }

    public void Open() {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Close() {
        for (int i = 0; i < this.gameObject.transform.childCount; i++){
            this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private int MyInput(int inp) {
        if (inp == -1)
        {
            inputs[idx--] = 0;
        }
        else
        {
            if(idx >= 3) return 0;
            inputs[++idx] = inp;
        }
        
        return DailUpdate();
    }

    private int DailUpdate()
    {
        text.text = "";
        bool isSolving = true;
        for (int i = 0; i <= idx; i++) {
            text.text += inputs[i].ToString() + "   ";
            isSolving = isSolving && answer[i] == inputs[i];
        }
        
        if (idx == 3 && isSolving) { return Solve(); }

        return 0;
    }

    private int Solve() {
        GameManager.SetLevel(0);
        isComplete = true;
        
        text.transform.parent.gameObject.SetActive(false);
        return 1;
    }

    public void OnClickZero() {
        MyInput(0);
    }
    public void OnClickOne()
    {
        MyInput(1);
    }
    public void OnClickTwo()
    {
        MyInput(2);
    }
    public void OnClickThree()
    {
        MyInput(3);
    }
    public void OnClickFour()
    {
        MyInput(4);
    }
    public void OnClickFive()
    {
        
        MyInput(5);
    }
    public void OnClickSix()
    {
        MyInput(6);
    }
    public void OnClickSeven()
    {
        MyInput(7);
    }
    public void OnClickEight()
    {
        MyInput(8);
    }
    public void OnClickNine()
    {
        MyInput(9);
    }

    public void OnClickRemove()
    {
        MyInput(-1);
    }

    public void OnClickBack() {
        Close();
    }

}
