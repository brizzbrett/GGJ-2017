using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoObject : MonoBehaviour {

    private Transform ScannerOrigin;
    public List<Vector4> Positions = new List<Vector4>();
    public Material EffectMaterial;
    public List<float> ScanDistances = new List<float>(20);
    public List<float> Strengths = new List<float>(20);
    private List<int> InUse = new List<int>(20);
    public float Speed;
    public int Pulses;
    public List<Vector4> Centers = new List<Vector4>(20);
    public List<float> Radius = new List<float>(20);

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
                if (ScanDistances[i] > 90)
                {
                    PulseDie(i);
                    continue;
                }
                ScanDistances[i] += Time.deltaTime * Speed;
                Strengths[i] = ((90 - ScanDistances[i]) / 90 * 35);
                Radius[i] = ((ScanDistances[i] + 30));
            }
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                AddPulse(hit.point);
            }
        }
        EffectMaterial.SetVectorArray("_Centers", Centers);
       // Debug.Log(EffectMaterial.GetVectorArray("_Centers").GetValue(0) +  ", " + EffectMaterial.GetVectorArray("_Centers").GetValue(1) + " , " +
     //       EffectMaterial.GetVectorArray("_Centers").GetValue(2) + " , " + EffectMaterial.GetVectorArray("_Centers").GetValue(3));
        EffectMaterial.SetFloatArray("_Radius", Radius);
        //Debug.Log(EffectMaterial.GetFloatArray("_Radius").GetValue(0) + ", " + EffectMaterial.GetFloatArray("_Radius").GetValue(1) + " , " +
       //     EffectMaterial.GetFloatArray("_Radius").GetValue(2));
        EffectMaterial.SetFloatArray("_Strengths", Strengths);
       // Debug.Log(EffectMaterial.GetFloatArray("_Strengths").GetValue(0) + ", " + EffectMaterial.GetFloatArray("_Strengths").GetValue(1) + " , " +
      //      EffectMaterial.GetFloatArray("_Strengths").GetValue(2));
        EffectMaterial.SetInt("_Pulses", Pulses);
    }

    public void AddPulse(Vector4 Position)
    {
        for(int i =0;i < InUse.Count;i++)
        {
            if(InUse[i] == 0)
            {
                Centers[i] = Position;
                InUse[i] = 1;
                Pulses += 1;
                return;
            }
        }

        
    }

    public void PulseDie(int i)
    {
        Centers[i] = new Vector4(0,0,0,0);
        ScanDistances[i] = 0;
        Radius[i] = 0;
        Strengths[i] = 0;
        InUse[i] = 0;
        Pulses -= 1;
    }
}
