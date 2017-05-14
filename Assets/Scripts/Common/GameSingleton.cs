using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSingleton : MonoBehaviour
{
<<<<<<< .merge_file_a01880
    public static GameSingleton Instance = null;    

    public GlobalTypes.GameKind GameKind = GlobalTypes.GameKind.Sudda;    
=======
    public GamePlayData GameData = null;
    public static GameSingleton Instance = null;
    public GlobalTypes.GameKind GameKind = GlobalTypes.GameKind.Sudda;
>>>>>>> .merge_file_a04244

    private string GetArg(string name)
    {
        string[] Args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < Args.Length; ++i)
        {
            if(Args[i].ToLower() == name && Args.Length > i + 1)
            {
                return Args[i + 1];
            }
        }

        return null;
    }

    private void Init()
    {
        GameData = new GamePlayData();
        //string FindGameKind = GetArg("gamekind");
        //if (FindGameKind != null)
        //{
        //    try
        //    {
        //        GameKind = (GlobalTypes.GameKind)System.Enum.Parse(typeof(GlobalTypes.GameKind), FindGameKind, true);
        //    }
        //    catch (System.Exception e)
        //    {
        //        // TODO: Assert 작업 해야함.
        //    }
        //}
        //else
        //{
        //    // TODO: Assert 작업 해야함.
        //}
    }

    public void GameInit()
    {
        GameData.Init(GameKind);
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            Init();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // ===========================================================================
    //
    //  PlayScene
    //
    // ===========================================================================
    private static PlayScene PlayInst = null;

    public static void SetPlayScene(PlayScene scene)
    {
        PlayInst = scene;
    }
    public static PlayScene GetBasePlayScene()
    {
        assert.set(PlayInst != null);
        return PlayInst;
    }
    public static SevenPokerScene GetSevenPokerPlayScene()
    {
        assert.set(PlayInst != null);
        assert.set(PlayInst is SevenPokerScene);
        return PlayInst as SevenPokerScene;
    }
}
