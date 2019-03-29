using System;
namespace GimbalDemo.Interface
{
    public interface IGimbalService
    {
        void Initialize(Action<string> statusAction);

        void Start();

        void Stop();
    }
}
