using UnityEngine;
using System.Collections;

public class InimigoFujao : MonoBehaviour
{

    public float velocidade;
    public NavMeshAgent AuxPosicaoNavMesh;
    public GameObject personagem;

    private Vector3[] wayPoints;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Destino do fujão = " + AuxPosicaoNavMesh.destination);
       
    }

    void Start()
    {
        // armazenamos todos os waypoints em um vetor de Vector3 para detectar aqueles que estão 
        // próximos da direçao oposta ao pacMan, já que este inimigo é o fujão
        //wayPoints =  new Vector3[63];

        GameObject wayPointDestino = null;
        //for (int i=1; i<63; i++)
        //{
        //        wayPointDestino = GameObject.Find(i.ToString());
        //        if (wayPointDestino != null)
        //            wayPoints[i] = wayPointDestino.transform.position;
        //}

        wayPointDestino = GameObject.Find("50");  // para dar um movimento inicial ao inimigo fujão
        if (wayPointDestino != null)
            AuxPosicaoNavMesh.destination = wayPointDestino.transform.position;
    }

    void OnTriggerEnter(Collider collision)
    {
        Tipo tipoDoElemento = collision.gameObject.GetComponent<Tipo>();
//        WayPoints waypoint = collision.gameObject.GetComponent<WayPoints>();

        if (tipoDoElemento != null)
        {

            int direcaoDoFantasma = (GameMaster.direcaoDoPacMan + 4) % 8;

            AuxPosicaoNavMesh.destination = personagem.transform.position + GameMaster.deslocamentos[direcaoDoFantasma];

            Debug.Log("PacMan indo na direção "+ GameMaster.direcaoDoPacMan + " e Fujão indo para direção " + direcaoDoFantasma + " na coordenada " + AuxPosicaoNavMesh.destination);


            //Vector3 direction = personagem.transform.position - transform.position; 
            //Vector3 startingPoint = transform.position;

            //int numeroWayPointDesejado = 62;
            //Ray ray = new Ray(startingPoint, direction);
            //float distance;
            //bool achou = false;
            //while (!achou) 
            //{
            //    int i = UnityEngine.Random.Range(1, 62);
            //    distance = Vector3.Cross(ray.direction, wayPoints[i] - ray.origin).magnitude;
            //    if (distance > 3 && distance < 6)
            //    {
            //        //Debug.Log("Waypoint "+i+" Distancia = " + distance);
            //        numeroWayPointDesejado = i;
            //        achou =true;
            //    }
            //}

            //GameObject wayPointDestino = GameObject.Find(numeroWayPointDesejado.ToString());
            //if (wayPointDestino != null )
            //{
            //    while (wayPointDestino == waypoint)
            //    {
            //        numeroWayPointDesejado = UnityEngine.Random.Range(0, 61) + 1;
            //        wayPointDestino = GameObject.Find(numeroWayPointDesejado.ToString());
            //        //Debug.Log("Sorteando outro waypoint " + numeroWayPointDesejado);
            //    }
            //    //Debug.Log("Colidiu com waypoint " + waypoint + " e irá para " + wayPointDestino);
            //    AuxPosicaoNavMesh.destination = wayPointDestino.transform.position;
            //    //Debug.Log("Destino " + AuxPosicaoNavMesh.destination);
            //}

            //print(waypoint.Valor);

        }

    }//trigger

}