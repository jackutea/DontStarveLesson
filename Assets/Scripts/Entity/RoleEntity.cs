using UnityEngine; // 为了方便使用, 所以常用的命名空间会提前using

namespace DontStarve {

    // 继承, 获得父类的所有字段和方法
    // * Role 角色
    // * Entity 是实体的意思

    // 写一个类主要做的事：
    // 1. 定义字段(属性)
    // 2. 定义函数(方法)

    // 玩家角色、动物、怪物
    // 建议: 草 和 角色 互相不知道对方存在
    // 如同 角色和相机互相不知道对方存在
    public class RoleEntity : MonoBehaviour {

        string roleName; // 任何字段不声明 `访问修饰符` 默认 private
        public float moveSpeed;
        public float gatherRadius; // 采集半径

        public int grassStorage; // 角色持有多少草

        // 移动方法
        // inputMoveAxis: 输入的移动方向, WSAD/方向键
        // 三维坐标系: x 正为右, y 正为上(跳), z 正为前
        // deltaTime: 上一帧到这一帧的时间间隔. 每秒的deltaTime总和是1
        // float 小数
        public void Move(float x, float z, float deltaTime) {

            // 三维移动方向
            Vector3 moveInput3 = new Vector3(x, 0, z);

            // 1. 获取数据
            Vector3 pos = transform.position;

            // 2. 运算
            pos += moveInput3 * moveSpeed * deltaTime;

            // 3. 设置数据
            transform.position = pos;

            // 4. 渲染(Unity会自动渲染)
            
        }

        public bool GatherGrass(PlantEntity grass) {
            bool isClear;
            if (grass.count > 0) {
                grassStorage += 1;
                grass.count -= 1;

                if (grass.count <= 0) {
                    grass.SetDead();
                    isClear = true;
                    return isClear;
                }
            }
            isClear = false;
            return isClear;
        }

    }

}