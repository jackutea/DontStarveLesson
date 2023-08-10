using System;
using UnityEngine;

namespace DontStarve {

    // 委托示例
    public class DelegateSample {

        // 什么是变量: 存数据的
        int a;

        // 什么是委托: 存方法的变量
        // 我们不知道用户何时输入, 延迟调用/延迟绑定
        // 常见场景: 点击按钮 / 输入用户名密码 / 网络请求
        Action action;
        Action<int> actionIntHandle;
        Action<int, float, string> actionMiscHandle; // 支持 16 个参数
        Action<float> actionFloatHandle;

        public void Enter() {

            actionIntHandle = OnIntMethod;
            actionIntHandle(1);

            actionMiscHandle = OnMiscMethod;
            actionMiscHandle(1, 2.0f, "3");
            
            actionFloatHandle = (float fv) => {
                Debug.Log("Float: " + fv);
            };
            actionFloatHandle.Invoke(8.8f);

            // 扩展: 匿名函数
            action = () => {
                Debug.Log("Anyonymous Function");
            };
            action.Invoke(); // 区分它是委托还是方法

        }

        void OnIntMethod(int value) {

        }

        void OnMiscMethod(int value, float value2, string value3) {

        }

        public void Tick() {
            if (Input.GetKeyDown(KeyCode.L)) {
                action = LMethod;
            } else if (Input.GetKeyDown(KeyCode.R)) {
                action = RMethod;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                if (action != null) {
                    action();
                }
            }
        }

        void LMethod() {
            Debug.Log("L:LLLLLLLLLLLLLLL");
        }

        void RMethod() {
            Debug.Log("R:RRRRRRRRRRRRRRRR");
        }

    }
}