using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;

    private GameplayManager gameplayManager;
    void Awake() {
        gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
    }

    void OnEnable() {
        countdownText.text = "3";
        StartCoroutine("StartCountdown");
    }

    IEnumerator StartCountdown() {
        int count = 3;
        for (int i = 0; i < count; i++) {
            countdownText.text = (count - i).ToString();
            yield return new WaitForSeconds(1);
        }
        gameplayManager.setGameState(2);
    }
}
