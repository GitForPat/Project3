using UnityEngine;

public class climb : MonoBehaviour
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
            SpriteRenderer refToRender = collision.gameObject.GetComponent<SpriteRenderer>();

            if (!refToPlayer.StatusAffectCanClimb) {
                collision.gameObject.layer = 8; //Ignore collisions with all objects that are not set to defualt
                Color temp = refToRender.color;
                temp.a = 0.5f;
                refToRender.color = temp;
                refToPlayer.StatusAffectCanClimb = true;

                if (refToPlayer.StatusAffectNoClimb) {
                    refToPlayer.StatusAffectNoClimb = false;
                }
            }
        }
    }
}
