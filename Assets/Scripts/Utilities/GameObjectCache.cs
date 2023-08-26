using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class GameObjectCache
    {
        private static readonly Dictionary<string, GameObject> _dicGameObjectCache = new Dictionary<string, GameObject>();
        private static readonly Dictionary<string, Object> _dicObjectCache = new Dictionary<string, Object>();

        public static GameObject GetGameObjectFromResources(string path)
        {
            if (_dicGameObjectCache.TryGetValue(path, value: out var asset)) return asset;

            var prefab = Resources.Load<GameObject>(path);
            _dicGameObjectCache.Add(path, prefab);
            return prefab;
        }

        public static T GetAssetFromResources<T>(string path) where T: Object
        {
            if (_dicObjectCache.TryGetValue(path, value: out var asset)) return asset as T;

            var prefab = Resources.Load<T>(path);
            _dicObjectCache.Add(path, prefab);
            return prefab;
        }
    }
}