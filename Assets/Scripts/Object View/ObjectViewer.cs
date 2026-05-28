using UnityEngine;
using System.Collections;

public class ObjectViewer : MonoBehaviour
{

    // Object or Transform which we want to rotate
    public Transform targetObject;

    // these are the import but hush hush settings for the rotation properties
    public RotationProperties rotationProperties;
    private float xDeg;
    private float yDeg;
    private Quaternion fromRotation;
    private Quaternion toRotation;

    // we store our rotation settings in a class to seperate them
    [System.Serializable]
    public class RotationProperties
    {
        // rotation speed
        public int speed = 10;
        // rotation friction
        public float friction = 1;
        // rotation smoothing speed
        public float lerpSpeed = 10;
    }

    // secret secret zoom settings
    public ZoomProperties zoomProperties;
    private Vector3 position;
    private float toPosition;

    // now we seperate the zoom settings
    [System.Serializable]
    public class ZoomProperties
    {
        // this value should always be the lowest of the two
        public float minZ = -7.5f;
        // this value should be the highest (even when negative should be the highest or in this case lowest negative value)
        public float maxZ = -2.5f;
        // speed of scroll
        public int speed = 1;
        // zoom smoothing speed
        public float lerpSpeed = 1;
    }

    // on Update... of course
    void Update()
    {
        // if the target isn't null then we run our code
        if (targetObject != null)
        {
            // on left mouse button pressed..
            if (Input.GetMouseButton(0))
            {
                // we apply our x rotation using a little bit of math into our variable
                xDeg -= Input.GetAxis("Mouse X") * rotationProperties.speed * rotationProperties.friction;
                // we apply our y rotation using a little bit of math into our variable
                yDeg += Input.GetAxis("Mouse Y") * rotationProperties.speed * rotationProperties.friction;
                // we store the targets current rotation
                fromRotation = targetObject.rotation;
                // our new rotation with the new values
                toRotation = Quaternion.Euler(yDeg, xDeg, 0);
                // now apply our new values to our object
                targetObject.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * rotationProperties.lerpSpeed);
            }

            // we get the current position of the camera
            position = Camera.main.transform.localPosition;
            // we should set our new position to old first, for relative math then apply our scroll wheel value and speed setting
            toPosition = position.z += Input.GetAxis("Mouse ScrollWheel") * zoomProperties.speed;
            // now we use Lerp, to smooth our zoom speed (or more precisely our position as it slides forward and back)
            position.z = Mathf.Lerp(position.z, toPosition, Time.deltaTime * zoomProperties.lerpSpeed);
            // now we apply a clamp, so that it never goes beyond what the limitations we place
            position.z = Mathf.Clamp(position.z, zoomProperties.minZ, zoomProperties.maxZ);
            // now we set the new values to the object
            Camera.main.transform.localPosition = position;
        }
    }
}