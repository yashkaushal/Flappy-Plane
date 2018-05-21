using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    
    public static int score = 0;
    [SerializeField]
    private UnityEngine.UI.Text scoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateScoreText(){
        scoreText.text = "Score : " + score + System.Environment.NewLine + "Best : " + "5";
    }


	private void OnTriggerEnter(Collider other)
	{
        Debug.Log("score!");

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log("scoresssss!");
        updateScoreText();

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("score!");

	}
}
