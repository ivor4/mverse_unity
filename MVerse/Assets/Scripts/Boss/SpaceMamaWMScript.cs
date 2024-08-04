using UnityEditor;
using UnityEngine;
using MVerse.VARMAP.BossMaster;
using MVerse.VARMAP.Types;
using MVerse.FixedConfig;
using System.Collections.Generic;

namespace MVerse.Boss.SpaceMama.WM
{
    public class SpaceMamaWMScript : MonoBehaviour
    {
        [SerializeField]
        private float finalY;

        private Rigidbody myrigidbody;
        private Collider mycollider;
        private MeshRenderer myrenderer;
        private Transform mainBody;
        private Transform door;
        private Vector3 centerOfCircle;
        private float initialY;

        private ulong gpt;


        private void Awake()
        {

        }

        private void Start()
        {
            myrigidbody = GetComponentInChildren<Rigidbody>();
            mycollider = GetComponentInChildren<Collider>();
            myrenderer = GetComponentInChildren<MeshRenderer>();
            door = transform.Find("DoorBase");
            mainBody = transform;
            initialY = mainBody.position.y;



            VARMAP_BossMaster.MONO_REGISTER(this, true);

            VARMAP_BossMaster.SET_BOSS_STEP((byte)SpaceMamaStep.STEP_WM_WAIT_ENTRY);
            gpt = VARMAP_BossMaster.GET_ELAPSED_TIME_MS();
        }


        private void Update()
        {
            byte step = VARMAP_BossMaster.GET_BOSS_STEP();
            ulong timestamp = VARMAP_BossMaster.GET_ELAPSED_TIME_MS();

            switch (step)
            {
                case (byte)SpaceMamaStep.STEP_WM_WAIT_ENTRY:
                    Step_0_Entry(timestamp);
                    break;

                case (byte)SpaceMamaStep.STEP_WM_ENTRY_FLY:
                    Step_1_Fly(timestamp);
                    break;

                case (byte)SpaceMamaStep.STEP_WM_OPEN_DOOR:
                    Step_3_OpenDoor(timestamp);
                    break;
            }

            

            
        }



        private void Step_0_Entry(ulong timestamp)
        {
            ulong deltaTime = timestamp - gpt;

            if (deltaTime > 2000)
            {
                VARMAP_BossMaster.SET_BOSS_STEP((byte)SpaceMamaStep.STEP_WM_ENTRY_FLY);
                gpt = timestamp;
            }
        }

        private void Step_1_Fly(ulong timestamp)
        {
            ulong deltaTime = timestamp - gpt;

            if (deltaTime < 1000)
            {
                mainBody.Translate(Vector3.right * Time.deltaTime * 6f);
                centerOfCircle = mainBody.transform.position + Vector3.up * 3.0f;
            }
            else if(deltaTime < 2000)
            {
                float angle;
                float cx;
                float sy;
                /* Simplify calculations */
                deltaTime -= 1000;

                angle = (Mathf.PI * 3f / 2f) + 2f*Mathf.PI*deltaTime/1000;
                cx = Mathf.Cos(angle) * 3.0f;
                sy = Mathf.Sin(angle) * 3.0f;

                mainBody.position = new Vector3(centerOfCircle.x + cx, centerOfCircle.y + sy, centerOfCircle.z);
            }
            else if(deltaTime < 2500)
            {
                mainBody.Translate(Vector3.right * Time.deltaTime * 6f);
                centerOfCircle = mainBody.transform.position + Vector3.up * 3.0f;
            }
            else if(deltaTime < 3500)
            {
                float angle;
                float cx;
                float sy;
                /* Simplify calculations */
                deltaTime -= 2500;

                angle = (Mathf.PI * 3f / 2f) + 2.5f * Mathf.PI * deltaTime / 1000;
                cx = Mathf.Cos(angle) * 3.0f;
                sy = Mathf.Sin(angle) * 3.0f;

                mainBody.position = new Vector3(centerOfCircle.x + cx, centerOfCircle.y + sy, centerOfCircle.z);
                initialY = mainBody.position.y;
            }
            else if(deltaTime < 4000)
            {
                /* Simplify calculations */
                deltaTime -= 3500;

                mainBody.position = new Vector3(mainBody.position.x, initialY + (-initialY + finalY)*deltaTime/500f, 0);
            }
            else
            {
                gpt = timestamp;
                VARMAP_BossMaster.SET_BOSS_STEP((byte)SpaceMamaStep.STEP_WM_OPEN_DOOR);
            }
                
        }

        private void Step_3_OpenDoor(ulong timestamp)
        {
            ulong deltaTime = timestamp - gpt;

            if (deltaTime < 1000)
            {
                door.localRotation = Quaternion.Euler(0, -144f * deltaTime / 1000f, 0);
            }
            else
            {
                VARMAP_BossMaster.SET_BOSS_STEP((byte)SpaceMamaStep.STEP_SM_COME_OUT);
            }
        }

        private void OnDestroy()
        {
            VARMAP_BossMaster.MONO_REGISTER(this, false);
        }
    }
}