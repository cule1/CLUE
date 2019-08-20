using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoBoard : MonoBehaviour
{

    [SerializeField]
    private GameObject m_TargetGameobject;
    public bool m_bIsRender { get; set; }
    private Quaternion m_quaternion;
    public Vector3 m_preForwardVector { get; set; }
    public Matrix4x4 m_preForwardMat { get; set; }

    // Use this for initialization
    void Start()
    {
        transform.position = m_TargetGameobject.transform.position + m_TargetGameobject.transform.forward * 0.8f;
        transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), 270.0f);
        m_quaternion = Quaternion.identity;
        m_preForwardVector = new Vector3(0.0f, 0.0f, 0.0f);
        m_preForwardMat = Matrix4x4.identity;
    }

    // Update is called once per frame
    void Update()
    {
        // 화면 고정

        //transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), 90.0f);
        //Vector3.Dot(new Vector3(0.0f, 0.0f, 0.0f), m_TargetGameobject.transform.forward);
        m_quaternion = new Quaternion(m_TargetGameobject.transform.eulerAngles.x, m_TargetGameobject.transform.eulerAngles.y, m_TargetGameobject.transform.eulerAngles.z, 1.0f);

        // While m_bIsDraw is true 
        if (!GameObject.Find("hand_right").GetComponent<DrawLine>().m_bIsDraw)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            m_bIsRender = false;
        }
        else if (GameObject.Find("hand_right").GetComponent<DrawLine>().m_bIsDraw)
        {
            if (!m_bIsRender)
            {
                transform.position = m_TargetGameobject.transform.position + m_TargetGameobject.transform.forward * 0.8f;
                transform.LookAt(transform.position + m_TargetGameobject.transform.rotation * Vector3.back, m_TargetGameobject.transform.rotation * Vector3.down);
                m_preForwardVector = m_TargetGameobject.transform.forward;
                //m_preForwardMat = m_TargetGameobject.GetComponent<Matrix4x4>();
                //m_quaternion = new Quaternion(m_TargetGameobject.transform.eulerAngles.x, m_TargetGameobject.transform.eulerAngles.y, m_TargetGameobject.transform.eulerAngles.z, 1.0f);
            }

            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            m_bIsRender = true;
        }

        //if (m_bIsRender)
        //{
        //    LineRenderer l = GameObject.Find("hand_right").GetComponent<LineRenderer>();

        //}
    }

    public Quaternion GetTargetQuaternion()
    {
        return m_quaternion;
    }

    /*
    public bool m_bIsRender { get; set; }
    public Vector3 m_hitPos { get; set; }

    [SerializeField]
    private GameObject m_TargetGameobject;
    private GameObject m_HandR;
    private List<Vector3> m_lProjectedPos = new List<Vector3>();
    private List<DrawnLines> m_lLine = new List<DrawnLines>();

    // Use this for initialization
    void Start()
    {
        transform.position = m_TargetGameobject.transform.position + m_TargetGameobject.transform.forward * 0.8f;
        transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), 270.0f);

        m_HandR = GameObject.Find("hand_right");
    }

    // Update is called once per frame
    void Update()
    {

        // While m_bIsDraw is true 
        if (!m_HandR.GetComponent<DrawLine>().m_bIsDraw)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            m_bIsRender = false;
        }
        else if (m_HandR.GetComponent<DrawLine>().m_bIsDraw)
        {
            if (!m_bIsRender)
            {
                transform.position = m_TargetGameobject.transform.position + m_TargetGameobject.transform.forward * 0.8f;
                transform.LookAt(transform.position + m_TargetGameobject.transform.rotation * Vector3.back, m_TargetGameobject.transform.rotation * Vector3.down);
            }

            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            m_bIsRender = true;
        }

        if (m_bIsRender)
        {
            if (m_HandR.GetComponent<DrawLine>().m_bIsDrawing)
            {
                m_lProjectedPos.Add(m_hitPos);
                m_lLine[m_lLine.Count - 1].SetPosList(m_lProjectedPos);
            }
            else if (!m_HandR.GetComponent<DrawLine>().m_bIsDrawing)
            {
                DrawnLines n = gameObject.AddComponent<DrawnLines>();
                n.Start();
                m_lLine.Add(n);
                m_lProjectedPos.Clear();
            }
        }
    }
    */
}
