using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class WhiteboardPen : VRTK_InteractableObject {

	//private VRTK_ControllerActions controllerActions;
	public Whiteboard whiteboard;
	private RaycastHit touch;
	private Quaternion lastAngle;
	private bool lastTouch;

    [HideInInspector]
    public bool isPen;
    private int textureSize = 2048;
    private Color eraser;

    // Use this for initialization
    void Start () {
		// Get our Whiteboard component from the whiteboard object
		this.whiteboard = GameObject.Find("Whiteboard").GetComponent<Whiteboard>();

        Texture2D newTex = new Texture2D(textureSize, textureSize);
        eraser = newTex.GetPixel(0, 0);

        isPen = true;
    }

	// Update is called once per frame
	void Update () {
		float tipHeight = transform.Find ("Tip").transform.localScale.y;
		Vector3 tip = transform.Find ("Tip/TouchPoint").transform.position;

		Debug.Log (tip);

		if (lastTouch) {
			tipHeight *= 1.1f;
		}

        if (OVRInput.GetDown(OVRInput.Button.Two) && !isPen)
            isPen = true;
        else if (OVRInput.GetDown(OVRInput.Button.Two) && isPen)
            isPen = false;

        // Check for a Raycast from the tip of the pen
        if (Physics.Raycast (tip, transform.up, out touch, tipHeight)) {
			if (!(touch.collider.tag == "Whiteboard")) return;
    		this.whiteboard = touch.collider.GetComponent<Whiteboard>();

            // Give haptic feedback when touching the whiteboard
            //controllerActions.TriggerHapticPulse (0.05f);

            // Set whiteboard parameters
            // 수정
            if (isPen)
                whiteboard.SetColor(Color.black);
            else if (!isPen)
                whiteboard.SetColor(eraser);

            whiteboard.SetTouchPosition (touch.textureCoord.x, touch.textureCoord.y);
			whiteboard.ToggleTouch (true);

			// If we started touching, get the current angle of the pen
			if (lastTouch == false) {
				lastTouch = true;
				lastAngle = transform.rotation;
			}
		} else {
			whiteboard.ToggleTouch (false);
			lastTouch = false;
		}

		// Lock the rotation of the pen if "touching"
		if (lastTouch) {
			transform.rotation = lastAngle;
		}
	}

	//public override void Grabbed(GameObject grabbingObject)
	//{
	//	base.Grabbed(grabbingObject);
	//	controllerActions = grabbingObject.GetComponent<VRTK_ControllerActions>();
	//}
}
