using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonArchitect;


public class GameManager : MonoBehaviour {

    static public GameManager instance;
    public EchoObject EchoManager;

    public Dungeon dungeon;

    public Player player1;
    public Player player2;

    public GameObject playerGameObj;

    public GameObject p1StartPad = null;
    public GameObject p2StartPad = null;

    public bool round_started = false;

	// Use this for initialization
	void Awake () {
        dungeon.DestroyDungeon();
        var config = dungeon.Config;
        if (config != null)
        {
            config.Seed = (uint)(Random.value * uint.MaxValue);
            dungeon.Build();
        }
        instance = this;
	}
    private void Start()
    {
        EchoManager = GetComponent<EchoObject>();
    }
	// Update is called once per frame
    public static void AddStartPad(GameObject sp)
    {
        Debug.Log("Add Start Pad");
        if (!instance.p1StartPad)
            instance.p1StartPad = sp;
        else if (!instance.p2StartPad)
            instance.p2StartPad = sp;
        else
            Destroy(sp);

        Debug.Log("p1sp is " + instance.p1StartPad.transform.position);

        if (instance.p1StartPad && !instance.round_started)
        {
            instance.round_started = true;
            instance.StartRound();
        }
    }

    void StartRound()
    {
        player1 = Instantiate(playerGameObj).GetComponent<Player>();
        player1.my_startpad = instance.p1StartPad;
        player1.Respawn();

    }

    public void DestroyDungeon()
    {
        dungeon.DestroyDungeon();
    }

}
