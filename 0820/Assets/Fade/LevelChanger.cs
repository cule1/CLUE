using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	public Animator animator;

	private int levelToLoad;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CheckObject")
        {
            FadeToNextLevel();
          
        }
    }
    void Update () {
		//if (Input.GetMouseButtonDown(0))
		//{
		//	FadeToNextLevel();
		//}
	}
    
	public void FadeToNextLevel ()
	{
		FadeToLevel(SceneManager.GetActiveScene().buildIndex + 0);
	}
    
	public void FadeToLevel (int levelIndex)
	{
		levelToLoad = levelIndex;
		animator.SetTrigger("FadeOut");
	}
    
	public void OnFadeComplete ()
	{
		SceneManager.LoadScene("Menu");
	}
}
