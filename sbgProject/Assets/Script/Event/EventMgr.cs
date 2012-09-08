using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EventMgr : MonoBehaviour 
{
	
	//-------------------------------------------------------------------
    /* static */
    //-------------------------------------------------------------------
	private static EventMgr ms_Instance = null;	
		
	public static EventMgr Instance
	{
		get
		{
			return ms_Instance;
		}
	}
	
	
	//-------------------------------------------------------------------
    /* Private Variable */
    //-------------------------------------------------------------------
	private List<EventBase> m_EventList = new List<EventBase>();
	
	
	//-------------------------------------------------------------------
    /* Public Function */
    //-------------------------------------------------------------------
	
	public void AddEvent( EventBase _event )
	{
		if( null == _event )
		{
			Debug.LogError("EventMgr::AddEvent() [ null == _event ]");
			return;
		}
		
		m_EventList.Add( _event );
	}
	
	
	public void Clear()
	{
		m_EventList.Clear();
	}
	
	
	//-------------------------------------------------------------------
    /* MonoBehaviour Function */
    //-------------------------------------------------------------------
	
	void Awake()
	{
		ms_Instance = this;
		DontDestroyOnLoad(gameObject);	
	}
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

        if (true == SceneMgr.Instance.isPause)
            return;
		
		int i = 0;
		while( i < m_EventList.Count)
		{
			m_EventList[i].Update();				
			if( true == m_EventList[i].IsNeedDelete )
			{
				m_EventList.RemoveAt(i);
				continue;
			}
			
			++i;
		}		
	}
}
