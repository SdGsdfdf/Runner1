using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerController : MonoBehaviour {
    //управление
    public float playerSpeed;
    public float maxPos;
    public float minPos;
    public float go;
    public Rigidbody rb;
    public float directionInput;
    public Vector3 position;
    public int WhatColor;
    //цвет
    public int numberColor;
    public int numberColorNotDoubleRed, numberColorNotDoubleBlue, numberColorNotDoubleGreen;
    //проиграл
    public GameObject pLose;
    public GameObject pPause;
    public GameObject pOnGame;
    //очки
    public Text Scoretext;
    public int Score;
    public int redScore;
    public int blueScore;
    public int greenScore;
    int red, blue, green;
    // Use this for initialization
    void Start () {

        position = transform.position;
        numberColor = 1;
        numberColorNotDoubleRed = 1;
        red = PlayerPrefs.GetInt("redScore");
        blue = PlayerPrefs.GetInt("blueScore");
        green = PlayerPrefs.GetInt("greenScore");

    }
     public void Move(float InputAxis)
    {

        directionInput = InputAxis;

    }
    // Update is called once per frame
    void Update () {
        //счет
        Score++;
        Scoretext.text = Score.ToString();
        //контроллер для андроид 
        if (directionInput==1)
        {
            go += 0.1f;
            if (go >= 1)
                go = 1;
        }
        if (directionInput==-1)
        {
            go -= 0.1f;
            if(go<=-1)
                go = -1;
        }
        if (directionInput == 0)
            go = 0;
         position.x += go * playerSpeed;
        //для ПК  position.x += Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        //ограничение по х
        position.x = Mathf.Clamp(position.x, minPos, maxPos);
        transform.position = position;
        //рандом из двух цветов
        if (WhatColor==1)
        {
            if (numberColorNotDoubleRed == 0 && numberColorNotDoubleGreen == 0)
            {
                numberColor = Random.Range(4, 6);
            }
            if (numberColorNotDoubleBlue == 0 && numberColorNotDoubleRed == 0)
            {
                numberColor = Random.Range(1, 3);            
            }
            if (numberColorNotDoubleGreen == 0 && numberColorNotDoubleBlue == 0)
            {
                numberColor = Random.Range(2, 4);  
            }
            //выбран рандомный цвет
            if (numberColor == 1 || numberColor == 4)
            {
                GetComponent<Renderer>().material.color = Color.red;
                numberColorNotDoubleRed = 1;
                numberColorNotDoubleBlue = 0;
                numberColorNotDoubleGreen = 0;
                //сколько раз выпал красный 
                redScore++;
                red = red + redScore;
                PlayerPrefs.SetInt("redScore", red);
            }
            if (numberColor == 2)
            {
                GetComponent<Renderer>().material.color = Color.blue;
                numberColorNotDoubleRed = 0;
                numberColorNotDoubleBlue = 1;
                numberColorNotDoubleGreen = 0;
                //сколько раз выпал синий
                blueScore++; 
                blue = blue + blueScore;
                PlayerPrefs.SetInt("blueScore", blue);
            }
            if (numberColor == 3 || numberColor == 5)
            {
                GetComponent<Renderer>().material.color = Color.green;
                numberColorNotDoubleRed = 0;
                numberColorNotDoubleBlue = 0;
                numberColorNotDoubleGreen = 1;
                // сколько раз выпал зеленый
                greenScore++;
                green = green + greenScore;
                PlayerPrefs.SetInt("greenScore", green);
            }
            //одно нажатие на кнопку
            WhatColor = 0;
        }
	}
    public void ChooseColor(int ChooseColor)
    {
        WhatColor = ChooseColor;
    }
    //Тут была ошибка с капсулой
    //Условие выбора цвета для прохождения через кубик
    void OnTriggerEnter(Collider col)
    {
      if (col.gameObject.tag == "Red" && (numberColor==2 || numberColor == 3|| numberColor == 5))
        {
            Lose();
        }
      if (col.gameObject.tag == "Blue" && (numberColor == 1 || numberColor == 3|| numberColor == 4 || numberColor == 5))
        {
            Lose();
        }
      if (col.gameObject.tag == "Green" && (numberColor == 1 || numberColor == 2 || numberColor == 4))
        {
            Lose();
        }
    }
    //проиграл
    void Lose()
    {
        //счет
        if (PlayerPrefs.GetInt("Score") < Score)
        {
            PlayerPrefs.SetInt("Score", Score);
        }
        //вызов панели проигрыша 
        pLose.SetActive(true);
        pPause.SetActive(false);
        pOnGame.SetActive(false);
        Destroy(gameObject);
    }
   
}
