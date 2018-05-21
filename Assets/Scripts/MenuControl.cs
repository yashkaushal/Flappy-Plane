using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {

    public static MenuControl instance;

    public enum PlaneColour{
        Green,
        Red
    }

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a LevelMenu.
            Destroy(instance.gameObject);
            instance = this;
        }
    }
    public GameObject[] planes;
    public PlaneColour myplanecolour = PlaneColour.Green;

    public void ChangePlaneColour(){
        if (myplanecolour == PlaneColour.Green)
            myplanecolour = PlaneColour.Red;
        else
            myplanecolour = PlaneColour.Green;

        if (myplanecolour == PlaneColour.Green)
        {
            planes[0].SetActive(true);
            planes[1].SetActive(false);
        }
        else
        {
            planes[1].SetActive(true);
            planes[0].SetActive(false);
        }
        Debug.Log("Plane Colour switched");
    }

    public void startGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
