using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSharp.Animation
{
    public interface ITransformable<T1, T2> where T1 : struct where T2 : struct
    {
        void Fade(Easing easing, T1 startTime, T1 endTime, T2 startOpacity, T2 endOpacity);
        void Rotate(Easing easing, T1 startTime, T1 endTime, T2 startDeg, T2 endDeg);

        void Move(Easing easing, T1 startTime, T1 endTime, Vector2<T2> startPos, Vector2<T2> endPos);
        void ScaleVec(Easing easing, T1 startTime, T1 endTime, Vector2<T2> startSize, Vector2<T2> endSize);
        void Color(Easing easing, T1 startTime, T1 endTime, Vector3<T2> startColor, Vector3<T2> endColor);

        void Blend(T1 startTime, T1 endTime, BlendMode mode);

        void Flip(T1 startTime, T1 endTime, FlipMode mode);
    }
}
