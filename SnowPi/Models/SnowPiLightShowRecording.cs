using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SnowPi.Models
{
    /// <summary>
    ///     Fluent interface for recording lightshows
    /// </summary>
    public class SnowPiLightShowRecording
    {
        private readonly CancellationToken _cancellationToken;
        private readonly PcQueue _queue;
        private readonly Snowman _snowPi;
        private readonly SynchronizationContext _synchronizationContext;
        private readonly CancellationTokenSource _tokenSource;

        public SnowPiLightShowRecording(Snowman snowPi) : this(snowPi, SynchronizationContext.Current)
        {
        }

        public SnowPiLightShowRecording(Snowman snowPi, SynchronizationContext synchronizationContext)
        {
            if (synchronizationContext == null)
            {
                throw new ArgumentNullException(nameof(synchronizationContext),
                    "No synchronization context was provided");
            }

            _snowPi = snowPi;
            _synchronizationContext = synchronizationContext;
            _queue = new PcQueue(1);
            _tokenSource = new CancellationTokenSource();
            _cancellationToken = _tokenSource.Token;
            _snowPi.Reset();
        }

        public SnowPiLightShowRecording TurnLedOn(Led led)
        {
            _queue.Enqueue(() => _synchronizationContext.Post(o => ToggleLed(led, true), null), _cancellationToken);
            return this;
        }

        public SnowPiLightShowRecording TurnLedOff(Led led)
        {
            _queue.Enqueue(() => _synchronizationContext.Post(o => ToggleLed(led, false), null), _cancellationToken);
            return this;
        }

        public SnowPiLightShowRecording PauseForSeconds(int seconds)
        {
            PauseForMilliseconds(1000*seconds);
            return this;
        }

        public SnowPiLightShowRecording PauseForMilliseconds(int milliseconds)
        {
            _queue.Enqueue(() => { Task.Delay(milliseconds).Wait(); }, _cancellationToken);
            return this;
        }

        public void CancelShow()
        {
            _tokenSource.Cancel();
        }

        private void ToggleLed(Led led, bool turnOn)
        {
            switch (led)
            {
                case Led.One:
                    _snowPi.LedOneSet = turnOn;
                    break;
                case Led.Two:
                    _snowPi.LedTwoSet = turnOn;
                    break;
                case Led.Three:
                    _snowPi.LedThreeSet = turnOn;
                    break;
                case Led.Four:
                    _snowPi.LedFourSet = turnOn;
                    break;
                case Led.Five:
                    _snowPi.LedFiveSet = turnOn;
                    break;
                case Led.Six:
                    _snowPi.LedSixSet = turnOn;
                    break;
                case Led.Seven:
                    _snowPi.LedSevenSet = turnOn;
                    break;
                case Led.Eight:
                    _snowPi.LedEightSet = turnOn;
                    break;
                case Led.Nine:
                    _snowPi.LedNineSet = turnOn;
                    break;
                default:
                    throw new NotSupportedException("Unsupported LED value");
            }
        }

        // Based on code from C# 6.0 in a Nutshell by Joseph Albahari and Ben Albahari (O’Reilly). Copyright 2016 Joseph Albahari and Ben Albahari, 978-1-491-92706-9
        private class PcQueue : IDisposable
        {
            private readonly BlockingCollection<Task> _taskQ = new BlockingCollection<Task>();

            public PcQueue(int workerCount)
            {
                // Create and start a separate Task for each consumer:
                for (var i = 0; i < workerCount; i++)
                    Task.Factory.StartNew(Consume);
            }

            public void Dispose()
            {
                _taskQ.CompleteAdding();
            }

            public Task Enqueue(Action action, CancellationToken cancelToken
                = default(CancellationToken))
            {
                var task = new Task(action, cancelToken);
                _taskQ.Add(task);
                return task;
            }

            private void Consume()
            {
                foreach (var task in _taskQ.GetConsumingEnumerable())
                    try
                    {
                        if (!task.IsCanceled) task.RunSynchronously();
                    }
                    catch (InvalidOperationException)
                    {
                    } // Race condition
            }
        }
    }
}