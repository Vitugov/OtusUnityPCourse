using System.Collections;

namespace ShootEmUp
{
    public interface ICoroutineLogic<T>
    {
        void Initialize(ICoroutineHandler handler, T target);
        IEnumerator Execute();
    }
}
