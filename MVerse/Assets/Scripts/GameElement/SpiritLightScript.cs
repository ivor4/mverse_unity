using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RamsesTheThird.VARMAP.PlayerMaster;
using RamsesTheThird.VARMAP.Types;
using RamsesTheThird.FixedConfig;

namespace RamsesTheThird.PlayerMaster
{
    public class SpiritLightScript : MonoBehaviour
    {
        private int solidMask;
        private Collider actualcollider;
        private Rigidbody myrigidbody;

        // Start is called before the first frame update
        void Start()
        {
            solidMask = 1 << (int)CollisionLayer.LAYER_SOLID;
            actualcollider = GetComponent<Collider>();
            myrigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            Game_Status gstatus = VARMAP_PlayerMaster.GET_GAMESTATUS();

            switch(gstatus)
            {
                case Game_Status.GAME_STATUS_PLAY:
                    Execute_Play();
                    break;

                default:
                    break;
            }
        }

        private void Execute_Play()
        {
            KeyStruct keyInfo = VARMAP_PlayerMaster.GET_PRESSED_KEYS();
            int hor;
            int ver;

            if((keyInfo.pressedKeys & KeyFunctions.KEYFUNC_LEFT) != 0)
            {
                hor = -1;
            }
            else if((keyInfo.pressedKeys & KeyFunctions.KEYFUNC_RIGHT) != 0)
            {
                hor = 1;
            }
            else
            {
                hor = 0;
            }

            if ((keyInfo.pressedKeys & KeyFunctions.KEYFUNC_UP) != 0)
            {
                ver = 1;
            }
            else if ((keyInfo.pressedKeys & KeyFunctions.KEYFUNC_DOWN) != 0)
            {
                ver = -1;
            }
            else
            {
                ver = 0;
            }


            if ((ver != 0) || (hor != 0))
            {
                Vector3 direction = new Vector3(hor, ver, 0).normalized;

                Ray ray = new Ray(actualcollider.bounds.center, direction);

                float delta;

                if (Physics.Raycast(ray, out RaycastHit hitInfo, GameFixedConfig.PLAYER_NORMAL_MOVEMENT_SPEED * Time.fixedDeltaTime, solidMask, QueryTriggerInteraction.Ignore))
                {
                    delta = hitInfo.distance - actualcollider.bounds.extents.x;
                }
                else
                {
                    delta = GameFixedConfig.PLAYER_NORMAL_MOVEMENT_SPEED * Time.fixedDeltaTime;
                }

                delta = Mathf.Max(0.05f, delta);

                myrigidbody.MovePosition(transform.position + direction * delta);
            }
            Vector3Struct v3struct = new Vector3Struct();
            v3struct.position = transform.position;

            VARMAP_PlayerMaster.SET_PLAYER_POSITION(v3struct);
        }

        private void OnEnable()
        {
            transform.position = VARMAP_PlayerMaster.GET_PLAYER_POSITION().position;
        }
    }
}
