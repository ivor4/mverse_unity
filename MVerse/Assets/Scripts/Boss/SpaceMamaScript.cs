using UnityEditor;
using UnityEngine;
using MVerse.VARMAP.EnemyMaster;
using MVerse.VARMAP.Types;
using MVerse.FixedConfig;
using System.Collections.Generic;

namespace MVerse.Boss.SpaceMama
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


            
        }


        private void Update()
        {
            Game_Status gstatus = VARMAP_EnemyMaster.GET_GAMESTATUS();

            switch(gstatus)
            {
                case Game_Status.GAME_STATUS_PLAY_FREEZE:
                    
                    break;

                case Game_Status.GAME_STATUS_PLAY:
                    
                    break;
            }
        }

    }
}