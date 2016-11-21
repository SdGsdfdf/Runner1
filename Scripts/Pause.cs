using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
    public float timing;
    public bool isPaused;
   
    public GameObject pause;
    public GameObject pauseOnGame;
    public GameObject Everyplay;
    public GameObject EveryplayCam;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        
            Time.timeScale = timing;
            if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
            {
                isPaused = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
            {
                isPaused = false;
            }
            if (isPaused == true)
            {
                timing = 0;
                pause.SetActive(true);
                pauseOnGame.SetActive(false);
            }
            if (isPaused == false)
            {
                timing = 1;
                pause.SetActive(false);
                pauseOnGame.SetActive(true);
            }
        
       


    }
    public void ResumeButton(bool state)
    {
        isPaused = state;
    }
    public void BackButton()
    {
        Application.LoadLevel("Menu");
        Everyplay.SetActive(false);
        EveryplayCam.SetActive(false);
    }
    public void ResumeOnGameButton(bool state)
    {
        isPaused = state;
        pauseOnGame.SetActive(false);
        pause.SetActive(true);

    }
    public void Repid()
    {
        Application.LoadLevel("ScenePlay");
    }
}


