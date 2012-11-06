using UnityEngine;
using System.Collections;

public class FSMState : MonoBehaviour {

    private int m_iStateID;
    private int m_usNumberOfTransistions;

    public void Initialize( int iStateID, int Transitions )
    {
        if (Transitions < 1)
            m_usNumberOfTransistions = 1;
        else 
            m_usNumberOfTransistions = Transitions;

        m_iStateID = iStateID;
    }

	// Use this for initialization
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
        return m_iStateID;
    }
}
