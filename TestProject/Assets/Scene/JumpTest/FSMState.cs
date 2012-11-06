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

	// Use this for initialization��
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
        //�� ������Ʈ�� �ϴ� �����س��´�.
        int iOutPutID = m_iStateID;
        for (int i = 0; i < m_usNumberOfTransistions; ++i )
        {
            if ((int)m_OutPutState[i] == 0)
                break;

            //Ư�� Ʈ�������� ��� ������Ʈ�� �������� ���� ID�� ��´�
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
        //���� ��� �ִ°� �ִٸ� ��� �ִ� ���� ���� �Ѵ�.
        //���� �� �������� ���̻� �߰��� ���� �ʴ´�.
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
