//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Tween the object's position.
/// </summary>

[AddComponentMenu("NGUI/Tween/CirclePosition")]
public class TweenCirclePosition : UITweener
{
	public Vector3 from;
	public Vector3 to;

	Transform mTrans;

	public Transform cachedTransform { get { if (mTrans == null) mTrans = transform; return mTrans; } }
	public Vector3 position { get { return cachedTransform.localPosition; } set { cachedTransform.localPosition = value; } }

    override protected void OnUpdate(float factor) 
    {
        cachedTransform.localPosition = new Vector3(from.x * (1f - factor) + to.x * factor, Mathf.Sin(factor * 180.0f * Mathf.Deg2Rad)*200 +(factor*to.y), from.z * (1f - factor) + to.z * factor);
    }

	static public TweenPosition Begin (GameObject go, float duration, Vector3 pos)
	{
		TweenPosition comp = UITweener.Begin<TweenPosition>(go, duration);
		comp.from = comp.position;
		comp.to = pos;
		return comp;
	}
}