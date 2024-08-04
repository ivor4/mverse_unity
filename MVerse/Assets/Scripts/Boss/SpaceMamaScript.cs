using UnityEditor;
using UnityEngine;
using MVerse.VARMAP.BossMaster;
using MVerse.VARMAP.Types;
using MVerse.FixedConfig;
using System.Collections.Generic;
using MVerse.Boss.BossMaster;

namespace MVerse.Boss.SpaceMama
{
    public enum SpaceMamaStep
    {
        STEP_WM_WAIT_ENTRY,
        STEP_WM_ENTRY_FLY,
        STEP_WM_OPEN_DOOR,
        STEP_SM_COME_OUT,
    }
}

namespace MVerse.Boss.SpaceMama.Mama
{
    public class SpaceMamaScript : MonoBehaviour
    {
        private Rigidbody myrigidbody;
        private Collider mycollider;
        private MeshRenderer myrenderer;


        private void Awake()
        {

        }

        private void Start()
        {
            myrigidbody = GetComponent<Rigidbody>();
            mycollider = GetComponent<Collider>();
            myrenderer = GetComponent<MeshRenderer>();


            VARMAP_BossMaster.MONO_REGISTER(this, true);
        }


        private void Update()
        {
            Game_Status gstatus = VARMAP_BossMaster.GET_GAMESTATUS();

            switch(gstatus)
            {
                case Game_Status.GAME_STATUS_PLAY_FREEZE:
                    
                    break;

                case Game_Status.GAME_STATUS_PLAY:
                    
                    break;
            }
        }

        private void OnDestroy()
        {
            VARMAP_BossMaster.MONO_REGISTER(this, false);
        }

    }
}