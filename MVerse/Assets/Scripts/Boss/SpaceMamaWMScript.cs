using UnityEditor;
using UnityEngine;
using MVerse.VARMAP.BossMaster;
using MVerse.VARMAP.Types;
using MVerse.FixedConfig;
using System.Collections.Generic;

namespace MVerse.Boss.SpaceMamaWM
{
    public class SpaceMamaWMScript : MonoBehaviour
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

            myrenderer.enabled = false;
            mycollider.enabled = false;
            
        }


        private void Update()
        {
            
        }

    }
}