using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseBullet : MonoBehaviour
{
    /*
     *  [X] Sprite
     *  [X] Algo que pasa cuando se dispara
     *  [X] Algo que pasa cuando colisiona con el personaje  
     *  [X] Algo que pasa cuanodo colisiona contra un planeta
     *  [ ] Partículas cuando se destruyen?
     */

	//[Berdy] Agrego el shooter para identificar el PlayerName que dispara y evitar un autodisparo (bug de disparo sobre planeta con Pusher Gun)
	//[Berdy] Tener en cuenta que solo sirve para comparar, si la comparacion no se hace se puede permitir el autodisparo (ej. Bala orbital)
	public abstract void OnShot(int shooter);

    protected virtual void ApplyEffectOnPlayer(GameObject player) { }
    protected virtual void ApplyEffectOnPlanet(GameObject planet) { }

    private void OnCollisionWithPlayer(GameObject player)
    {
        Debug.Log("Le pegaron un balazo al player", player);
        ApplyEffectOnPlayer(player);
        Destroy(gameObject);
    }

    private void OnCollisionWithPlanet(GameObject planet)
    {
        ApplyEffectOnPlanet(planet);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCollisionWithPlayer(collision.gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("Planet"))
        {
            OnCollisionWithPlanet(collision.gameObject);
            return;
        }
    }
}
