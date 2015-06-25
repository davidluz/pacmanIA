using UnityEngine;
using System.Collections;

public class Tipo : MonoBehaviour {
	
	public enum Elemento
	{
		Objetos,
		Personagem,
		Inimigos,
		WayPoints,
		Pilula,
		Moedas
	}
	
	public Elemento tipo;
	
}
