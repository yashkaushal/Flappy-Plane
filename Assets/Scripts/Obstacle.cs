using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public Vector2 velocity = new Vector2(-4, 0);
	public float range = 1;
	
	// Use this for initialization
	void Start()
	{
        var rand = Random.Range(-range, range);
        GetComponent<Rigidbody2D>().velocity = velocity;
        transform.position = new Vector3(transform.position.x, transform.position.y + rand, transform.position.z);
        transform.localScale += new Vector3(0, Mathf.Abs(rand)/2, 0);
	}
}