using System;

namespace pattern_state
{
    public class StoppedState : StopWatchState
    {
        public StopWatchStatePt StopWatch { get; }
        public StoppedState(StopWatchStatePt stopwatch)
        {
            this.StopWatch = stopwatch;
        }
        public void Click()
        {
            StopWatch.CurrentState = new RunningState(StopWatch);
            Console.WriteLine("Running");
        }
    }
}