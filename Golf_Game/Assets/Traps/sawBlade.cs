using UnityEngine;

public class sawBlade : MonoBehaviour
{
    private float moveSpeed;
    [SerializeField]
    private Transform movePointOne;
    [SerializeField]
    private Transform movePointTwo;
    private Vector2 locationStart;
    private Vector2 locationEnd;

    private float distanceToTravel;
    private float startTime;
    private bool lerpingHere;


    private void Awake() {
        moveSpeed = 10.0f;
        startTime = 0.0f;
        locationStart = movePointOne.position;
        locationEnd = movePointTwo.position;
        this.gameObject.transform.position = locationEnd;
        lerpingHere = false;
        calculateJourneyLenght();
    }

    private void Update() {
        if ((Vector2)this.gameObject.transform.position == locationEnd && !lerpingHere) {
            startTime = Time.time;
            lerpingHere = true;
            Vector2 temp = locationEnd;
            locationEnd = locationStart;
            locationStart = temp;
        }

        if ((Vector2)this.gameObject.transform.position == locationEnd && !lerpingHere) {
            startTime = Time.time;
            lerpingHere = true;
            Vector2 temp = locationEnd;
            locationEnd = locationStart;
            locationStart = temp;
        }
    }

    private void FixedUpdate() {
        if (lerpingHere) {
            lerpingOverHere(locationStart, locationEnd);
        }
    }

    private void calculateJourneyLenght() {
        distanceToTravel = Mathf.Sqrt(Mathf.Pow((locationEnd.x - locationStart.x), 2.0f) + Mathf.Pow((locationEnd.y - locationStart.y), 2.0f));
    }

    private void lerpingOverHere(Vector2 startingLocation, Vector2 endingLocation) {
        float distanceToCover = (Time.time - startTime) * moveSpeed;
        float fractionOfJourney = distanceToCover / distanceToTravel;
        this.gameObject.transform.position = Vector3.Lerp(startingLocation, endingLocation, fractionOfJourney);

        if ((Vector2)this.gameObject.transform.position == locationEnd) {
            lerpingHere = false;
        }

        if ((Vector2)this.gameObject.transform.position == locationEnd) {
            lerpingHere = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (string.Compare("Player", collision.transform.tag) == 0) {
            collision.gameObject.GetComponent<playerMain>().MyUIController.showFailCase();
            Destroy(collision.gameObject);
        }
    }
}
