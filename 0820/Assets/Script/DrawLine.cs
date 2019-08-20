using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public bool m_bIsDraw { get; set; }
    bool m_bIsDrawing = false;

    [SerializeField]
    protected OVRInput.Controller m_controller;

    private List<Vector3> m_lProjectedPos = new List<Vector3>();
    private List<DrawnLines> m_lLine = new List<DrawnLines>();

    private RaycastHit hit;
    private float m_delay = 0.0f;


    // 화이트보드 페이지 넘기는 것 처럼 리스트로 더 만든다
    //private List<List<DrawnLines>> m_lLine = new List<List<DrawnLines>>();

    private void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
        lineRenderer.numCapVertices = 1;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);

        m_delay = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;

        if (OVRInput.GetDown(OVRInput.Button.Two) && !m_bIsDraw)
        {
            m_bIsDraw = true;
            lineRenderer.enabled = true;
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two) && m_bIsDraw)
        {
            m_bIsDraw = false;
            lineRenderer.enabled = false;
        }

        if (m_bIsDraw)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit)
                && hit.collider.gameObject.name == "WhiteBoard")
            {
                //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                //Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue, 5.0f);
                lineRenderer.startColor = Color.blue;
                lineRenderer.endColor = Color.blue;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);

                if (0.0f != OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, m_controller))
                {
                    if (!m_bIsDrawing)
                    {
                        DrawnLines n = gameObject.AddComponent<DrawnLines>();
                        n.Start();
                        m_lLine.Add(n);
                    }

                    m_bIsDrawing = true;
                    //GameObject.Find("WhiteBoard").GetComponent<MemoBoard>().m_hitPos = hit.point;

                    //StartCoroutine(InputPointPos());

                    m_delay += Time.deltaTime;

                    if (m_delay >= 0.007f)
                    {
                        m_delay = 0.0f;
                        m_lProjectedPos.Add(hit.point);
                        m_lLine[m_lLine.Count - 1].SetPosList(m_lProjectedPos);
                    }
                }
                else if (0.0f == OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, m_controller))
                {
                    m_bIsDrawing = false;
                    m_lProjectedPos.Clear();
                }
            }
            else
            {
                lineRenderer.startColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                lineRenderer.endColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }

            for (int i = 0; i < m_lLine.Count; ++i)
            {
                m_lLine[i].Update();
            }
        }
    }

    //private IEnumerator InputPointPos()
    //{

    //    m_lProjectedPos.Add(hit.point);
    //    m_lLine[m_lLine.Count - 1].SetPosList(m_lProjectedPos);
    //    yield return new WaitForSeconds(1.0f);
    //    StartCoroutine(InputPointPos());
    //}
}
