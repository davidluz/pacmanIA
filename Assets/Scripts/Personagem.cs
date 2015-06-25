using UnityEngine;
using System.Collections;

public class Personagem : MonoBehaviour {

	public NavMeshAgent Inimigo1;
	public NavMeshAgent Inimigo2;
	public NavMeshAgent Inimigo3;
	public NavMeshAgent Inimigo4;
	public float velocidade; 
	public NavMeshAgent AuxPosicaoNavMesh;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {

		if (GameMaster.Vivo == true) {

            float deslocamentoEmX = Input.GetAxis ("Horizontal");
            float deslocamentoEmZ = Input.GetAxis ("Vertical");
			Vector3 auxiliar = new Vector3 ((deslocamentoEmX * velocidade)+gameObject.transform.position.x, 0, (deslocamentoEmZ * velocidade)+gameObject.transform.position.z);
			AuxPosicaoNavMesh.destination = auxiliar;

            if (deslocamentoEmX == 0)
                if (deslocamentoEmZ > 0)
                    GameMaster.direcaoDoPacMan = 0;
                else
                {
                    if (deslocamentoEmZ < 0)
                        GameMaster.direcaoDoPacMan = 4;
                }
                    //else
                    //    GameMaster.direcaoDoPacMan = 9;  /// parado
            else
                if (deslocamentoEmX > 0)
                    if (deslocamentoEmZ > 0)
                        GameMaster.direcaoDoPacMan = 1;
                    else
                        if (deslocamentoEmZ == 0)
                            GameMaster.direcaoDoPacMan = 2;
                        else
                            GameMaster.direcaoDoPacMan = 3;
                else
                    if (deslocamentoEmZ < 0)
                        GameMaster.direcaoDoPacMan = 5;
                    else
                        if (deslocamentoEmZ == 0)
                            GameMaster.direcaoDoPacMan = 6;
                        else
                            GameMaster.direcaoDoPacMan = 7;

           // Debug.Log("Direção do pacMan =" + GameMaster.direcaoDoPacMan);
		}


	}


	void OnTriggerEnter(Collider collision){
		
		
		Tipo tipoDoElemento = collision.gameObject.GetComponent<Tipo>();
		WayPoints waypoint = collision.gameObject.GetComponent<WayPoints>();
		NumeroInimigo numerodoinimigo = collision.gameObject.GetComponent<NumeroInimigo>();

		if(tipoDoElemento != null){
			if(tipoDoElemento.tipo == Tipo.Elemento.Pilula){
				collision.gameObject.SetActive(false);
				GameMaster.Pontos = GameMaster.Pontos+1;
			}
			if(tipoDoElemento.tipo == Tipo.Elemento.Moedas){
				collision.gameObject.SetActive(false);
				GameMaster.Fugir = true;
				GameMaster.Pontos = GameMaster.Pontos+1;
			}
			if(tipoDoElemento.tipo == Tipo.Elemento.Inimigos){
				if(GameMaster.Fugir==false){
					GameMaster.Vivo = false;
				}else{

					if(numerodoinimigo.Numero==1){

						Inimigo1.Warp(new Vector3(10,1,11));
					

					}else if(numerodoinimigo.Numero==2){
						Inimigo2.Warp(new Vector3(10,1,11));

					}else if(numerodoinimigo.Numero==3){
						Inimigo3.Warp(new Vector3(10,1,11)); 

					}else{

						Inimigo4.Warp(new Vector3(10,1,11)); 
					}
				
				}

			}
			if(tipoDoElemento.tipo == Tipo.Elemento.WayPoints){



				switch (waypoint.Valor){
					case 1:
						GameMaster.PosPlayer = 1;
						GameMaster.PosPlayerPas = 2;
						GameMaster.PosPlayerPro = 7;
						break;
					case 2:
						GameMaster.PosPlayer = 2;
						GameMaster.PosPlayerPas = 3;
						GameMaster.PosPlayerPro = 1;
						break;
					case 3:
						GameMaster.PosPlayer = 3;
						GameMaster.PosPlayerPas = 10;
						GameMaster.PosPlayerPro = 2;
						break;
					case 4:
						GameMaster.PosPlayer = 4;
						GameMaster.PosPlayerPas = 5;
						GameMaster.PosPlayerPro = 11;
						break;
					case 5:
						GameMaster.PosPlayer = 5;
						GameMaster.PosPlayerPas = 14;
						GameMaster.PosPlayerPro = 11;
						break;
					case 6:
						GameMaster.PosPlayer = 6;
						GameMaster.PosPlayerPas = 14;
						GameMaster.PosPlayerPro = 5;
						break;
					case 7:
						GameMaster.PosPlayer = 7;
						GameMaster.PosPlayerPas = 8;
						GameMaster.PosPlayerPro = 15;
						break;
					case 8:
						GameMaster.PosPlayer = 8;
						GameMaster.PosPlayerPas = 9;
						GameMaster.PosPlayerPro = 7;
						break;
					case 9:
						GameMaster.PosPlayer = 9;
						GameMaster.PosPlayerPas = 10;
						GameMaster.PosPlayerPro = 8;
						break;
					case 10:
						GameMaster.PosPlayer = 10;
						GameMaster.PosPlayerPas = 11;
						GameMaster.PosPlayerPro = 9;
						break;
					case 11:
						GameMaster.PosPlayer = 11;
						GameMaster.PosPlayerPas = 12;
						GameMaster.PosPlayerPro = 10;
						break;
					case 12:
						GameMaster.PosPlayer = 12;
						GameMaster.PosPlayerPas = 13;
						GameMaster.PosPlayerPro = 11;
						break;
					case 13:
						GameMaster.PosPlayer = 13;
						GameMaster.PosPlayerPas = 14;
						GameMaster.PosPlayerPro = 12;
						break;
					case 14:
						GameMaster.PosPlayer = 14;
						GameMaster.PosPlayerPas = 22;
						GameMaster.PosPlayerPro = 13;
						break;
					case 15:
						GameMaster.PosPlayer = 15;
						GameMaster.PosPlayerPas = 7;
						GameMaster.PosPlayerPro = 16;
						break;
					case 16:
						GameMaster.PosPlayer = 16;
						GameMaster.PosPlayerPas = 15;
						GameMaster.PosPlayerPro = 27;
						break;
					case 17:
						GameMaster.PosPlayer = 17;
						GameMaster.PosPlayerPas = 9;
						GameMaster.PosPlayerPro = 18;
						break;
					case 18:
						GameMaster.PosPlayer = 18;
						GameMaster.PosPlayerPas = 17;
						GameMaster.PosPlayerPro = 24;
						break;
					case 19:
						GameMaster.PosPlayer = 19;
						GameMaster.PosPlayerPas = 20;
						GameMaster.PosPlayerPro = 25;
						break;
					case 20:
						GameMaster.PosPlayer = 20;
						GameMaster.PosPlayerPas = 12;
						GameMaster.PosPlayerPro = 19;
						break;
					case 21:
						GameMaster.PosPlayer = 21;
						GameMaster.PosPlayerPas = 13;
						GameMaster.PosPlayerPro = 30;
						break;
					case 22:
						GameMaster.PosPlayer = 22;
						GameMaster.PosPlayerPas = 14;
						GameMaster.PosPlayerPro = 21;
						break;
					case 23:
						GameMaster.PosPlayer = 23;
						GameMaster.PosPlayerPas = 24;
						GameMaster.PosPlayerPro = 28;
						break;
					case 24:
						GameMaster.PosPlayer = 24;
						GameMaster.PosPlayerPas = 25;
						GameMaster.PosPlayerPro = 23;
						break;
					case 25:
						GameMaster.PosPlayer = 25;
						GameMaster.PosPlayerPas = 26;
						GameMaster.PosPlayerPro = 24;
						break;
					case 26:
						GameMaster.PosPlayer = 26;
						GameMaster.PosPlayerPas = 29;
						GameMaster.PosPlayerPro = 25;
						break;
					case 27:
						GameMaster.PosPlayer = 27;
						GameMaster.PosPlayerPas = 28;
						GameMaster.PosPlayerPro = 34;
						break;
					case 28:
						GameMaster.PosPlayer = 28;
						GameMaster.PosPlayerPas = 23;
						GameMaster.PosPlayerPro = 31;
						break;
					case 29:
						GameMaster.PosPlayer = 29;
						GameMaster.PosPlayerPas = 26;
						GameMaster.PosPlayerPro = 32;
						break;
					case 30:
						GameMaster.PosPlayer = 30;
						GameMaster.PosPlayerPas = 29;
						GameMaster.PosPlayerPro = 39;
						break;
					case 31:
						GameMaster.PosPlayer = 31;
						GameMaster.PosPlayerPas = 28;
						GameMaster.PosPlayerPro = 35;
						break;
					case 32:
						GameMaster.PosPlayer = 32;
						GameMaster.PosPlayerPas = 29;
						GameMaster.PosPlayerPro = 38;
						break;
					case 33:
						GameMaster.PosPlayer = 33;
						GameMaster.PosPlayerPas = 34;
						GameMaster.PosPlayerPro = 41;
						break;
					case 34:
						GameMaster.PosPlayer = 34;
						GameMaster.PosPlayerPas = 35;
						GameMaster.PosPlayerPro = 33;
						break;
					case 35:
						GameMaster.PosPlayer = 35;
						GameMaster.PosPlayerPas = 36;
						GameMaster.PosPlayerPro = 34;
						break;
					case 36:
						GameMaster.PosPlayer = 36;
						GameMaster.PosPlayerPas = 44;
						GameMaster.PosPlayerPro = 35;
						break;
					case 37:
						GameMaster.PosPlayer = 37;
						GameMaster.PosPlayerPas = 38;
						GameMaster.PosPlayerPro = 45;
						break;
					case 38:
						GameMaster.PosPlayer = 38;
						GameMaster.PosPlayerPas = 39;
						GameMaster.PosPlayerPro = 37;
						break;
					case 39:
						GameMaster.PosPlayer = 39;
						GameMaster.PosPlayerPas = 47;
						GameMaster.PosPlayerPro = 38;
						break;
					case 40:
						GameMaster.PosPlayer = 40;
						GameMaster.PosPlayerPas = 48;
						GameMaster.PosPlayerPro = 39;
						break;
					case 41:
						GameMaster.PosPlayer = 41;
						GameMaster.PosPlayerPas = 33;
						GameMaster.PosPlayerPro = 50;
						break;
					case 42:
						GameMaster.PosPlayer = 42;
						GameMaster.PosPlayerPas = 43;
						GameMaster.PosPlayerPro = 51;
						break;
					case 43:
						GameMaster.PosPlayer = 43;
						GameMaster.PosPlayerPas = 44;
						GameMaster.PosPlayerPro = 42;
						break;
					case 44:
						GameMaster.PosPlayer = 44;
						GameMaster.PosPlayerPas = 45;
						GameMaster.PosPlayerPro = 43;
						break;
					case 45:
						GameMaster.PosPlayer = 45;
						GameMaster.PosPlayerPas = 46;
						GameMaster.PosPlayerPro = 44;
						break;
					case 46:
						GameMaster.PosPlayer = 46;
						GameMaster.PosPlayerPas = 47;
						GameMaster.PosPlayerPro = 45;
						break;
					case 47:
						GameMaster.PosPlayer = 47;
						GameMaster.PosPlayerPas = 39;
						GameMaster.PosPlayerPro = 46;
						break;
					case 48:
						GameMaster.PosPlayer = 48;
						GameMaster.PosPlayerPas = 57;
						GameMaster.PosPlayerPro = 40;
						break;
					case 49:
						GameMaster.PosPlayer = 49;
						GameMaster.PosPlayerPas = 50;
						GameMaster.PosPlayerPro = 59;
						break;
					case 50:
						GameMaster.PosPlayer = 50;
						GameMaster.PosPlayerPas = 51;
						GameMaster.PosPlayerPro = 49;
						break;
					case 51:
						GameMaster.PosPlayer = 51;
						GameMaster.PosPlayerPas = 42;
						GameMaster.PosPlayerPro = 50;
						break;
					case 52:
						GameMaster.PosPlayer = 52;
						GameMaster.PosPlayerPas = 43;
						GameMaster.PosPlayerPro = 53;
						break;
					case 53:
						GameMaster.PosPlayer = 53;
						GameMaster.PosPlayerPas = 52;
						GameMaster.PosPlayerPro = 60;
						break;
					case 54:
						GameMaster.PosPlayer = 54;
						GameMaster.PosPlayerPas = 55;
						GameMaster.PosPlayerPro = 61;
						break;
					case 55:
						GameMaster.PosPlayer = 55;
						GameMaster.PosPlayerPas = 46;
						GameMaster.PosPlayerPro = 54;
						break;
					case 56:
						GameMaster.PosPlayer = 56;
						GameMaster.PosPlayerPas = 47;
						GameMaster.PosPlayerPro = 57;
						break;
					case 57:
						GameMaster.PosPlayer = 57;
						GameMaster.PosPlayerPas = 56;
						GameMaster.PosPlayerPro = 58;
						break;
					case 58:
						GameMaster.PosPlayer = 58;
						GameMaster.PosPlayerPas = 57;
						GameMaster.PosPlayerPro = 62;
						break;
					case 59:
						GameMaster.PosPlayer = 59;
						GameMaster.PosPlayerPas = 49;
						GameMaster.PosPlayerPro = 60;
						break;
					case 60:
						GameMaster.PosPlayer = 60;
						GameMaster.PosPlayerPas = 59;
						GameMaster.PosPlayerPro = 61;
						break;
					case 61:
						GameMaster.PosPlayer = 61;
						GameMaster.PosPlayerPas = 60;
						GameMaster.PosPlayerPro = 62;
						break;
					case 62:
						GameMaster.PosPlayer = 62;
						GameMaster.PosPlayerPas = 58;
						GameMaster.PosPlayerPro = 61;
						break;
				}//fim case
				
				
				//print(waypoint.Valor);
				
			}
			
		}
		
	}//trigger
	
}
