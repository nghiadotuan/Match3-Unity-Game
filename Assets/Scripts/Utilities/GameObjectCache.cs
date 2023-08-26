using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class GameObjectCache
    {
        private static readonly Dictionary<string, GameObject> _dicGameObjectCache = new Dictionary<string, GameObject>();

        public static GameObject GetGameObjectFromResources(string path)
        {
            if (_dicGameObjectCache.TryGetValue(path, value: out var asset)) return asset;

            var prefab = Resources.Load<GameObject>(path);
            _dicGameObjectCache.Add(path, prefab);
            return prefab;
        }
    }
}