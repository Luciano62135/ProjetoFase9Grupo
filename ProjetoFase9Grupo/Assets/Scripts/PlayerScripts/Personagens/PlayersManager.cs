using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayersManager : MonoBehaviour
{ 
    private Vector3 BotaoDeMovimento;
    private Vector3 moveVelocity;

    public bool estaAtacando = false;
	public bool ataqueEspecial = false;

    public float vidaAtual;
    public float vidaMaxima = 100;
    public BarraDeVida barraDeVida;

    public void Start()
    {
        
    }

    public void Update()
    {

		/*if (waitTime > 10 && hold == true)
		{
			if (foots > 10 && foots < 15)
			{
				if (Input.GetButton("Walk") == false)
					Instantiate(rightFoot, transform.position, transform.rotation);

				foots += 1 * RealSpeed;
			}
			else if (foots > 20)
			{
				if (Input.GetButton("Walk") == false)
					Instantiate(rightFoot, transform.position, transform.rotation);
				foots = 0;
			}
			else
			{
				foots += 1 * RealSpeed;
			}
			waitTime = 0;
		}*/
	}

}
