using UnityEngine;
using System.Collections;

public enum eFSM_STATE
{
    NONE,
    IDEL
};


public enum eENTITY_TYPE
{
    NONE = 0,
    MONSTER
};

public abstract class Entity : MonoBehaviour
{
	public eFSM_STATE viewFsmState;
	public eENTITY_TYPE viewEntityType;
    private eENTITY_TYPE m_eEntityType;

    protected void SetType(eENTITY_TYPE _type)
    {
        m_eEntityType = _type;
        viewEntityType = _type;
    }

    public eENTITY_TYPE entityType
    {
        get
        {
            return m_eEntityType;
        }
    }

    public virtual void SetMsg()
    {

    }

    public virtual bool Create()
    {
        return true;
    }

    public abstract void SetState(eFSM_STATE state);
    public abstract eFSM_STATE GetFsmState();
}
