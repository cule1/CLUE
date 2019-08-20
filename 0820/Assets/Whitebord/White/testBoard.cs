using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBoard : MonoBehaviour {

    private GameObject m_TargetGameobject;
    public bool m_bIsRender { get; set; }

    private List<Vector3> m_lProjectedPos = new List<Vector3>();
    private List<DrawnLines> m_lLine = new List<DrawnLines>();

    public Vector3 m_HitPos { get; set; }
    private float m_delay = 0.0f;
    private bool m_bIsNewLine = false;

    private testLine testline = null;

    public Vector3 m_preForwardVector { get; set; }

    // Use this for initialization
    void Start () {
        m_TargetGameobject = GameObject.Find("Pen");
        transform.position = m_TargetGameobject.transform.position + m_TargetGameobject.transform.forward * 0.8f;
        transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), 270.0f);
        m_preForwardVector = new Vector3(0.0f, 0.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Pen").GetComponent<testDrawLine>().m_bIsDraw)
        {
            if (!m_bIsRender)
            {
                transform.position = m_TargetGameobject.transform.position + m_TargetGameobject.transform.forward * 0.8f;
                transform.LookAt(transform.position + m_TargetGameobject.transform.rotation * Vector3.back, m_TargetGameobject.transform.rotation * Vector3.down);
                //m_preForwardVector = m_TargetGameobject.transform.forward;
                m_preForwardVector = transform.forward;
            }

            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            m_bIsRender = true;

            if (GameObject.Find("Pen").GetComponent<testDrawLine>().m_bIsDrawing)
            {
                //if (m_lLine.Count == 0)
                if(!m_bIsNewLine)
                {
                    //DrawnLines n = gameObject.AddComponent<DrawnLines>();
                    //n.Start();
                    //m_lLine.Add(n);
                    m_bIsNewLine = true;
                    GameObject line = Instantiate(new GameObject(), transform);
                    line.transform.parent = transform;
                    line.transform.localPosition = Vector3.zero;
                    line.transform.localScale = Vector3.one;
                    testline = line.AddComponent<testLine>();
                }
                
                m_delay += Time.deltaTime;

                if (m_delay >= 0.008f)
                {
                    m_delay = 0.0f;
                    m_lProjectedPos.Add(m_HitPos);
                    //m_lLine[m_lLine.Count - 1].SetPosList(m_lProjectedPos);

                    testline.SetPosList(m_lProjectedPos);
                }
            }
            else
            {
                m_bIsNewLine = false;
                m_lProjectedPos.Clear();
                testline = null;
            }
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            m_bIsRender = false;
        }
    }
}
