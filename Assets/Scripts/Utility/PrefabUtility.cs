using UnityEngine;

namespace Assets.Scripts.Utility
{
    public static  class PrefabUtility
    {
        public static T InstantiatePrefab<T>(GameObject prefab, Transform parent)
        {
            var go = Object.Instantiate(prefab, parent, false);
            go.SetActive(true);
            return go.GetComponent<T>();
        }
    }
}
