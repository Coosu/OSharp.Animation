using System;
using System.Collections.Generic;

namespace OSharp.Animation
{
    internal class InternalTransformableObject<T1, T2> : ITransformable<T1, T2> where T1 : struct where T2 : struct
    {
        internal readonly Dictionary<TransformType, List<TransformAction<T1>>> TransformDictionary =
            new Dictionary<TransformType, List<TransformAction<T1>>>();

        public void Fade(Easing easing, T1 startTime, T1 endTime, T2 startOpacity, T2 endOpacity)
        {
            const TransformType type = TransformType.Fade;
            AddKey(type);
            TransformDictionary[type].Add(new TransformAction<T1>(easing, startTime, endTime, startOpacity, endOpacity));
        }

        public void Rotate(Easing easing, T1 startTime, T1 endTime, T2 startDeg, T2 endDeg)
        {
            const TransformType type = TransformType.Rotate;
            AddKey(type);
            TransformDictionary[type].Add(new TransformAction<T1>(easing, startTime, endTime, startDeg, endDeg));
        }

        public void Move(Easing easing, T1 startTime, T1 endTime, Vector2<T2> startPos, Vector2<T2> endPos)
        {
            const TransformType type = TransformType.Move;
            AddKey(type);
            TransformDictionary[type].Add(new TransformAction<T1>(easing, startTime, endTime, startPos, endPos));
        }

        public void ScaleVec(Easing easing, T1 startTime, T1 endTime, Vector2<T2> startSize, Vector2<T2> endSize)
        {
            const TransformType type = TransformType.ScaleVec;
            AddKey(type);
            TransformDictionary[type].Add(new TransformAction<T1>(easing, startTime, endTime, startSize, endSize));
        }

        public void Color(Easing easing, T1 startTime, T1 endTime, Vector3<T2> startColor, Vector3<T2> endColor)
        {
            const TransformType type = TransformType.Color;
            AddKey(type);
            TransformDictionary[type].Add(new TransformAction<T1>(easing, startTime, endTime, startColor, endColor));
        }

        public void Blend(T1 startTime, T1 endTime, BlendMode mode)
        {
            const TransformType type = TransformType.Blend;
            AddKey(type);
            TransformDictionary[type].Add(new TransformAction<T1>(Easing.Linear, startTime, endTime, mode, mode));
        }

        public void Flip(T1 startTime, T1 endTime, FlipMode mode)
        {
            const TransformType type = TransformType.Flip;
            AddKey(type);
            TransformDictionary[type].Add(new TransformAction<T1>(Easing.Linear, startTime, endTime, mode, mode));
        }

        private void AddKey(TransformType type)
        {
            if (!TransformDictionary.ContainsKey(type))
            {
                TransformDictionary.Add(type, new List<TransformAction<T1>>());
            }
        }
    }
}