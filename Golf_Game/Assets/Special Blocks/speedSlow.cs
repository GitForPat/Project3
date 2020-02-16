using UnityEngine;

public class speedSlow : MonoBehaviour
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
            if (timerMax <= activeTimer) {
                activeTimer = 0.0f;
                wasTriggered = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (string.Compare("Player", collision.transform.tag) == 0 && !wasTriggered) {
            wasTriggered = true;
            playerMain refToPlayer = collision.gameObject.GetComponent<playerMain>();

            if (!refToPlayer.StatusAffectSpeedSlow) {
                refToPlayer.Speed -= 10.0f;
                refToPlayer.StatusAffectSpeedSlow = true;

                if (refToPlayer.StatusAffectSpeedUp) { //If player is currently slowed, double the speed up affect
                    refToPlayer.StatusAffectSpeedUp = false;
                    refToPlayer.Speed -= 10.0f;
                }
            }
        }
    }
}
