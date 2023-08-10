using UnityEngine;
using UnityEngine.UI;

namespace DontStarve {

    public class UISample : MonoBehaviour {

        public Sprite imgIcon;

        public Image image;
        public Text txt;
        public Button btn;
        public Slider slider;
        public InputField inputField;

        string username;

        public void Ctor() {

            // UI 组件有两大核心功能:
            // 1. 用于显示
            // 图片与文字是纯显示
            image.sprite = imgIcon;
            txt.text = "Hello World";

            // 滑动条、输入框、按钮是有交互功能的
            var btnText = btn.GetComponentInChildren<Text>();
            btnText.text = "Click Me";

            float hp = 50f;
            float hpMax = 100f;
            slider.maxValue = hpMax;
            slider.value = hp;

            var placeholder = inputField.placeholder.GetComponent<Text>();
            placeholder.text = "请输入用户名";

            inputField.text = "aaaaaaaa";

            // 2. 用于获取玩家输入
            // * 委托就特别重要了
            btn.onClick.AddListener(OnBtnClick); // 添加绑定: 按钮点击时触发的函数, 先绑定的先触发
            
            slider.onValueChanged.AddListener(OnValueChangedMethod);

            // - InputField
            // 值发生变化时
            inputField.onValueChanged.AddListener(OnInputFieldValueChangedMethod);

        }

        void OnBtnClick() {
            Debug.Log("Login: " + username);
        }

        void OnValueChangedMethod(float value) {
            Debug.Log("OnValueChangedMethod: " + value);
        }

        void OnInputFieldValueChangedMethod(string value) {
            Debug.Log("OnInputFieldValueChangedMethod: " + value);
            username = value;
        }

        public void Tick() {

        }

    }
}