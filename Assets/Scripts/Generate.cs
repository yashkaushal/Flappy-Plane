﻿using UnityEngine;

public class Generate : MonoBehaviour
{
	public GameObject rocks;
    public static int score = 0;
	
	// Use this for initialization
	void Start()
	{
        InvokeRepeating("CreateObstacle", 1f, Random.Range(1.5f, 2f));
	}
	
	// Update is called once per frame
	
	
	void CreateObstacle()
	{
		Instantiate(rocks);
		score++;
	}
}