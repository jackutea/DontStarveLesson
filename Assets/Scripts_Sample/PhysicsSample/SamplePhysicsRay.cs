using System;
using UnityEngine;

namespace DontStarve.Sample {

    public class SamplePhysicsRay : MonoBehaviour {

        public float rayLength;

        bool hasHitPlane;
        Vector3 hitPoint;

        [SerializeField] GameObject cube;
        [SerializeField] Vector3 half = new Vector3(0.5f, 0.5f, 0.5f);

        void FixedUpdate() {

            bool hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayLength);
            if (hasHit) {
                Vector3 rayHitPoint = hit.point;
                Debug.Log(hit.collider.gameObject.name + " point: " + rayHitPoint);
            }

            // 从相机发射一条射线到鼠标点击的位置
            // 1. 从屏幕坐标转换到世界坐标
            // 2. 从相机发射一条射线到世界坐标
            // 3. 检测射线是否碰撞到物体
            // 4. 如果碰撞到物体, 获取碰撞点
            // 5. 将物体移动到碰撞点

            // 获取鼠标的屏幕坐标
            Vector2 mouseScreenPoint = Input.mousePosition;
            // 把屏幕坐标转换成一条从相机发射到 `鼠标所在的世界坐标` 的射线
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPoint);
            int layer = 0b00000000_00000000_00000000_00000000; // 原始值
            Int32 layer32 = layer;
            int layer_1_leftmove_7_ground = 0b00000000_00000000_00000000_10000000; // 1 << 7
            int layer_1_leftmove_6_role = 0b00000000_00000000_00000000_01000000; // 1 << 6
            // int layer_ground_and_role =  0b00000000_00000000_00000000_11000000;
            // | 相当于 `or` 中文又称 `或`: 
            // 0 | 0 = 0;
            // 0 | 1 = 1;
            // 1 | 1 = 1;
            int layer_ground_and_role = layer_1_leftmove_7_ground | layer_1_leftmove_6_role;
            hasHitPlane = Physics.Raycast(ray, out RaycastHit hit2, 1000f, layer_ground_and_role);
            if (hasHitPlane) {
                hitPoint = hit2.point;
            }

            Vector3 center = transform.position;    
            Collider[] allOverlap = Physics.OverlapBox(center, half, Quaternion.identity, layer_ground_and_role);
            if (allOverlap.Length > 0) {
                // Debug.Log("allOverlap.Length: " + allOverlap.Length);
            }
        }

        // Trigger 三个生命周期函数
        void OnTriggerEnter(Collider other) {
            Debug.Log("TTTT Enter: " + other.gameObject.name);
        }

        void OnTriggerStay(Collider other) {
            // Debug.Log("OnTriggerStay: " + other.gameObject.name);
        }

        void OnTriggerExit(Collider other) {
            Debug.Log("TTTTT Exit: " + other.gameObject.name);
        }

        // Collision 三个生命周期函数
        void OnCollisionEnter(Collision collision) {
            Debug.Log("CCCCC Enter: " + collision.gameObject.name);
        }

        void OnCollisionStay(Collision collision) {
            // Debug.Log("OnCollisionStay: " + collision.gameObject.name);
        }

        void OnCollisionExit(Collision collision) {
            Debug.Log("CCCC Exit: " + collision.gameObject.name);
        }

        // Gizmos, 它不是 Runtime, 给开发者演示用的, 玩家看不到
        void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayLength);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, half);

            if (hasHitPlane) {
                cube.transform.position = hitPoint;
            }
        }

    }

}