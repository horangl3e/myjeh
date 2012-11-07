using UnityEngine;
using System.Collections;

public abstract class EntityMessage
{
    public enum eMSG
    {
        NONE,
        TARGET_MOVE,
        MOVE_STOP,
        MOVE_RESULT_STOP,
        ANIMATION_PLAY,
        ANIMATION_STOP,
        ANIMATION_RESULT_STOP,
    };

    protected eMSG m_eMsg = eMSG.NONE;

    public eMSG msg
    {
        get
        {
            return m_eMsg;
        }
    }
}

public class Msg_TargetMove : EntityMessage
{
    private Vector3 m_vec3TargetPos;

    public Vector3 targetPos
    {
        get
        {
            return m_vec3TargetPos;
        }
    }

    public Msg_TargetMove(Vector3 vec3TargetPos)
    {
        m_vec3TargetPos = vec3TargetPos;
        m_eMsg = EntityMessage.eMSG.TARGET_MOVE;
    }
}

public class Msg_MoveStop : EntityMessage
{
    public Msg_MoveStop()
    {
        m_eMsg = EntityMessage.eMSG.MOVE_STOP;
    }
}

public class Msg_AnimationPlay : EntityMessage
{
    private string m_strAnimationName;
    public string strAniName
    {
        get
        {
            return m_strAnimationName;
        }
    }

    public Msg_AnimationPlay(string strAnimationName)
    {
        m_eMsg = EntityMessage.eMSG.ANIMATION_PLAY;
        m_strAnimationName = strAnimationName;
    }
}

public class Msg_AnimationStop : EntityMessage
{
    public Msg_AnimationStop()
    {
        m_eMsg = EntityMessage.eMSG.ANIMATION_STOP;
    }
}

public class Msg_AnimationResultStop : EntityMessage
{
    private string m_strAnimationName;
    public string strAniName
    {
        get
        {
            return m_strAnimationName;
        }
    }

    public Msg_AnimationResultStop(string strAnimationName)
    {
        m_eMsg = EntityMessage.eMSG.ANIMATION_RESULT_STOP;
        m_strAnimationName = strAnimationName;
    }
}
