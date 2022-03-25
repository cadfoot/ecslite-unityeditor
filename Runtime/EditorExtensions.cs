// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

#if UNITY_EDITOR
using System;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor {
    public static class EditorExtensions {
        public static string GetCleanGenericTypeName (Type type) {
            if (!type.IsGenericType) {
                return type.Name;
            }
            var constraints = "";
            foreach (var constraint in type.GetGenericArguments ()) {
                constraints += constraints.Length > 0 ? $", {GetCleanGenericTypeName (constraint)}" : constraint.Name;
            }
            return $"{type.Name.Substring (0, type.Name.LastIndexOf ("`", StringComparison.Ordinal))}<{constraints}>";
        }
    }

    public sealed class EcsEntityDebugView : MonoBehaviour {
        [NonSerialized]
        public EcsWorld World;
        [NonSerialized]
        public int Entity;
        [NonSerialized]
        public EcsWorldDebugSystem DebugSystem;
    }
}
#endif