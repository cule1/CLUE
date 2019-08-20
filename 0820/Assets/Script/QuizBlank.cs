using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizBlank : MonoBehaviour {

    public string answer;
    public bool IsSelect; //{ get; set; }  // 선택되었는가
    public bool IsCorrect { get; set; } // 정답인가
    
    private GameObject quiz;

    /*
    [HideInInspector]
    public bool [] horizontalQuiz = new bool[5];
    [HideInInspector]
    public bool[] VerticalQuiz = new bool[5];
    */

    // Use this for initialization
    void Start () {
        quiz = transform.parent.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if(IsSelect)
        {
            transform.GetComponent<Outline>().enabled = true;

            int size = quiz.GetComponent<SolveQuiz>().SelectedBlank.Count;

            if (size == 0)
            {
                quiz.GetComponent<SolveQuiz>().SelectedBlank.Add(this.gameObject);
            }
            else
            {
                //foreach (GameObject it in quiz.GetComponent<SolveQuiz>().SelectedBlank)
                for (int i = 0; i < size; ++i)
                {
                    //if(it == this)
                    if (quiz.GetComponent<SolveQuiz>().SelectedBlank[i] == this.gameObject)
                    {
                        break;
                    }
                    else
                    {
                        if (i + 1 == size)
                        {
                            quiz.GetComponent<SolveQuiz>().SelectedBlank.Add(this.gameObject);
                        }
                    }
                }
            }
        }
        else
        {
            transform.GetComponent<Outline>().enabled = false;
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GameObject1"
            || other.gameObject.name == "GameObject2")
        {
            if(!IsCorrect)
                IsSelect = true;
        }
    }
}
