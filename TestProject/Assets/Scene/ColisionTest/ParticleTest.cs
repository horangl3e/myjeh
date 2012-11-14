using UnityEngine;
using System.Collections;

public class ParticleTest : MonoBehaviour {

    public GameObject ParticlePrefab;

	// Use this for initialization
	void Start () {

        if (!ParticlePrefab)
            Debug.LogError("PaticlePreFab Null Error");

        Debug.Log(ParticlePrefab.GetType());
        Object ParticleObject = (Object)ParticlePrefab;

        if (!ParticleObject)
            Debug.LogError("Error");

        GameObject ParticleGameObject = (GameObject)ParticleObject;

        if (!ParticleGameObject)
            Debug.LogError("Particle GameObject Null");

        GameObject go = (GameObject)GameObject.Instantiate(ParticleGameObject, Vector3.zero, Quaternion.identity);
        Destroy(go, 10);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
