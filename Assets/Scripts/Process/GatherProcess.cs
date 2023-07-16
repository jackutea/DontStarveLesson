using System.Collections.Generic;
using UnityEngine;

namespace DontStarve {

    // 采集 进程
    public static class GatherProcess {

        public static void Gather(RoleEntity role, List<PlantEntity> allGrass) {

            // 1. 获取角色的位置
            Vector3 rolePos = role.transform.position;

            // 2. 获取角色的采集范围
            float roleGatherRadius = role.gatherRadius;

            PlantEntity nearestGrass = FindNearestGrass(rolePos, roleGatherRadius, allGrass);

            // 4. 处于范围内的那一颗就可以采
            if (nearestGrass != null) {
                // 5. 采完之后, 草的数量减少, 角色的草的数量增加
                bool isGrassClear = role.GatherGrass(nearestGrass);
                if (isGrassClear) {
                    allGrass.Remove(nearestGrass); // 从列表中移除这颗草
                }
                Debug.Log("采到了一颗草" + nearestGrass.id + ", 还剩" + allGrass.Count + "颗草");
            } else {
                // 6. 如果没有草处于范围内, 就不采
                Debug.Log("没有草处于范围内");
            }

        }

        static PlantEntity FindNearestGrass(Vector3 rolePos, float roleGatherRadius, List<PlantEntity> allGrass) {
            /* 整段只做一件事: 找到一颗草 */
            // 3. 遍历所有的草, 找到离角色最近的
            //    3.1 第0颗草, 距离角色5米, 会忽略
            //    3.2 第1颗草, 距离角色1米, 可采的, nearestGrass = 第1颗草, 并且最近的距离 nearestGrassDistance = 1米
            //    3.3 第2颗草, 距离角色1.2米, 会忽略
            //    ......
            PlantEntity nearestGrass = null;
            float nearestGrassDistance = float.MaxValue;
            for (int i = 0; i < allGrass.Count; i += 1) {
                // 遍历到当前的草
                var currentGrass = allGrass[i];
                Vector3 grassPos = currentGrass.transform.position;
                grassPos.y = 0; // 忽略高度

                // 当前这颗草和角色的距离
                // 包含了 x, y, z 三个方向的距离
                float grassDistance = Vector3.Distance(rolePos, grassPos);

                // 距离大于角色可收集的距离, 不管这颗草
                if (grassDistance > roleGatherRadius) {
                    continue;
                }

                // 对比上一次最近的草, 如果这颗草更近, 就更新最近的草
                if (grassDistance < nearestGrassDistance) {
                    nearestGrass = currentGrass;
                    nearestGrassDistance = grassDistance;
                }
            }

            return nearestGrass;
            
        }

    }
}