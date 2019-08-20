using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDrawLine : MonoBehaviour {

    public Whiteboard whiteboard;
    private Quaternion lastAngle;
    private bool lastTouch;


    public bool m_bIsDraw { get; set; }
    public bool m_bIsDrawing { get; set; }

    private RaycastHit hit;


    public Vector3 m_preForwardVector { get; set; }



    // Use this for initialization
    void Start () {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
        lineRenderer.numCapVertices = 1;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);

        m_bIsDraw = true;
        m_bIsDrawing = false;


        m_preForwardVector = new Vector3(0.0f, 0.0f, 0.0f);
        this.whiteboard = GameObject.Find("Whiteboard").GetComponent<Whiteboard>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;

        if (Input.GetKeyDown(KeyCode.Space) && !m_bIsDraw)
        {
            m_bIsDraw = true;
            lineRenderer.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && m_bIsDraw)
        {
            m_bIsDraw = false;
            lineRenderer.enabled = false;
        }

        if (m_bIsDraw)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit)
                && hit.collider.gameObject.name == "Whiteboard")
            {
                this.whiteboard = hit.collider.GetComponent<Whiteboard>();

                whiteboard.SetColor(Color.black);
                whiteboard.SetTouchPosition(hit.textureCoord.x, hit.textureCoord.y);
                whiteboard.ToggleTouch(true);

                if (lastTouch == false)
                {
                    lastTouch = true;
                    lastAngle = transform.rotation;
                }


                lineRenderer.startColor = Color.blue;
                lineRenderer.endColor = Color.blue;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);

                ////if (Input.GetKeyDown(KeyCode.A) && !m_bIsDrawing)
                //if (Input.GetKeyDown(KeyCode.A) && !m_bIsDrawing)
                //{
                //    m_bIsDrawing = true;

                //    GameObject.Find("Board").GetComponent<testBoard>().m_HitPos = hit.point;
                //}
                //else if (Input.GetKeyDown(KeyCode.A) && m_bIsDrawing)
                //{
                //    m_bIsDrawing = false;
                //}
            }
            else
            {
                whiteboard.ToggleTouch(false);
                lastTouch = false;

                lineRenderer.startColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                lineRenderer.endColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }

            if (lastTouch)
            {
                transform.rotation = lastAngle;
            }
        }
    }

    private void LateUpdate()
    {
        if(m_preForwardVector != transform.forward)
            m_preForwardVector = transform.forward;
    }
}
