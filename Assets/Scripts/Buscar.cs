using UnityEngine;
using System.Collections;

public class Buscar : MonoBehaviour {

	public Transform Alvo;
	public NavMeshAgent AuxPosicaoNavMesh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		AuxPosicaoNavMesh.destination = Alvo.position;

	}
}
