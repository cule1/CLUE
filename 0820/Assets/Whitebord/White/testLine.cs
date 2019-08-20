using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLine : MonoBehaviour
{

    GameObject emptyGameObject;
    GameObject BoardGameObject;
    private List<Vector3> m_lProjectedPos = new List<Vector3>();
    private Vector3 m_vConvertPos = new Vector3(0.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start()
    {
        //emptyGameObject = new GameObject("line");

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
        lineRenderer.numCapVertices = 1;
        lineRenderer.useWorldSpace = true;

        BoardGameObject = GameObject.Find("Board");
    }

    // Update is called once per frame
    void Update()
    {
        //LineRenderer lineRenderer = emptyGameObject.GetComponent<LineRenderer>();
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();

        if (m_lProjectedPos != null)
        {
            if (BoardGameObject.GetComponent<testBoard>().m_bIsRender)
            {
                lineRenderer.enabled = true;
                lineRenderer.positionCount = m_lProjectedPos.Count + 1;

                float dot = 1.0f;
                if (GameObject.Find("Pen").GetComponent<testDrawLine>().m_preForwardVector != GameObject.Find("Pen").transform.forward)
                {
                    dot = Vector3.Dot(GameObject.Find("Pen").GetComponent<testDrawLine>().m_preForwardVector, GameObject.Find("Pen").transform.forward);
                }

                //float dot = Vector3.Dot(BoardGameObject.GetComponent<testBoard>().m_preForwardVector, BoardGameObject.transform.forward);
                //float dot = Vector3.Dot(GameObject.Find("Pen").GetComponent<testDrawLine>().m_preForwardVector, GameObject.Find("Pen").transform.forward);
                float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
                //Vector3 cross = Vector3.Cross(BoardGameObject.GetComponent<testBoard>().m_preForwardVector, BoardGameObject.transform.forward);
                Vector3 cross = Vector3.Cross(GameObject.Find("Pen").GetComponent<testDrawLine>().m_preForwardVector, GameObject.Find("Pen").transform.forward);


                int i = 0;
                Quaternion rot = GameObject.Find("Pen").GetComponent<Transform>().rotation;
                Vector3 vPenPos = GameObject.Find("Pen").GetComponent<Transform>().position;
                Transform tr = transform;

                for (; i < m_lProjectedPos.Count; ++i)
                {
                    m_vConvertPos = m_lProjectedPos[i] - vPenPos;
                    tr.position = m_lProjectedPos[i] - vPenPos;

                    //transform.RotateAround(m_lProjectedPos[i], GameObject.Find("Pen").transform.up, angle);
                    //transform.RotateAround(m_vConvertPos, GameObject.Find("Pen").transform.up, angle);
                    tr.RotateAround(Vector3.zero, Vector3.up, angle);

                    m_vConvertPos += vPenPos;
                    tr.position += vPenPos;

                    //m_vConvertPos.x = Mathf.Cos(dot) * m_vConvertPos.x - Mathf.Sin(dot) * m_vConvertPos.z;
                    //m_vConvertPos.z = Mathf.Sin(dot) * m_vConvertPos.x + Mathf.Cos(dot) * m_vConvertPos.z;


                    lineRenderer.SetPosition(i, tr.position);
                    //transform.LookAt(m_lProjectedPos[i] + rot * Vector3.back, rot * Vector3.down);
                }
                //lineRenderer.SetPosition(i, rot * m_lProjectedPos[i - 1]);
                lineRenderer.SetPosition(i, tr.position);
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }

    public void SetPosList(List<Vector3> list)
    {
        m_lProjectedPos = new List<Vector3>(list);
    }
}
