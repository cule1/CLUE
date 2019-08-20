using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawnLines : MonoBehaviour
{

    //private OVRInput.Controller m_controller;
    GameObject emptyGameObject;
    GameObject BoardGameObject;
    private List<Vector3> m_lProjectedPos = new List<Vector3>();
    private List<Vector3> m_ltestPos = new List<Vector3>();

    // Use this for initialization
    public void Start()
    {
        //m_controller = GetComponent<DrawLine>().GetController();
        emptyGameObject = new GameObject("line");

        LineRenderer lineRenderer = emptyGameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.003f;
        lineRenderer.endWidth = 0.003f;
        lineRenderer.numCapVertices = 1;

        BoardGameObject = GameObject.Find("WhiteBoard");
    }

    // Update is called once per frame
    public void Update()
    {
        //LineRenderer lineRenderer = GetComponent<DrawLine>().GetLineRenderer();

        LineRenderer lineRenderer = emptyGameObject.GetComponent<LineRenderer>();

        if (m_lProjectedPos != null)
        {
            if (BoardGameObject.GetComponent<MemoBoard>().m_bIsRender)
            {
                lineRenderer.enabled = true;
                lineRenderer.positionCount = m_lProjectedPos.Count + 1;

                float dot = Vector3.Dot(BoardGameObject.GetComponent<MemoBoard>().m_preForwardVector, GameObject.Find("CenterEyeAnchor").transform.forward);
                Vector3 cross = Vector3.Cross(BoardGameObject.GetComponent<MemoBoard>().m_preForwardVector, GameObject.Find("CenterEyeAnchor").transform.forward);
                float angle = 0.0f;

                if (dot < 1.0f)
                {
                    angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

                    //if (cross.z < 0)
                    //{
                    //    angle = transform;
                    //}

                }

                int i = 0;

                for (; i < m_lProjectedPos.Count; ++i)
                {
                    //m_ltestPos.Add(BoardGameObject.GetComponent<MemoBoard>().GetTargetQuaternion() * m_lProjectedPos[i]);
                    //m_ltestPos.Add(transform.RotateAround(GameObject.Find("CenterEyeAnchor").transform.position, BoardGameObject.GetComponent<MemoBoard>().GetTargetQuaternion().eulerAngles));
                    Vector3 newVec = m_lProjectedPos[i];
                    GameObject emptyGaamObject = new GameObject();
                    emptyGaamObject.transform.position = newVec;
                    emptyGaamObject.transform.RotateAround(newVec, cross, angle);
                    //newVec = BoardGameObject.GetComponent<MemoBoard>().m_preForwardMat * newVec;
                    m_ltestPos.Add(newVec);
                    lineRenderer.SetPosition(i, emptyGaamObject.transform.position/*BoardGameObject.GetComponent<MemoBoard>().GetTargetQuaternion() * m_lProjectedPos[i]*/);
                }

                //lineRenderer.SetPosition(i, BoardGameObject.GetComponent<MemoBoard>().GetTargetQuaternion() * m_lProjectedPos[i - 1]);

            }
            else
            {
                m_ltestPos.Clear();
                lineRenderer.enabled = false;
            }
        }
    }

    public void SetPosList(List<Vector3> list)
    {
        m_lProjectedPos = new List<Vector3>(list);
    }
}
