using UnityEngine;

namespace DontStarve {

    // 输入实体
    // 面向对象-封装
    // 把所有的输入都放在这里处理
    public class InputEntity {

        public bool ProcessGatherInput() {
            bool isKeyDown = Input.GetKeyDown(KeyCode.Space);
            return isKeyDown;
        }

        public Vector2 ProcessMoveInput() {

            // 输入
            Vector2 axis = Vector2.zero; // x = 0, y = 0
            if (Input.GetKey(KeyCode.W)) {
                axis.y = 1;
            } else if (Input.GetKey(KeyCode.S)) {
                axis.y = -1;
            }
            
            if (Input.GetKey(KeyCode.A)) {
                axis.x = -1;
            } else if (Input.GetKey(KeyCode.D)) {
                axis.x = 1;
            }

            axis.Normalize(); // 归一化, 保证长度为1

            return axis;

        }

    }

}