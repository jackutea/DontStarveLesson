using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStarve {

    // Main 是控制器, 控制全局用的
    // 世界
    public class Main : MonoBehaviour {

        // 声明了 public 或 [SerializeField] 的字段, 会在Unity的Inspector面板上显示
        public RoleEntity rolePrefab; // 预制件
        public PlantEntity grassPrefab;

        public InputEntity input;
        RoleEntity role;
        List<PlantEntity> allGrass;
        public Camera mainCamera;
        public Vector3 cameraOffset;

        // UI
        // 架构原则: 控制流是自上而下的
        // 优秀的架构里, 控制流只能是高层调用低层
        public Panel_Login panel_Login;

        // 主入口, 相当于 Main(), 只执行一次;
        protected void Start() {

            // Ctor
            input = new InputEntity();

            panel_Login.Ctor();
            // 把低层委托绑定到高层的函数
            panel_Login.onStartGameHandle = StartGame;
            // panel_Login 点击后, 触发 StartGame

        }

        void StartGame() {

            panel_Login.Close();

            // 生成角色
            role = GameObject.Instantiate(rolePrefab);
            role.Ctor();
            role.transform.position = Vector3.zero; // x = 0, y = 0, z = 0
            role.moveSpeed = 5f;
            role.gatherRadius = 2f;

            // 生成草
            allGrass = new List<PlantEntity>();
            for (int i = 0; i < 100; i += 1) {
                float randX = UnityEngine.Random.Range(-30f, 30f);
                float randZ = UnityEngine.Random.Range(-30f, 30f);
                Vector3 grassRandPos = new Vector3(randX, 0, randZ);

                int randCount = UnityEngine.Random.Range(1, 5);

                PlantEntity grass = GameObject.Instantiate(grassPrefab);
                grass.Ctor();
                grass.id = i;
                grass.transform.position = grassRandPos;
                grass.SetCount(randCount);

                allGrass.Add(grass);

            }

            // 设置相机
            cameraOffset = new Vector3(0, 5, -7);

        }

        // 主入口, 自动循环
        // deltaTime 是上一帧到这一帧的时间间隔. 每秒的deltaTime总和是1
        protected void Update() { // 会在每帧调用一次, 一秒内总共调用的次数是 1 / deltaTime

            if (role == null) {
                return;
            }

            // 1 / 60, 基于 60 FPS(Frame Per Second)
            float dt = Time.deltaTime;

            // 输入
            Vector2 moveAxis = input.ProcessMoveInput();
            bool isGatherDown = input.ProcessGatherInput();

            // 角色移动
            role.Move(moveAxis.x, moveAxis.y, dt);

            // 角色采草
            if (isGatherDown) {
                GatherProcess.Gather(role, allGrass);
            }

            // 相机跟随 (相机的位置 = 角色的位置 + 相机偏移)
            // 它一定是在角色移动后
            mainCamera.transform.position = role.transform.position + cameraOffset;

        }

    }

}
