using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolveQuiz : MonoBehaviour {

    public List<GameObject> SelectedBlank = new List<GameObject>();
    public List<GameObject> ClearBlank = new List<GameObject>();

    public GameObject Keyboard;
    public bool IsClear = false;

    private Animator anim;

    /*
    [HideInInspector]
    public int[] horizontalQuizNum = new int[5];
    [HideInInspector]
    public int[] VerticalQuizNum = new int[5];

    private bool IsCorrect = false;
    private int CorrectNum = 0;
    */

    // Use this for initialization
    void Start () {
        anim = transform.parent.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if(!IsClear)
        {
            int CorrectNum = 0;
            foreach(GameObject it in ClearBlank)
            {
                if(it.GetComponent<QuizBlank>().IsCorrect)
                {
                    CorrectNum++;
                }
            }

            if(CorrectNum == 6)
            {
                IsClear = true;
                anim.SetBool("IsOpen", true);
            }
        }

        if (SelectedBlank.Count == 0)
        {
            return;
        }

        SelectedBlank.Sort(delegate (GameObject a, GameObject b)
        {
            return a.name.CompareTo(b.name);
        });

        if (Keyboard.GetComponent<VRTK.Examples.UI_Keyboard>().inputSentence != "")
        {
            string temp = "";

            for (int i = 0; i < SelectedBlank.Count; ++i)
            {
                temp += SelectedBlank[i].GetComponent<QuizBlank>().answer;
            }

            if (string.Compare(temp, Keyboard.GetComponent<VRTK.Examples.UI_Keyboard>().inputSentence, true) != 0)
            {
                for (int i = 0; i < SelectedBlank.Count; ++i)
                {
                    SelectedBlank[i].GetComponent<QuizBlank>().IsSelect = false;
                }
                Keyboard.GetComponent<VRTK.Examples.UI_Keyboard>().inputSentence = "";
                SelectedBlank.Clear();
            }
            else
            {
                for(int i = 0; i < SelectedBlank.Count; ++i)
                {
                    SelectedBlank[i].GetComponent<QuizBlank>().IsCorrect = true;
                    SelectedBlank[i].GetComponent<QuizBlank>().IsSelect = false;
                    SelectedBlank[i].transform.GetChild(0).GetComponent<Text>().text
                        = SelectedBlank[i].GetComponent<QuizBlank>().answer;
                }
                Keyboard.GetComponent<VRTK.Examples.UI_Keyboard>().inputSentence = "";
                SelectedBlank.Clear();
            }
        }

        /*for (int i = 0; i < 5; ++i)
        {
            if(SelectedBlank[0].GetComponent<QuizBlank>().horizontalQuiz[i])
            {
                for(int j = 0; j < SelectedBlank.Count; ++j)
                {
                    if(SelectedBlank[0].GetComponent<QuizBlank>().horizontalQuiz[i]
                        != SelectedBlank[j].GetComponent<QuizBlank>().horizontalQuiz[i])
                    {
                        CorrectNum = 0;
                        IsCorrect = false;
                        break;
                    }
                    else
                    {
                        CorrectNum++;
                        IsCorrect = true;
                    }
                }
            }
        }

        if (!IsCorrect)
        {
            for (int i = 0; i < 5; ++i)
            {
                if (SelectedBlank[0].GetComponent<QuizBlank>().VerticalQuiz[i])
                {
                    for (int j = 0; j < SelectedBlank.Count; ++j)
                    {
                        if (SelectedBlank[0].GetComponent<QuizBlank>().VerticalQuiz[i]
                            != SelectedBlank[j].GetComponent<QuizBlank>().VerticalQuiz[i])
                        {
                            IsCorrect = false;
                            break;
                        }
                    }
                }
            }
        }

        if (IsCorrect)
        {
            for (int i = 0; i < SelectedBlank.Count; ++i)
            {
                SelectedBlank[i].GetComponent<QuizBlank>().IsSelect = false;
            }
            SelectedBlank.Clear();
            IsCorrect = false;
        }*/
    }
}
