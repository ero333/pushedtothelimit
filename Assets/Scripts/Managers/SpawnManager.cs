using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject agujeroNegro;
    public List<GameObject> planetas;
    [Header("0 = Norte , 1 = Sur , 2 = Este , 3 = Oeste")]
    public List<Transform> spawnpoints;
    public List<Transform> spawnPlayer; 
    Vector2 posicionAgujeroNegro;
    Vector2 ultimaPosicionN;
    Vector2 ultimaPosicionS;
    Vector2 ultimaPosicionE;
    Vector2 ultimaPosicionO;
    public float distanciaEntreSpawns;
    public float tiempoEntreSpawns;
    public float desplazamientoX;
    public float desplazamientoY;
    public float correcionSpawnAgujeroNegro;

    private void Start(){
        // SpawnAgujeroNegro();
        // ActivarJugadores();
        GameManager.instance.rondaEnCurso = true;
        AcomodarJugadores();
        InvokeRepeating("SpawnPlaneta", tiempoEntreSpawns, tiempoEntreSpawns);   
    }

    private void OnDestroy(){
        GameManager.instance.rondaEnCurso = false;
        for (int i = 0; i < GameManager.instance.jugadores.Length; i++){
            Destroy(GameManager.instance.jugadores[i]);
        }
        GameManager.instance.activados = false;
    }

    /*
    void SpawnAgujeroNegro(){
        int lateral = Random.Range(0, 100);
        if (lateral >=0 && lateral <= 25){
            float x = Random.Range(-desplazamientoX, desplazamientoX);
            Vector3 posicion = new Vector3(x, desplazamientoY - correcionSpawnAgujeroNegro);
            GameObject aN = Instantiate(agujeroNegro,spawnpoints[0].position, spawnpoints[0].rotation);
            aN.transform.position = posicion;
			aN.transform.Rotate (-90, 0, 0);
            ultimaPosicionN = posicion;
        }
        if (lateral >= 26 && lateral <= 50){
            float x = Random.Range(-desplazamientoX, desplazamientoX);
            Vector3 posicion = new Vector3(x, -desplazamientoY + correcionSpawnAgujeroNegro);
            GameObject aN = Instantiate(agujeroNegro, spawnpoints[1].position, spawnpoints[1].rotation);
            aN.transform.position = posicion;
			aN.transform.Rotate (-90, 0, 0);
            ultimaPosicionS = posicion;
        }
        if (lateral >= 51 && lateral <= 75){
            float y = Random.Range(-desplazamientoY, desplazamientoY);
            Vector3 posicion = new Vector3(desplazamientoX - correcionSpawnAgujeroNegro, y);
            GameObject aN = Instantiate(agujeroNegro, spawnpoints[2].position, spawnpoints[2].rotation);
            aN.transform.position = posicion;
			aN.transform.Rotate (-90, 0, 0);
            ultimaPosicionE = posicion;
        }
        if (lateral >= 76 && lateral <= 100){
            float y = Random.Range(-desplazamientoY, desplazamientoY);
            Vector3 posicion = new Vector3(-desplazamientoX + correcionSpawnAgujeroNegro, y);
            GameObject aN = Instantiate(agujeroNegro, spawnpoints[3].position, spawnpoints[3].rotation);
            aN.transform.position = posicion;
			aN.transform.Rotate (-90, 0, 0);
            ultimaPosicionO = posicion;
        }
    }*/
    /*
    void SpawnPlaneta(){
        int lateral = Random.Range(0, 100);
        if (lateral >= 0 && lateral <= 25){
            int planeta = Random.Range(0,planetas.Count);
            float x = Random.Range(-desplazamientoX, desplazamientoX);
            Vector3 posicion = new Vector3(x, desplazamientoY);
            GameObject aN = Instantiate(planetas[planeta], spawnpoints[0].position, spawnpoints[0].rotation);
            if (posicion.x > ultimaPosicionN.x + distanciaEntreSpawns || posicion.x < ultimaPosicionN.x - distanciaEntreSpawns){
                aN.transform.position = posicion;
                ultimaPosicionN = posicion;
            }else{
                SpawnPlaneta();
            }
        }
        if (lateral >= 26 && lateral <= 50){
            int planeta = Random.Range(0, planetas.Count);
            float x = Random.Range(-desplazamientoX, desplazamientoX);
            Vector3 posicion = new Vector3(x, -desplazamientoY);
            GameObject aN = Instantiate(planetas[planeta], spawnpoints[1].position, spawnpoints[1].rotation);
            if (posicion.x > ultimaPosicionS.x + distanciaEntreSpawns || posicion.x < ultimaPosicionS.x - distanciaEntreSpawns){
                aN.transform.position = posicion;
                ultimaPosicionS = posicion;
            }else{
                SpawnPlaneta();
            }
        }
        if (lateral >= 51 && lateral <= 75){
            int planeta = Random.Range(0, planetas.Count);
            float y = Random.Range(-desplazamientoY, desplazamientoY);
            Vector3 posicion = new Vector3(-desplazamientoX , y);
            GameObject aN = Instantiate(planetas[planeta], spawnpoints[2].position, spawnpoints[2].rotation);
            if (posicion.y > ultimaPosicionE.y + distanciaEntreSpawns || posicion.y < ultimaPosicionE.y - distanciaEntreSpawns){
                aN.transform.position = posicion;
                ultimaPosicionE = posicion;
            }else{
                SpawnPlaneta();
            }
        }
        if (lateral >= 76 && lateral <= 100){
            int planeta = Random.Range(0, planetas.Count);
            float y = Random.Range(-desplazamientoY, desplazamientoY);
            Vector3 posicion = new Vector3(desplazamientoX, y);
            GameObject aN = Instantiate(planetas[planeta], spawnpoints[3].position, spawnpoints[3].rotation);
            if (posicion.y > ultimaPosicionO.y + distanciaEntreSpawns || posicion.y < ultimaPosicionO.y - distanciaEntreSpawns){
                aN.transform.position = posicion;
                ultimaPosicionO = posicion;
            }else{
                SpawnPlaneta();
            }
        }
    }*/

    public void AcomodarJugadores(){
        GameManager.instance.jugador1.transform.Translate(spawnPlayer[0].position);
        GameManager.instance.jugador2.transform.Translate(spawnPlayer[1].position);
        GameManager.instance.jugador3.transform.Translate(spawnPlayer[2].position);
        GameManager.instance.jugador4.transform.Translate(spawnPlayer[3].position);
    }

    public void ActivarJugadores(){
        if(GameManager.instance.jugador1 == true){
            GameManager.instance.jugador1.SetActive(true);
        }
        if(GameManager.instance.jugador2 == true){
            GameManager.instance.jugador1.SetActive(true);
        }
        if(GameManager.instance.jugador3 == true){
            GameManager.instance.jugador1.SetActive(true);
        }
        if(GameManager.instance.jugador4 == true){
            GameManager.instance.jugador1.SetActive(true);
        }
    }
}
