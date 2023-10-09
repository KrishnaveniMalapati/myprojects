namespace MSys.Library.Logger.Interface
{
    public static class ObjectFactory
    {
        public static T GetInstance<T>(this T instance)
        {
            if (instance != null) return instance;

            switch (typeof(T).Name)
            {
                case nameof(ILoggerService): return (T)(object)CustomLoggerService.Instance;
                default:
                    throw new NotSupportedException($"Type {typeof(T)} is not supported for GetInstance.");
            }
        }
    }
}
