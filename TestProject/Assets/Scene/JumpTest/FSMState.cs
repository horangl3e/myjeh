using UnityEngine;
using System.Collections;

public class FSMState : MonoBehaviour {

    private int m_iStateID;
    private int m_usNumberOfTransistions;
    private ArrayList m_InputList = new ArrayList();
    private ArrayList m_OutPutState = new ArrayList();

    public void Initialize( int iStateID, int Transitions )
    {
        if (Transitions < 1)
            m_usNumberOfTransistions = 1;
        else 
            m_usNumberOfTransistions = Transitions;

        m_iStateID = iStateID;

        for (int i = 0; i < m_usNumberOfTransistions; i++)
        {
            m_InputList.Add(0);
            m_OutPutState.Add(0);
        }
    }

	// Use this for initializationㅑ
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetID()
    {
        return m_iStateID;
    }

    public int GetOutPut( int iInput )
    {
        //내 스테이트를 일단 지정해놓는다.
        int iOutPutID = m_iStateID;
        for (int i = 0; i < m_usNumberOfTransistions; ++i )
        {
            if ((int)m_OutPutState[i] == 0)
                break;

            //특정 트랜지션이 어느 스테이트로 가는지에 대한 ID를 얻는다
            if (iInput == (int)m_InputList[i])
            {
                iOutPutID = (int)m_OutPutState[i];
                break;
            }
        }
        return iOutPutID;
    }

    public void AddTransition(int iInput, int iOutputID)
    {
        //값이 비어 있는게 있다면 비어 있는 곳에 세팅 한다.
        //값이 다 차있으면 더이상 추가를 하지 않는다.
        int i = 0;
        for (; i < m_usNumberOfTransistions; ++i)
        {
            if ((int)m_OutPutState[i] == 0)
                break;
        }

        if (i < m_usNumberOfTransistions)
        {
            m_OutPutState[i] = iOutputID;
            m_InputList[i] = iInput;
        }
    }

    public void DeleteTransition(int iOutputID)
    {
        for (int i = 0; i < m_usNumberOfTransistions; ++i )
        {
           // if( m_OutPutState[i] == iOutputID )

        }
    }
}
