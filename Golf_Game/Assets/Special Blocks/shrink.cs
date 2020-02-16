using UnityEngine;

public class shrink : MonoBehaviour
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

            if (!refToPlayer.StatusAffectShrink) {
                Vector3 playerScale = collision.transform.localScale;
                Vector3 temp = new Vector3(playerScale.x / 2.0f, playerScale.y / 2.0f, playerScale.z / 2.0f);
                collision.transform.localScale = temp;
                refToPlayer.StatusAffectShrink = true;

                if (refToPlayer.StatusAffectEnlarge) { //If player is currently enlarged, double the shrink affect
                    refToPlayer.StatusAffectEnlarge = false;
                    playerScale = collision.transform.localScale;
                    temp = new Vector3(playerScale.x / 2.0f, playerScale.y / 2.0f, playerScale.z / 2.0f);
                    collision.transform.localScale = temp;
                }
            }
        }
    }
}
