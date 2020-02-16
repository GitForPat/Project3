using UnityEngine;

public class normalize : MonoBehaviour
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

            refToPlayer.Speed = 15.0f;
            collision.transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);

            collision.gameObject.layer = 0; //Don't ignore collisions 
            Color temp = refToRender.color;
            temp.a = 1.0f;
            refToRender.color = temp;

            refToPlayer.StatusAffectEnlarge = false;
            refToPlayer.StatusAffectShrink = false;
            refToPlayer.StatusAffectSpeedSlow = false;
            refToPlayer.StatusAffectSpeedUp = false;
        }
    }
}
