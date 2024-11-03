using System.Collections.Generic;

namespace Core.Core.Commands
{
    public class CommandSequence : Command
    {
        protected Queue<Command> _queue;
        private int _commandsCount;
        private int _commandsCompleted;

        public CommandSequence(params Command[] commands)
        {
            _queue = new Queue<Command>(commands);
        }
        
        public override void Execute()
        {
            _commandsCount = _queue.Count;
            _commandsCompleted = 0;
            ExecuteNextCommand();
        }

        private void ExecuteNextCommand()
        {
            var command = _queue.Dequeue();
            command.OnComplete += OnCommandComplete;
            command.OnProgress += OnCommandProgress;
            command.Execute();
        }

        private void OnCommandProgress(float percent)
        {
            var percentPerCommand = 1f / _commandsCount;
            var completedPercent = percentPerCommand * _commandsCompleted;
            float value = completedPercent + percentPerCommand * percent;
            SetProgress(value);
        }

        private void OnCommandComplete()
        {
            _commandsCompleted++;
            
            if (_queue.Count == 0)
            {
                Complete();
                return;
            }
            
            ExecuteNextCommand();
        }
    }
}