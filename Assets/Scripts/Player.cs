using UnityEngine;

public class Player : MonoBehaviour
{
	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	public Vector2 jumpForce = new Vector2(0, 300);

    int score = -1;
    [SerializeField]
    private UnityEngine.UI.Text scoreText;

    public GameObject[] Planes;

    public static int highScore;

	private void Start()
	{
        updateScoreText();
        if(MenuControl.instance.myplanecolour == MenuControl.PlaneColour.Green){
            Planes[0].SetActive(true);
        }
        else{
            Planes[1].SetActive(true);
        }

        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else
        {
            PlayerPrefs.SetInt("highScore", 0);
            PlayerPrefs.Save();
        }

	}

	// Update is called once per frame
	void Update ()
	{
		// Jump
        if (Input.GetKeyUp("space")||(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
            GetComponent<Animator>().SetTrigger("Pop");
		}
		
		// Die by being off screen
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0)
		{
			Die();
		}
	}
	
	// Die by collision
	void OnCollisionEnter2D(Collision2D other)
	{
		Die();
	}

    public void updateScoreText()
    {
        score++;

        if(highScore < score){
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();

            highScore = score;
        } 
        scoreText.text = "Score : " + score + System.Environment.NewLine + "Best : " + highScore.ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("scores!");
        updateScoreText();

    }
	
	void Die()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene(Application.loadedLevel);
	}
}
