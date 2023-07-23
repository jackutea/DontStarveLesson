using UnityEngine;
using TMPro;

namespace DontStarve {

    public class PlantEntity : MonoBehaviour {

        // 自带 Transform, Transform 自带了 平移、旋转、缩放
        public int id;
        int count; // 3

        TextMeshProUGUI textMeshPro;

        public void Ctor() {
            textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        }

        // Count 相关的函数
        public int GetCount() {
            return count;
        }

        public void SetCount(int _count) {
            count = _count;
            textMeshPro.text = count.ToString();
        }

        public void SetDead() {
            GameObject.Destroy(gameObject);
        }

        public void SetAlive() {
            // 变成活的样子
        }

        public void Tick(float dt) {
            // 如果是枯萎的, 需要慢慢复活
            // 很像红绿灯的变化: 枯 -> 活
        }

    }

}