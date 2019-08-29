using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour {
    public static string nextScene;
    public Animator animator;
    private int levelToLoad;

    [SerializeField]
    Image progressBar;

    string nextSceneName;

	// Use this for initialization
	void Start () {
        progressBar.fillAmount = 0;
        StartCoroutine(LoadScene());	
	}

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("Menu");
    }
    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while(!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime * 0.1f;

            if(op.progress >= 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1.0f, timer);

                if(progressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if(progressBar.fillAmount >= op.progress)
                {
                    timer = 0.0f;
                }
            }
        }
    }
}
