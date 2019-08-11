namespace OSharp.Animation
{
    public struct TransformAction<T> where T : struct
    {
        public TransformAction(Easing easing, T startTime, T endTime, object startParam, object endParam)
        {
            Easing = easing;
            StartTime = startTime;
            EndTime = endTime;
            StartParam = startParam;
            EndParam = endParam;
        }

        public Easing Easing { get; set; }
        public T StartTime { get; set; }
        public T EndTime { get; set; }
        public object StartParam { get; set; }
        public object EndParam { get; set; }
    }
}