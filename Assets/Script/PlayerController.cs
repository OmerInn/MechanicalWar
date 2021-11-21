using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletProductionPoint;
    public bool fired;
    public int score;
    public Text ScoreText;
    public GameObject FailPanel;
    public Text failText;
    public int highScore;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "High Score: "+ highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!fired)
            {
                fired = true;
                bulletActivefonk();
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            fired = false;
        }
    }
    void bulletActivefonk()
    {
        PoolingSystem.instance.SpawFromPool("Bullet", Vector3.zero, Quaternion.Euler(Vector3.zero));

        //int BPPChieldSize=BulletProductionPoint.transform.childCount; //bullet üretim noktamýzdaki chield sayýsýný yani bullet sayýsýný aldýk.
        //for (int i = 0; i <BPPChieldSize; i++)
        //{
        //    if (!BulletProductionPoint.transform.GetChild(i).gameObject.activeSelf)
        //    {
        //        BulletProductionPoint.transform.GetChild(i).gameObject.SetActive(true);
        //        break;
        //    }
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Finish")
        {
            Movement.instance.speedZ = 0;

        }
        if (collision.transform.tag=="Enemy")
        {
            if (highScore<score)
            {
                highScore = score;
                PlayerPrefs.SetInt("High Score", highScore);
            }
            failText.text = "GAME OVER \n SCORE \n" + score;
            FailPanel.SetActive(true);
        }
    }

    public void scoreText()
    {
        score++;
        ScoreText.text = "Score : " + score;
    }
   
}
