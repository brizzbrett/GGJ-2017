using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour {

    public bool is_opened;
    public GameObject [] weapons;

    void Start()
    {
        is_opened = false;
    }

    public IEnumerator OpenChest(Transform top, Transform pivot, GameObject loot)
    {
        float duration = 1.0f;
        float rotation = 60.0f; //rotate top
        float total_rotation = 0;
        
        float move_up_loot = .3f;
        float total_move = 0;
        Vector3 up = loot.transform.up;

        Quaternion bRotation = top.rotation;
        Vector3 bPosition = top.position;

       
        for (float time = 0; time < duration; time += Time.deltaTime)
        {
            if (time == 0)
            {
                bRotation = top.rotation;
                bPosition = top.position;
            }
            float curr_rotation = rotation * Time.deltaTime;
            top.RotateAround(pivot.position, pivot.right, curr_rotation);
            total_rotation += curr_rotation;

            Vector3 up_distance = up * move_up_loot * Time.deltaTime;

            if(loot)
                loot.transform.position += up_distance;

            total_move += up_distance.magnitude;

            yield return null;
        }

        top.RotateAround(pivot.position, pivot.right, (rotation - total_rotation));
        if (loot)
            loot.transform.position += up * ( move_up_loot - total_move );

        StartCoroutine(BoxRegenTimer(top, bRotation, bPosition));

        yield break;
       
    }

    IEnumerator BoxRegenTimer(Transform top, Quaternion rot, Vector3 pos)
    {
        top.rotation = rot;
        top.position = pos;
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(60.0f);

        this.gameObject.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        this.is_opened = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (this.is_opened)
            return;

        if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "MainCamera"))
        {
            Debug.Log("poooopp");
            is_opened = true;

            int index = Random.Range(0, weapons.Length );
            Debug.Log("weap length " + weapons.Length);
            Debug.Log("Rand " + index);

            GameObject new_weap = Instantiate(weapons[index], col.transform.position, col.transform.rotation);

            Transform top = transform.Find("Top");
            Transform pivot = transform.Find("Rotate");
            StartCoroutine(OpenChest(top, pivot, new_weap));
        }
        
    }

}
