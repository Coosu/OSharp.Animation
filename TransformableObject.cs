using System;
using System.Collections.Generic;
using System.Linq;

namespace OSharp.Animation
{
    public abstract class TransformableObject<T1, T2> where T1 : struct where T2 : struct
    {
        protected abstract void FadeAction(List<TransformAction<T1>> actions);
        protected abstract void RotateAction(List<TransformAction<T1>> actions);
        protected abstract void MoveAction(List<TransformAction<T1>> actions);
        protected abstract void ScaleVecAction(List<TransformAction<T1>> actions);
        protected abstract void ColorAction(List<TransformAction<T1>> actions);
        protected abstract void BlendAction(List<TransformAction<T1>> actions);
        protected abstract void FlipAction(List<TransformAction<T1>> actions);

        protected abstract void StartAnimation();
        protected abstract void EndAnimation();
        public void ApplyAnimation(Action<ITransformable<T1, T2>> func)
        {
            StartAnimation();
            var internalObj = new InternalTransformableObject<T1, T2>();
            func?.Invoke(internalObj);
            MinTime = internalObj.TransformDictionary.Min(k => k.Value.Min(o => o.StartTime));

            foreach (var transform in internalObj.TransformDictionary)
            {
                switch (transform.Key)
                {
                    case TransformType.Fade:
                        FadeAction(transform.Value);
                        break;
                    case TransformType.Rotate:
                        RotateAction(transform.Value);
                        break;
                    case TransformType.Move:
                        MoveAction(transform.Value);
                        break;
                    case TransformType.ScaleVec:
                        ScaleVecAction(transform.Value);
                        break;
                    case TransformType.Color:
                        ColorAction(transform.Value);
                        break;
                    case TransformType.Blend:
                        BlendAction(transform.Value);
                        break;
                    case TransformType.Flip:
                        FlipAction(transform.Value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            EndAnimation();
        }

        public T1 MinTime { get; set; }
    }
}