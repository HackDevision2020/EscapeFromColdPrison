using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // what the camera follows
    public float smoothing; //how quickly the camera follow the target
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() // LateUpdate always comes last so camera moves last (smoother camera)
    {
        if(transform.position != target.position) // if camera not fixed in target follow the target
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x); // restricts camera movement x
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y); // restricts camera movement y
            transform.position = Vector3.Lerp(transform.position,targetPosition, smoothing); //Lerp find the target and move to the target percentage wise. target.position (Where u r at, where u want the camera to go, amount u want to travel)

        }
    }
}
