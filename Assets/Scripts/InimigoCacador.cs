using UnityEngine;
using System.Collections;

public class InimigoCacador : MonoBehaviour {

	public Transform Alvo;
	public Transform[] WayPoints;
	public Transform AlvoAtualProx;
	public Transform AlvoAtualPassado;
	public NavMeshAgent AuxPosicaoNavMesh;
	public bool seguirPlayer = false;
	public bool CacadorFuturo = true;
	public bool ativo = false;
	public float TempoLimite = 10.0f;
	public float Timer = 0.0f;
	public float TimerAdd = 0.0f;
	public int destino = 0;

	// Use this for initialization
	void Start () {
		AlvoAtualProx.position = Alvo.position;
		AlvoAtualPassado.position = Alvo.position;
	}
	
	// Update is called once per frame
	void Update () {
		Timer += Time.deltaTime;
		TimerAdd += Time.deltaTime;
		if (Timer >= TempoLimite) {
			ativo = true;
		}
		if (ativo == true) {

			if(GameMaster.Fugir==false){
				if(CacadorFuturo==true){
					AlvoAtualProx.position = WayPoints[GameMaster.PosPlayerPro].position;
					if(seguirPlayer==false){
						AuxPosicaoNavMesh.destination = AlvoAtualProx.position;
					}else{
						AuxPosicaoNavMesh.destination = Alvo.position;
					}
				}else{
					AlvoAtualPassado.position = WayPoints[GameMaster.PosPlayerPas].position;
					if(seguirPlayer==false){
						AuxPosicaoNavMesh.destination = AlvoAtualPassado.position;
					}else{
						AuxPosicaoNavMesh.destination = Alvo.position;
					}
				}


			}else{

				if(TimerAdd>=1){
					TimerAdd = 0.0f;
					int aux = destino;
					while(aux==destino){
						destino = Random.Range(0,8);
					}
				}
				AuxPosicaoNavMesh.destination = Alvo.position+GameMaster.deslocamentos[destino];

			}//fim else fugir
		}//fim iff vivo
	
	}//update


	void OnTriggerEnter(Collider collision){
		
		
			Tipo tipoDoElemento = collision.gameObject.GetComponent<Tipo> ();
			WayPoints waypoint = collision.gameObject.GetComponent<WayPoints> ();
		
			if (tipoDoElemento != null) {
			
					if (tipoDoElemento.tipo == Tipo.Elemento.WayPoints) {
						if(CacadorFuturo==true){
							if(waypoint.Valor==GameMaster.PosPlayerPro){
								seguirPlayer = true;
							}else if(waypoint.Valor!=GameMaster.PosPlayer){
						
								seguirPlayer = false;
							}
						}else{
							if(waypoint.Valor==GameMaster.PosPlayerPas){
								seguirPlayer = true;
							}else if(waypoint.Valor!=GameMaster.PosPlayer){
						
								seguirPlayer = false;
							}
						}
						
					}
			}
	}//trigger

}
