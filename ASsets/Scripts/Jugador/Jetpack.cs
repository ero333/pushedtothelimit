using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour {
    public bool activado;
    public float tiepoDeUso;
    float usado;
    JetpackFireController jetAnim;
    public float velocidad;
    Transform tran;
    public float Cooldown;
    float tiempoCD;
    bool enOrbita;

    private void Awake(){
        jetAnim = GetComponent<JetpackFireController>();
        tran = GetComponent<Transform>();
        InvokeRepeating("Timer", 0, 1);
        InvokeRepeating("TimerJet", 0, 1);
    }

    private void Update()
    {
        ControlJet();
    }
    //controla cuanto si el jetpack se puede volver a usar al haber pasado el cooldown y lo desactiva al haber cosumido su tiempo de uso
    void ControlJet(){
        if(activado == true){
            if(usado >= tiepoDeUso && enOrbita == false)
            {
                activado = false;
                jetAnim.OnJetpackDisabled();

            
            }
           /* if(enOrbita == true && tiempoCD >= Cooldown)
            {
                usado = 0; 
            }*/
            if(usado < tiepoDeUso && enOrbita == false){
                tran.position = tran.position + transform.up * velocidad * Time.deltaTime;
                jetAnim.OnJetpackEnabled();
                   tiempoCD = 0;
            }
            if(enOrbita == true)
            {
                jetAnim.OnJetpackDisabled();
            }
       }
    }

    //Movimiento del Jetpack
    public void Movimiento(){
        
            if(tiempoCD >= Cooldown && activado == false ){
            activado = true;
            //usado = 0;
            }
        
    }

    void Timer(){
        usado += 1;
    }

    void TimerJet(){
        tiempoCD += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        enOrbita = true;
        activado = false;
        tiempoCD = 0;
    }

    private void OnTriggerExit2D(Collider2D collision){
        enOrbita = false;
        usado = 0;
    }
    
}
