using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayerController : MonoBehaviour
{

    private GameplayManager gameplayManager;
    private float distance = 0.0f;
    private float velocity = 0.0f;
    private float acceleration = 0.1f;
    private float deceleration = 0.008f;
    private bool animate = false;

    private Animator ghostPlayerAnimation;

    void Awake() {
        gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
    }

    void Start()
    {
        ghostPlayerAnimation = GetComponent<Animator>();
        distance = 0f;
        ghostPlayerAnimation.SetFloat("velocity", velocity);
        ghostPlayerAnimation.SetFloat("animationSpeed", 1.0f + velocity);
    }

    public void setAnimate(bool a) {
        animate = a;
    }

    void Update()
    {

	if (distance < 105 && animate) {
            velocity = 100 / PlayerPrefs.GetFloat("fastestTime") / 55.0f;
        } else {
            velocity = Mathf.Max(0, velocity - deceleration);    
        }
        //Debug.Log(velocity);
        distance += velocity;
        gameplayManager.setGhostDistance(distance);

        ghostPlayerAnimation.SetFloat("velocity", velocity);
        ghostPlayerAnimation.SetFloat("animationSpeed", 1.0f + velocity);
    }

    public void reset() {
        distance = 0f;
        velocity = 0f;
    }

    public float getVelocity() {
        return velocity;
    }

}
