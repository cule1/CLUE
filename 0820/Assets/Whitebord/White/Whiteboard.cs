using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Whiteboard : MonoBehaviour
{

    private int textureSize = 2048;
    private int penSize = 10;
    private int eraseSize = 30;
    private Texture2D texture;
    private Color[] color;
    private Texture2D[] page = new Texture2D[5];

    private bool touching, touchingLast;
    private float posX, posY;
    private float lastX, lastY;
    private int iPage = 0;

    private bool isPen = false;

    [HideInInspector]
    public Vector3 fixedPos;
    [HideInInspector]
    public Quaternion fixedRot;
    [HideInInspector]
    public bool IsfixedPos;

    public GameObject pageText;

    // Use this for initialization
    void Start()
    {
        // Set whiteboard texture
        Renderer renderer = GetComponent<Renderer>();
        this.texture = new Texture2D(textureSize, textureSize);
        renderer.material.mainTexture = (Texture)texture;

        for (int i = 0; i < 5; ++i)
        {
            page[i] = new Texture2D(textureSize, textureSize);
        }

        renderer.material.mainTexture = page[0];
    }

    // Update is called once per frame
    void Update()
    {
        isPen = GameObject.Find("Pen").GetComponent<WhiteboardPen>().isPen;

        if (IsfixedPos)
        {
            transform.position = fixedPos - new Vector3(0.0f, 0.07f, 0.0f);
            transform.rotation = fixedRot;
        }

        //if (Input.GetKeyDown(KeyCode.Q) && iPage < 4)
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch) && iPage < 4)
        {
            iPage++;
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = page[iPage];

            pageText.GetComponent<Text>().text = "- " + (iPage + 1) + " -";
        }
        //if (Input.GetKeyDown(KeyCode.E) && iPage > 0)
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch) && iPage > 0)
        {
            iPage--;
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = page[iPage];

            pageText.GetComponent<Text>().text = "- " + (iPage + 1) + " -";
        }

        int x = 0;
        int y = 0;
        // Transform textureCoords into "pixel" values
        if (isPen)
        {
            x = (int)(posX * textureSize - (penSize / 2));
            y = (int)(posY * textureSize - (penSize / 2));
        }
        else
        {
            x = (int)(posX * textureSize - (eraseSize / 2));
            y = (int)(posY * textureSize - (eraseSize / 2));
        }


        // Only set the pixels if we were touching last frame
        if (touchingLast)
        {

            if (isPen)
            {
                // Set base touch pixels
                page[iPage].SetPixels(x, y, penSize, penSize, color);

                // Interpolate pixels from previous touch
                for (float t = 0.01f; t < 1.00f; t += 0.01f)
                {
                    int lerpX = (int)Mathf.Lerp(lastX, (float)x, t);
                    int lerpY = (int)Mathf.Lerp(lastY, (float)y, t);
                    page[iPage].SetPixels(lerpX, lerpY, penSize, penSize, color);
                }
            }
            else
            {
                // Set base touch pixels
                page[iPage].SetPixels(x, y, eraseSize, eraseSize, color);

                // Interpolate pixels from previous touch
                for (float t = 0.01f; t < 1.00f; t += 0.01f)
                {
                    int lerpX = (int)Mathf.Lerp(lastX, (float)x, t);
                    int lerpY = (int)Mathf.Lerp(lastY, (float)y, t);
                    page[iPage].SetPixels(lerpX, lerpY, eraseSize, eraseSize, color);
                }
            }
        }

        // If currently touching, apply the texture
        if (touching)
        {
            page[iPage].Apply();
        }

        this.lastX = (float)x;
        this.lastY = (float)y;

        this.touchingLast = this.touching;
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
        if (isPen)
            this.color = Enumerable.Repeat<Color>(color, penSize * penSize).ToArray<Color>();
        else
            this.color = Enumerable.Repeat<Color>(color, eraseSize * eraseSize).ToArray<Color>();
    }
}