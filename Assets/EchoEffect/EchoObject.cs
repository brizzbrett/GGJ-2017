using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoObject : MonoBehaviour {

    private Transform ScannerOrigin;
    public Material EffectMaterial;
    public List<Vector4> Positions = new List<Vector4>();
    public List<float> ScanDistances = new List<float>(20);
    public List<float> Strengths = new List<float>(20);
    private List<int> InUse = new List<int>(20);
    public List<Vector4> Centers = new List<Vector4>(20);
    public List<float> Radius = new List<float>(20);
    public List<float> Speed = new List<float>(20);
    public List<float> Life = new List<float>(20);

    public int Pulses;
    public Camera MainCamera;
    private Camera _camera;


    void Start()
    {
        ScannerOrigin = transform;
       
        for (int i = 0; i < 20; i++)
        {
            Vector4 v = new Vector4 (transform.position.x, transform.position.y, transform.position.z) + new Vector4( Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10),0);
            Centers.Add(v);
            ScanDistances.Add(0);
            Strengths.Add(0);
            Radius.Add(0);
            InUse.Add(0);
            Speed.Add(0);
            Life.Add(0);
        }
    }

    void Update()
    {
        //Centers.Capacity = Pulses;
        //ScanDistances.Capacity = Pulses;
        //Strengths.Clear();
        //Radius.Clear();

        for (int i = 0; i < 20; i++)
        {
            if (InUse[i] == 1)
            {
                if (ScanDistances[i] > Life[i])
                {
                    PulseDie(i);
                    continue;
                }
                ScanDistances[i] += Time.deltaTime * Speed[i];
                Strengths[i] += Time.deltaTime * Speed[i];
                if (Strengths[i] < 0)
                    Strengths[i] = 0;
                Radius[i] = ((ScanDistances[i]));
            }
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                AddPulse(hit.point, Random.Range(20,40), Random.Range(10, 90), Random.Range(10, 30));
            }
        }
        EffectMaterial.SetVectorArray("_Centers", Centers);
        EffectMaterial.SetFloatArray("_Radius", Radius);
        EffectMaterial.SetFloatArray("_Strengths", Strengths);
        EffectMaterial.SetInt("_Pulses", Pulses);
    }

    public void AddPulse(Vector4 Position, float Speed, float life, float strength)
    {
        for(int i =0;i < InUse.Count;i++)
        {
            if(InUse[i] == 0)
            {
                this.Life[i] = life;
                this.Speed[i] = Speed;
                Centers[i] = Position;
                InUse[i] = 1;
                Pulses += 1;
                Strengths[i] = strength;
                return;
            }
        }

        
    }

    public void PulseDie(int i)
    {
        Centers[i] = new Vector4(0,0,0,0);
        Speed[i] = 0;
        ScanDistances[i] = 0;
        Radius[i] = 0;
        Strengths[i] = 0;
        InUse[i] = 0;
        Pulses -= 1;
    }
}
