using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameObject gameoverText;
    private GameObject runLengthText;
    private float len = 0;
    private float speed = 5f;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
        
    }

    // Update is called once per frame
    void Update()
    {
     if (this.isGameOver == false)
        {
            this.len += this.speed * Time.deltaTime;
            this.runLengthText.GetComponent<Text>().text = "Distance:" + len.ToString("F2") + "m";
               //runLengthText変数のtextに代入するときはlen.ToString ("F2")としてlen変数をToString関数を使って文字列に変換しています。
        }

     if (this.isGameOver == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        this.gameoverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
}
