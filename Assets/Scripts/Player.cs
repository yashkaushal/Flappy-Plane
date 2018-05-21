using UnityEngine;

public class Player : MonoBehaviour
{
	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	public Vector2 jumpForce = new Vector2(0, 300);
	
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
	
	void Die()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene(Application.loadedLevel);
	}
}
