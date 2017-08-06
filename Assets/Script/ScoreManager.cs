using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int score;
    public Text scoreText;
	// Use this for initialization
	void Start () {

        //karena variabel "score" pada Class GameManager bersifat static, maka bisa langsung memanggil variable tersebut dengan cara menuliskan nama Classnya telebih dahulu
        score = GameManager.score;
        scoreText.text = ("Your correct answer is: "+score+"/5");
    }
	
}
