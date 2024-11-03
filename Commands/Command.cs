using System;

namespace Core.Core.Commands
{
    public abstract class Command
    {
        public event Action OnComplete;
        public event Action<float> OnProgress;
        public abstract void Execute();

        protected virtual void Release()
        {
            OnComplete = null;
            OnProgress = null;
        }

        protected virtual void SetProgress(float percent)
        {
            OnProgress?.Invoke(percent);    
        }
        
        protected virtual void Complete()
        {
            OnProgress?.Invoke(1f);
            OnComplete?.Invoke();
            Release();
        }
    }
}
