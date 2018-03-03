using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour {

    public List<GameObject> planetas;
    public List<GameObject> elementoASpawnear;
    int planetaElegido;
    int poloelegido;
    int itemElegido;
    public float tiempoDeSpawn;

    private void Awake(){
        InvokeRepeating("LocacionElegida", tiempoDeSpawn,tiempoDeSpawn);
    }

    void LocacionElegida(){
        planetaElegido = Random.Range(0, planetas.Count);
        poloelegido = Random.Range(0, 3);
        itemElegido = Random.Range(0, elementoASpawnear.Count);
        InstanciarItem();
    }

    void InstanciarItem(){
        ListaPoscionItem polo = planetas[planetaElegido].GetComponentInChildren<ListaPoscionItem>();
        GameObject item = Instantiate(elementoASpawnear[itemElegido],polo.posiciones[poloelegido]);
        item.transform.position = polo.posiciones[poloelegido].position;
        item.transform.rotation = polo.posiciones[poloelegido].rotation;

    }
}
