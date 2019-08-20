using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class board : MonoBehaviour
{

    private GameObject m_TargetGameobject;// = GameObject.Find("CenterEyeAnchor");
    public bool m_bIsRender { get; set; }

    private int textureSize = 2048;
    private int penSize = 1;
    private Texture2D texture;
    private Color[] color;

    private bool touching, touchingLast;
    private float posX, posY;
    private float lastX, lastY;

    // Use this for initialization
    void Start()
    {
        m_TargetGameobject = GameObject.Find("CenterEyeAnchor");
        transform.position = m_TargetGameobject.transform.position + m_TargetGameobject.transform.forward * 0.8f;
        transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), 270.0f);
        // Set whiteboard texture
        Renderer renderer = GetComponent<Renderer>();
        this.texture = new Texture2D(textureSize, textureSize);
        renderer.material.mainTexture = (Texture)texture;
    }

    // Update is called once per frame
    void Update()
    {
        m_TargetGameobject = GameObject.Find("CenterEyeAnchor");
        if (GameObject.Find("hand_right").GetComponent<testDrawLine>().m_bIsDraw)
        {
            if (!m_bIsRender)
            {
                transform.position = m_TargetGameobject.transform.position + m_TargetGameobject.transform.forward * 0.8f;
                transform.LookAt(transform.position + m_TargetGameobject.transform.rotation * Vector3.back, m_TargetGameobject.transform.rotation * Vector3.down);
            }

            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            m_bIsRender = true;


            // Transform textureCoords into "pixel" values
            int x = (int)(posX * textureSize - (penSize / 2));
            int y = (int)(posY * textureSize - (penSize / 2));

            // Only set the pixels if we were touching last frame
            if (touchingLast)
            {
                // Set base touch pixels
                texture.SetPixels(x, y, penSize, penSize, color);

                // Interpolate pixels from previous touch
                for (float t = 0.01f; t < 1.00f; t += 0.01f)
                {
                    int lerpX = (int)Mathf.Lerp(lastX, (float)x, t);
                    int lerpY = (int)Mathf.Lerp(lastY, (float)y, t);
                    texture.SetPixels(lerpX, lerpY, penSize, penSize, color);
                }
            }

            // If currently touching, apply the texture
            if (touching)
            {
                texture.Apply();
            }

            this.lastX = (float)x;
            this.lastY = (float)y;

            this.touchingLast = this.touching;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            m_bIsRender = false;
        }
    }

    public void ToggleTouch(bool touching)
    {
        this.touching = touching;
    }

    public void SetTouchPosition(float x, float y)
    {
        this.posX = x;
        this.posY = y;
    }

    public void SetColor(Color color)
    {
        this.color = Enumerable.Repeat<Color>(color, penSize * penSize).ToArray<Color>();
    }
}
