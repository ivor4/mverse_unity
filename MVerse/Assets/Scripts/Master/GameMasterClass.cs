using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVerse.VARMAP.Types;
using MVerse.VARMAP.GameMaster;
using UnityEngine.SceneManagement;
using MVerse.VARMAP.Initialization;
using MVerse.FixedConfig;
using MVerse.VARMAP.Safe;
using UnityEditor;

namespace MVerse.GameMaster
{

    public class GameMasterClass : MonoBehaviour
    {
        private static GameMasterClass _singleton;

        private float elapsed_seconds;

        private int debug_index;
        private int debug_value;

        private void Awake()
        {
            if (_singleton != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _singleton = this;
                DontDestroyOnLoad(gameObject);

                /* Initialize VARMAP once for all the game */
                VARMAP_Initialization.InitializeVARMAP();
            }
        }

        private void Start()
        {
            /* CAREFUL, TODO must create a Load system before starting assigning like this */
            elapsed_seconds = VARMAP_GameMaster.GET_ELAPSED_TIME_MS() / GameFixedConfig.MILLISECONDS_TO_SECONDS;
        }

        private void Update()
        {
            Game_Status gstatus = VARMAP_GameMaster.GET_GAMESTATUS();

            switch(gstatus)
            {
                case Game_Status.GAME_STATUS_PLAY:
                case Game_Status.GAME_STATUS_STOPPED:
                    Play_Process_Time();
                    break;
            }

            VARMAP_Safe.IncrementTick();

        }

        private void Play_Process_Time()
        {
            float elapsedDelta = Time.deltaTime;

            elapsed_seconds = VARMAP_GameMaster.GET_ELAPSED_TIME_MS() / GameFixedConfig.MILLISECONDS_TO_SECONDS;

            elapsed_seconds += elapsedDelta;

            VARMAP_GameMaster.SET_ELAPSED_TIME_MS((ulong)(elapsed_seconds * GameFixedConfig.MILLISECONDS_TO_SECONDS));
        }


        public static void LoadRoomService(Room room, out bool error)
        {
            string sceneName = "";
            if (VARMAP_GameMaster.GET_GAMESTATUS() == Game_Status.GAME_STATUS_STOPPED)
            {
                if ((room > Room.NONE) && (room < Room.TOTAL_ROOMS))
                {
                    sceneName = GameFixedConfig.ROOM_TO_SCENE_NAME[(int)room];
                    error = false;
                }
                else
                {
                    error = true;
                }
            }
            else
            {
                error = true;
            }

            if (!error)
            {
                VARMAP_GameMaster.SET_ACTUAL_ROOM(room);
                VARMAP_GameMaster.SET_GAMESTATUS(Game_Status.GAME_STATUS_LOADING);

                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }

        public static void StartGameService(out bool error)
        {
            VARMAP_Initialization.ResetVARMAP();
            LoadRoomService(Room.ROOM_1_ORIGIN, out error);
        }

        public static void LoadOneBossFightService(OBFight fight, out bool error)
        {
            VARMAP_Initialization.ResetVARMAP();

            switch(fight)
            {
                case OBFight.OBF_SPACE_MAMA:
                    VARMAP_GameMaster.SET_ELEM_POWERS((int)Powers_Index.POWER_INDEX_SHOT, true);
                    VARMAP_GameMaster.SET_ELEM_POWERS((int)Powers_Index.POWER_INDEX_CLIMB, true);
                    VARMAP_GameMaster.SET_ELEM_POWERS((int)Powers_Index.POWER_INDEX_DOUBLE_JUMP, true);
                    VARMAP_GameMaster.SET_ELEM_SELECTED_CHARMS(0, (byte)Charm.CHARM_INPU_OTHER_WORLD);
                    VARMAP_GameMaster.SET_ELEM_SELECTED_CHARMS(1, (byte)Charm.CHARM_NONE);
                    LoadRoomService(Room.ROOM_SPACE_MAMA, out error);
                    break;

                default:
                    error = true;
                    break;
            }

            
        }

        public static void LoadingCompletedService(out bool error)
        {
            if (VARMAP_GameMaster.GET_GAMESTATUS() == Game_Status.GAME_STATUS_LOADING)
            {
                VARMAP_GameMaster.SET_GAMESTATUS(Game_Status.GAME_STATUS_PLAY);
                error = false;
            }
            else
            {
                error = true;
            }
        }

        public static void FreezePlayService(bool freeze)
        {
            Game_Status status = VARMAP_GameMaster.GET_GAMESTATUS();

            if (freeze && (status == Game_Status.GAME_STATUS_PLAY))
            {
                VARMAP_GameMaster.SET_GAMESTATUS(Game_Status.GAME_STATUS_PLAY_FREEZE);
            }
            else if((!freeze) && (status == Game_Status.GAME_STATUS_PLAY_FREEZE))
            {
                VARMAP_GameMaster.SET_GAMESTATUS(Game_Status.GAME_STATUS_PLAY);
            }
            else
            {

            }

        }

        public static void ExitGameService(out bool error)
        {
            if (VARMAP_GameMaster.GET_GAMESTATUS() != Game_Status.GAME_STATUS_STOPPED)
            {
                VARMAP_GameMaster.SET_GAMESTATUS(Game_Status.GAME_STATUS_STOPPED);
                SceneManager.LoadScene(GameFixedConfig.ROOM_MAINMENU, LoadSceneMode.Single);
                error = false;
            }
            else
            {
                error = true;
            }
        }


        private void OnDestroy()
        {
            if (_singleton == this)
            {
                _singleton = null;
            }
        }
    }
}

