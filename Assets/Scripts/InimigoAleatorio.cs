using UnityEngine;
using System.Collections;

public class InimigoAleatorio : MonoBehaviour
{

    public float velocidade;
    public NavMeshAgent AuxPosicaoNavMesh;


    // Update is called once per frame
    void Update()
    {

        //if (GameMaster.Vivo == true)
        //{
        //    Vector3 auxiliar = new Vector3(
        //        (UnityEngine.Random.Range(-1f, 1f) * velocidade) + gameObject.transform.position.x,
        //        0,
        //        (UnityEngine.Random.Range(-1f, 1f) * velocidade) + gameObject.transform.position.z);

        //    AuxPosicaoNavMesh.destination = auxiliar;
        //}
    }

    void Start()
    {
        GameObject wayPointDestino = GameObject.Find("1");
        if (wayPointDestino != null)
            AuxPosicaoNavMesh.destination = wayPointDestino.transform.position;
    }

    void OnTriggerEnter(Collider collision)
    {
        Tipo tipoDoElemento = collision.gameObject.GetComponent<Tipo>();
        WayPoints waypoint = collision.gameObject.GetComponent<WayPoints>();

        if (tipoDoElemento != null)
        {
            int proximoWayPoint = UnityEngine.Random.Range(1, 62);
   //         Debug.Log("Colidiu com waypoint " + waypoint+ " e irá para "+proximoWayPoint);
            GameObject wayPointDestino = GameObject.Find(proximoWayPoint.ToString());
            if (wayPointDestino != null && wayPointDestino != waypoint)
            {
                AuxPosicaoNavMesh.destination = wayPointDestino.transform.position;
    //            Debug.Log("Destino " + AuxPosicaoNavMesh.destination);
            }

            //print(waypoint.Valor);

        }

    }//trigger

}