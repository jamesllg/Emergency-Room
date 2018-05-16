using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{

    public int maxRotationHeight;
    public int minRotationHeight;
    public float euX;
    public float nextVertical;
    public float rotationSpeed;
    public float lagRotationSpeed;
    public bool goodTouch = false;
    public bool lagFriendly = false;

    private Vector2 touchOrigin = -Vector2.one;
    private Vector2 touchCurrent = -Vector2.one;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Rotate head around local x-axis from touch input
        float vertical = 0;
        if (Input.touchCount > 0)
        {
            Touch touch1 = Input.touches[0];
            if (touch1.phase == TouchPhase.Began && touch1.position.y > Screen.height / 3)
            {
                goodTouch = true;
                touchOrigin = touch1.position;
            }

            if (touch1.phase == TouchPhase.Moved && touch1.position.y > Screen.height / 3 && goodTouch)
            {
                touchCurrent = touch1.position;
                if (lagFriendly)
                {
                    vertical = lagRotationSpeed * (touchCurrent.y - touchOrigin.y) * Time.deltaTime / Screen.height;

                }
                else
                {
                    vertical = rotationSpeed * (touchCurrent.y - touchOrigin.y) / Screen.height;

                }
                euX = transform.eulerAngles.x;
                nextVertical = (vertical + transform.eulerAngles.x) % 360;
                if (nextVertical < maxRotationHeight ||
                    nextVertical > minRotationHeight)
                {
                    transform.Rotate(vertical, 0.0f, 0.0f);
                }
            }

            if (touch1.phase == TouchPhase.Ended)
            {
                goodTouch = false;
            }

            touchOrigin = touch1.position;
        }
    }
}
