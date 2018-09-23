using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//necessary for text
using UnityEngine.SceneManagement;//necessary for SceneManager

public class ApplePicker : MonoBehaviour {

    public GameObject       basketPrefab;
    public int              numBaskets = 3;
    public float            basketBottomY = -10f;
    public float            basketSpacingY = 2f;
    public Text             scoreUI;
    private int             score;
    public List<GameObject> basketList;
    static private int      highScore = 10;
    public Text             highScoreUI;

    //Unity built-in function.  Always happens before Start.
    private void Awake()
    {
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))//if it exists yet
        {
            highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
    }

    // Use this for initialization
    void Start () {

		for(int i=0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
        score = 0;
        setScore();
        setHighScore();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AppleCaught()
    {
        score += 1;
        setScore();
        if(score > highScore)
        {
            highScore = score;
            setHighScore();
        }
    }

    void setScore()
    {
        scoreUI.text = "Apples Caught: " + score.ToString();
    }

    void setHighScore()
    {
        highScoreUI.text = "Most Apples Ever Caught: " + highScore.ToString();
        PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
    }

    public void AppleDestroyed()
    {
        //destroy all falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject GO in tAppleArray)
        {
            Destroy(GO);
        }

        //destory a basket
        //Get index of last basket in list
        int basketIndex = basketList.Count - 1;//array starts at 0
        GameObject basketToRemove = basketList[basketIndex];//get a reference to the GO
        basketList.RemoveAt(basketIndex);//remove from list
        Destroy(basketToRemove);//remove GO

        //restart the game, when out of baskets
        if(basketList.Count == 0)
        {
            //Application.LoadLevel("_Scene_0");
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
