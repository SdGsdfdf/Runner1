using UnityEngine;
using System.Collections;

public class RandomGroundSpawn : MonoBehaviour {
    public GameObject[] groundPrefabs;
    int groundNumber;
    public float StartPos;
    public float EndPos;
    public float delayTimer;
    public float timer;
    public float timerx2;
    public float timerx3;
    public float x2;
    public float x3;

    // Use this for initialization
    void Start () {
        //обновляем скорость
        PlayerPrefs.SetFloat("uplvlx2", 0);
        PlayerPrefs.SetFloat("uplvlx3", 0);
        timer = delayTimer;
        //генерируем первые 10 блоков
        for (int i = 0; i < 10; i++)
        {
            StartPos += EndPos;
            Vector3 objectPos = new Vector3(transform.position.x, transform.position.y, StartPos);
            groundNumber = Random.Range(0, 4);
            Instantiate(groundPrefabs[groundNumber], objectPos, transform.rotation);
            
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //увеличиваем скорость х2
        timerx2 -= Time.deltaTime;
        if (timerx2 <= 0)
        {
            x2 = 1.4f;
        }
        //увеличиваем скорость х3
        timerx3 -= Time.deltaTime;
        if (timerx3 <= 0)
        {
            x3 = 0.7f;
        }
        //время появления блока 
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 objectPos = new Vector3(transform.position.x, transform.position.y, StartPos);
            groundNumber = Random.Range(0, 4);
            Instantiate(groundPrefabs[groundNumber], objectPos, transform.rotation);
            //увел скор на х2
            if (x2 == 1.4f)
            {
                PlayerPrefs.SetFloat("uplvlx2", x2);
                delayTimer = PlayerPrefs.GetFloat("uplvlx2");
            }
            //увел скор на х3
            if (x3 == 0.7f)
            {
                PlayerPrefs.SetFloat("uplvlx3", x3);
                delayTimer = PlayerPrefs.GetFloat("uplvlx3");
            }
            timer = delayTimer;
        }

    }
}
