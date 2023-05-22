using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceAnimation : MonoBehaviour
{
    public Animator DiceAnimator;
    Game dice;
    // Start is called before the first frame update
    void Start()
    {
        dice = GetComponentInParent<Game>();
        DiceAnimator = GetComponent<Animator>();
        DiceAnimator.SetTrigger("rolling");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hide() {
        gameObject.SetActive(false);
    }

    public void show() {
        gameObject.SetActive(true);
    }

    public void roll() {
        DiceAnimator.SetTrigger("rolling");
    }
    public void FinishedAnimation() {
        dice.FinishedAnimation();
    }
}
