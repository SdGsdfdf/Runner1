using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Menu: MonoBehaviour {
    
    public GameObject menu;
    public GameObject text;
    public Text scoreText;
    public Text scoreRed;
    public Text scoreBlue;
    public Text scoreGreen;
    public Text rateRed;
    public Text rateBlue;
    public Text rateGreen;
    public float sum;
    public float red,blue,green;
    public float ratered, rateblue, rategreen;

    // Use this for initialization
    void Start () {
        //решил проверить теорию вероятности. Эта часть доступна только для Андроид)
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        scoreRed.text = PlayerPrefs.GetInt("redScore").ToString();
        scoreBlue.text = PlayerPrefs.GetInt("blueScore").ToString();
        scoreGreen.text = PlayerPrefs.GetInt("greenScore").ToString();
        red = PlayerPrefs.GetInt("redScore");
        blue = PlayerPrefs.GetInt("blueScore");
        green = PlayerPrefs.GetInt("greenScore");
        sum = PlayerPrefs.GetInt("redScore") + PlayerPrefs.GetInt("blueScore") + PlayerPrefs.GetInt("greenScore");
        ratered = red/sum*100;
        ratered=Mathf.Round(ratered);
        rateRed.text = ratered.ToString();
        rateblue = blue / sum * 100;
        rateblue = Mathf.Round(rateblue);
        rateBlue.text = rateblue.ToString();
        rategreen = green / sum * 100;
        rategreen = Mathf.Round(rategreen);
        rateGreen.text = rategreen.ToString();
    }
	
	// Update is called once per frame
	void Update () {
       
	}
   
   
    public void LoadedLevel()
    {
        Application.LoadLevel("ScenePlay");
        
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void Rules()
    {
        text.SetActive(true);
    }
}


