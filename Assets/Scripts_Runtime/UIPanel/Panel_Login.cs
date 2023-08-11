using System;
using UnityEngine;
using UnityEngine.UI;

namespace DontStarve {

    public class Panel_Login : MonoBehaviour {

        public Button startGameBtn;

        // 利用委托: 变量
        public Action onStartGameHandle;

        public void Ctor() {
            startGameBtn.onClick.AddListener(OnStartGame);
        }

        public void Open() {
            gameObject.SetActive(true);
        }

        public void Close() {
            gameObject.SetActive(false);
        }

        void OnStartGame() {
            // 不知道 onStartGameHandle 到底指向哪个函数
            // 也就是说, 它并不知道高层的存在, 但却能调用到高层
            if (onStartGameHandle != null) {
                onStartGameHandle();
                Debug.Log("OnStartGame");
            }
        }

    }
}