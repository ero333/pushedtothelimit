using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlackHoleDistance
{
    Orbit1 =600,
    Orbit2 = 560,
    Orbit3 = 520,
    Orbit4 = 480,
    Orbit5 = 440,
    Orbit6 = 400,
    Orbit7 = 360,
    Orbit8 = 320,
    Orbit9 = 280,
    Orbit10 = 240,
    Orbit11 = 200,
    Orbit12 = 160,
    Orbit13 = 120,
    Orbit14 = 80,
    Orbit15 = 40
};
public enum PlanetQuadrant { C1 = 0, C2 = 45, C3 = 90, C4 = 135, C5=180, C6=225 };


public class BlackHoleAtractor : MonoBehaviour {
    public float ForceAtraction = 0.01f;
    public float RotateSpeed = 1f;
    public bool SpeedRamdom = false;
    public float RotateSpeedMin = 0.01f;
    public float RotateSpeedMax = 0.1f;
    public BlackHoleDistance Radius = BlackHoleDistance.Orbit1;
    public PlanetQuadrant Quadrant = PlanetQuadrant.C1;
    public bool QuadrantRandom = false;
    private float a, x, time;    
    private int index;
    private Vector2 _centre;
    private float _angle;
    private float _radius;
    
    void Start () {
        if(QuadrantRandom)
            _angle = Random.Range(0, 360);
        else
            _angle = (float)Quadrant;

        _radius = (float)Radius;

        if (SpeedRamdom)
            RotateSpeed = Random.Range(RotateSpeedMin, RotateSpeedMax);
    }
		
	void Update () {        
        Move();
    }
    
    void Move()
    {
        _angle += RotateSpeed * Time.deltaTime;
        _radius -= ForceAtraction;
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _radius;
        transform.position = _centre + offset;
    }

    void CuadraticaConOrdenadaOrigen()
    {
        /*
        x = positionsOrbict[0].x;
        y = positionsOrbict[0].y;
        s = positionsOrbict[1].x;
        d = positionsOrbict[1].y;
        q = positionsOrbict[2].x;
        w = positionsOrbict[2].y;
        a = ((y - w) - (((y - d) * x - (y - d) * q) * (1 / (x - s))) / ((x * x - q * q) + (((x * x - s * s) * q - (x * x - s * s) * x) * (1 / (x - s)))));
        b = (((y - d) - a * (x * x - s + s)) / (x - s));
        c = y - a * x * x - b * x;

        x = 10;*/
    }
}
