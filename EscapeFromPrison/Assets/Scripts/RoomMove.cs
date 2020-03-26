using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange; // how much the camera changes
    public Vector3 playerChange; // how much the player moves after change
    private CameraMovement cam; // refer to cameraMovement Script
    public bool needText;
    public string placeName;
    public GameObject text; // refers to text box in unity
    public Text placeText;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>(); // refer to cameraMovement Script
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //if entity tagged player collides
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    private IEnumerator placeNameCo() // makes text show up for a time (This Can be used to make instruction text Pop up)
    {
        text.SetActive(true); // makes inactive UI Active
        placeText.text = placeName;
        yield return new WaitForSeconds(4f); // wait for secnds delay
        text.SetActive(false); // disable UI after WaitForSeconds Delay
    }
}
