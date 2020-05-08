using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{

    public GameObject m25;
    public GameObject m50;
    public GameObject m75;
    public GameObject finishLine;
    public GameObject sprinter;

    public GameObject startScreen;
    public GameObject countdownScreen;
    public GameObject playScreen;
    public GameObject gameOverScreen;

    public GameObject cloud;
    public GameObject cloud2;

    public Text distanceText;
    public Text timeText;
    public Text bestTimeText;
    public Text finalRaceTimeText;

    private float scale = 0.3f;
    private float distance;
    private float timer;
    
    private int gameState;

    public void setGameState(int newState) {
        gameState = newState;
        switch (gameState) {
            case 0:
                reset();
                startScreen.SetActive(true);
                countdownScreen.SetActive(false);
                playScreen.SetActive(false);
                gameOverScreen.SetActive(false);
                break;
            case 1:
                reset();
                startScreen.SetActive(false);
                countdownScreen.SetActive(true);
                playScreen.SetActive(true);
                gameOverScreen.SetActive(false);
                if ( PlayerPrefs.HasKey("fastestTime") ) {
                	bestTimeText.enabled = true;
                	bestTimeText.text = PlayerPrefs.GetFloat("fastestTime").ToString("F2") + "s";
                } else {
                	bestTimeText.enabled = false;
                }
                break;
            case 2:
                startScreen.SetActive(false);
                countdownScreen.SetActive(false);
                playScreen.SetActive(true);
                gameOverScreen.SetActive(false);
                break;
            case 3:
                startScreen.SetActive(false);
                countdownScreen.SetActive(false);
                playScreen.SetActive(false);
                gameOverScreen.SetActive(true);
                break;
        }
    }
    public int getGameState() {
        return gameState;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        setGameState(0);
    }

    // Update is called once per frame
    void Update()
    {

        switch(gameState) {
            case 0:
                break;
            case 1:
                sprinter.GetComponent<PlayerController>().reset();
                break;
            case 2:
                if (distance < 100) {
                    timer += Time.deltaTime;
                }
                m25.transform.position = new Vector3( (25 * scale) - (distance * scale) , m25.transform.position.y, m25.transform.position.z);
                m50.transform.position = new Vector3( (50 * scale) - (distance * scale) , m50.transform.position.y, m50.transform.position.z);
                m75.transform.position = new Vector3( (75 * scale) - (distance * scale) , m75.transform.position.y, m75.transform.position.z);
                finishLine.transform.position = new Vector3( (100 * scale) - (distance * scale) , finishLine.transform.position.y, finishLine.transform.position.z);
                timeText.text = timer.ToString("F2") + "s";
                distanceText.text = Mathf.Min(100, distance).ToString("0") + "m";
                if (distance > 100) {
                
                    if ( PlayerPrefs.HasKey("fastestTime") == false || timer < PlayerPrefs.GetFloat("fastestTime") ) {
                        PlayerPrefs.SetFloat("fastestTime", timer);	
                    }
                
                    setGameState(3);
                }
                break;
            case 3:
                m25.transform.position = new Vector3( (25 * scale) - (distance * scale) , m25.transform.position.y, m25.transform.position.z);
                m50.transform.position = new Vector3( (50 * scale) - (distance * scale) , m50.transform.position.y, m50.transform.position.z);
                m75.transform.position = new Vector3( (75 * scale) - (distance * scale) , m75.transform.position.y, m75.transform.position.z);
                finishLine.transform.position = new Vector3( (100 * scale) - (distance * scale) , finishLine.transform.position.y, finishLine.transform.position.z);
                finalRaceTimeText.text = timer.ToString("F2") + "s";
                break;
        }
        cloud.transform.position = new Vector3( cloud.transform.position.x - 0.002f - (sprinter.GetComponent<PlayerController>().getVelocity() * 0.1f ) , cloud.transform.position.y, cloud.transform.position.z);
        if (cloud.transform.position.x < -5) {
            cloud.transform.position = new Vector3( 5, cloud.transform.position.y, cloud.transform.position.z);
        }
        cloud2.transform.position = new Vector3( cloud2.transform.position.x - 0.002f - (sprinter.GetComponent<PlayerController>().getVelocity() * 0.1f ) , cloud2.transform.position.y, cloud2.transform.position.z);
        if (cloud2.transform.position.x < -5) {
            cloud2.transform.position = new Vector3( 5, cloud2.transform.position.y, cloud2.transform.position.z);
        }

    }

    public void setDistance(float newDistance) {
        distance = newDistance;
    }

    public float getDistance() {
        return distance;
    }

    private void reset() {
        distance = 0f;
        timer = 0f;
        distanceText.text = "0m";
        timeText.text = "0s";
        m25.transform.position = new Vector3( 5 , m25.transform.position.y, m25.transform.position.z);
        m50.transform.position = new Vector3( 5 , m50.transform.position.y, m50.transform.position.z);
        m75.transform.position = new Vector3( 5 , m75.transform.position.y, m75.transform.position.z);
        finishLine.transform.position = new Vector3( 5 , finishLine.transform.position.y, finishLine.transform.position.z);
                
    }

}
