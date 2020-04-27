using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChanger : MonoBehaviour
{

    public Animator animator;
    private float t;

    void Start() {
        t = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t > 3.0f) {
            FadeToLevel();
        }
    }

    public void FadeToLevel() {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene("GameScene");
    }

}
