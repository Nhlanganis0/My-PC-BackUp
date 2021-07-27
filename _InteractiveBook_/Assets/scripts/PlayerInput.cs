using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public string Answer;
    public GameObject inputField_Q1;
    public GameObject inputField_Q2;
    public GameObject inputField_Q3;
    public GameObject inputField_Q4;
    public GameObject inputField_Q5;

    public GameObject inputField_Q2_1;
    public GameObject inputField_Q2_2;
    public GameObject inputField_Q2_3;

    public GameObject Read;
    public GameObject Next_Button;
    public GameObject Current_Question;
    public GameObject Next_Question;
    public Button One;
    public Button Two;
    public Button Tjree;
    public Button Four;
    public Button Five;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public float passMark = 0;
    private bool isNext = true;

    public void Q1()
    {
        Answer = inputField_Q1.GetComponent<Text>().text;
        if (Answer.Contains("Browse") || Answer.Contains("browse"))
        {
            passMark++;
            One.enabled = false;
            print(passMark);
        }
     
        if (passMark == 5)
        {
            print("Well Done!");
            passMark = 0;
            IsNext();
        }
    }
    public void Q2()
    {
        Answer = inputField_Q2.GetComponent<Text>().text;
        if (Answer.Contains("Fundraiser") || Answer.Contains("fundraiser"))
        {
            passMark++;
            Two.enabled = false;
            print(passMark);
        }

        if (passMark == 5)
        {
            print("Well Done!");
            passMark = 0;
            IsNext();
        }
    }
    public void Q3()
    {
        Answer = inputField_Q3.GetComponent<Text>().text;
        if (Answer.Contains("Money") || Answer.Contains("money"))
        {
            passMark++;
            Tjree.enabled = false;
            print(passMark);
        }

        if (passMark == 5)
        {
            print("Well Done!");
            passMark = 0;
            IsNext();
        }
    }
    public void Q4()
    {
        Answer = inputField_Q4.GetComponent<Text>().text;
        if (Answer.Contains("Stationary") || Answer.Contains("stationary"))
        {
            passMark++;
            Four.enabled = false;
            print(passMark);
        }

        if (passMark == 5)
        {
            print("Well Done!");
            passMark = 0;
            IsNext();
        }
    }
    public void Q5()
    {
        Answer = inputField_Q5.GetComponent<Text>().text;
        if (Answer.Contains("Clothing") || Answer.Contains("clothing"))
        {
            passMark++;
            Five.enabled = false;
            print(passMark);
        }

        if (passMark == 5)
        {
            print("Well Done!");
            passMark = 0;
            IsNext();
        }
    }

    public void Q2_1()
    {
        Answer = inputField_Q2_1.GetComponent<Text>().text;
        if (Answer.Contains("C") || Answer.Contains("c"))
        {
            passMark++;
            Button1.enabled = false;
            print(passMark);
        }

        if (passMark == 3)
        {
            print("Well Done!");
            passMark = 0;
            IsNext();
        }
    }
    public void Q2_2()
    {
        Answer = inputField_Q2_2.GetComponent<Text>().text;
        if (Answer.Contains("C") || Answer.Contains("c"))
        {
            passMark++;
            Button2.enabled = false;
            print(passMark);
        }

        if (passMark == 3)
        {
            print("Well Done!");
            passMark = 0;
            IsNext();
        }
    }
    public void Q2_3()
    {
        Answer = inputField_Q2_3.GetComponent<Text>().text;
        if (Answer.Contains("B") || Answer.Contains("b"))
        {
            passMark++;
            Button3.enabled = false;
            print(passMark);
        }

        if (passMark == 3)
        {
            print("Well Done!");
            passMark = 0;
            IsNext();
        }
    }

    public void IsNext()
    {
        if (isNext == true)
        {
            Next_Button.SetActive(true);
            isNext = false;
        }
        else if (isNext == false)
        {
            Read.SetActive(true);
        }
    }

    public void NextQuestion()
    {
        Current_Question.SetActive(false);
        Next_Question.SetActive(true);
    }

    public void Read_Book()
    {
        SceneManager.LoadScene(1);
    }
}
