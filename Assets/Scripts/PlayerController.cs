﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameplayManager gameplayManager;
    private float distance = 0.0f;
    private float velocity = 0.0f;
    private float acceleration = 0.1f;
    private float deceleration = 0.008f;

    private Animator playerAnimation;

    void Awake() {
        gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
    }

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        distance = 0f;
    }

    public void setVelocity(float v) {
        velocity = v;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && distance <= 100 && gameplayManager.getGameState() == 2) {
            velocity += acceleration;
        }

        velocity = Mathf.Max(0, velocity - deceleration);
        distance += velocity;
        gameplayManager.setDistance(distance);

        playerAnimation.SetFloat("velocity", velocity);
        playerAnimation.SetFloat("animationSpeed", 1.0f + velocity);
    }

    public void reset() {
        distance = 0f;
        velocity = 0f;
        playerAnimation.SetFloat("velocity", 0);
        playerAnimation.SetFloat("animationSpeed", 1.0f + velocity);
    }

    public float getVelocity() {
        return velocity;
    }

}
