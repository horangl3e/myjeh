using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FSMClass : MonoBehaviour {

    private Dictionary<int, FSMState> m_Map = new Dictionary<int, FSMState>();
    private int m_CurrentState;

    public FSMClass()
    {

    }

    public Dictionary<int,FSMState> FSMState
    {
        get { return m_Map; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetCurrentState(int iStateID)
    {
        m_CurrentState = iStateID;
    }

    public int GetCurrentState()
    {
        return m_CurrentState;
    }

    public void AddState( FSMState state )
    {
         if (m_Map.ContainsKey(state.GetID()))
             return;
         m_Map.Add(state.GetID(),state);
    }

    public FSMState GetState( int iStateID )
    {
        if (m_Map.ContainsKey(iStateID))
            return m_Map[iStateID];

        return null;
    }

    public void DeleteState(int iStateID )
    {
        if( m_Map.ContainsKey( iStateID ) )
            m_Map.Remove( iStateID );
    }

    public int StateTransition(int iInput)
    {
        if (m_CurrentState == 0)
            return m_CurrentState;

        FSMState FsmState = GetState(m_CurrentState);
        if ( null == FsmState )
        {
            m_CurrentState = 0;
            return m_CurrentState;
        }

        m_CurrentState = FsmState.GetOutPut(iInput);
        return m_CurrentState;
    }

}
