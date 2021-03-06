﻿using UnityEngine;

public class enlarge : MonoBehaviour
{
    private float activeTimer;
    private float timerMax;
    private bool wasTriggered;

    private void Awake() {
        activeTimer = 0.0f;
        timerMax = 0.5f;
        wasTriggered = false;
    }

    private void Update() {
        if (wasTriggered) {
            activeTimer += Time.deltaTime;
            if(timerMax <= activeTimer) {
                activeTimer = 0.0f;
                wasTriggered = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(string.Compare("Player", collision.transform.tag) == 0 && !wasTriggered) {
            wasTriggered = true;
            playerMain refToPlayer = collision.gameObject.GetComponent<playerMain>();
            if (!refToPlayer.StatusAffectEnlarge) {
                collision.transform.localScale *= 2.0f;
                refToPlayer.StatusAffectEnlarge = true;

                if (refToPlayer.StatusAffectShrink) { //If player is currently shrink, double the enlarge affect
                    refToPlayer.StatusAffectShrink = false;
                    collision.transform.localScale *= 2.0f;
                }
            }
        }
    }
}
