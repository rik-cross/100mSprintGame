using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;
    public AudioSource beep;
    public AudioSource boop;

    private GameplayManager gameplayManager;
    void Awake() {
        gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        boop = GameObject.Find("Boop").GetComponent<AudioSource>();
    }

    void OnEnable() {
        countdownText.text = "3";
        StartCoroutine("StartCountdown");
    }

    IEnumerator StartCountdown() {
        int count = 3;
        for (int i = 0; i < count; i++) {
            countdownText.text = (count - i).ToString();
            beep.Play();
            yield return new WaitForSeconds(1);
        }
        boop.Play();
        gameplayManager.setGameState(2);
    }
}
