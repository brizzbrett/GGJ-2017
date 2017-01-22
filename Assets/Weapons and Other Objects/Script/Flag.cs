using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {

    public int myId;
    public Sound sonicBoom;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Fag");
	}

    void OnTriggerEnter(Collider other)
    {
        //only player collisions matter
        if ((other.gameObject.tag != "Player") && (other.gameObject.tag != "MainCamera"))
            return;

        Player player = other.gameObject.GetComponent<Player>();
        int player_id = player.myId;

        if (player_id != myId)
        {
            Transform p_transform = other.gameObject.transform; //player transform

            Vector3 p_forward = p_transform.forward;
            Vector3 p_right = p_transform.right;
            Vector3 translate_offset = (p_forward * .75f) + (p_right * 1.0f);
            translate_offset.y += .75f;
            Vector3 rotate = new Vector3 { x = 45, y = 0, z = 45 };

            this.transform.parent = p_transform;
            this.transform.position += translate_offset; //move flag a a bit in front and above the new owner
            this.transform.rotation = p_transform.rotation;
            this.transform.Rotate(rotate);

            player.haveEnemyFlag = true;
            SoundManager.StartSound(sonicBoom);
            //play sound
        }
        else
        {
            if (player.haveEnemyFlag)
            {
                Application.LoadLevel(0);
            }
        }

    }


    
}
