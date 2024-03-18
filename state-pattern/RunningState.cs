using System;

namespace pattern_state
{
    public class RunningState : StopWatchState
    {
        public StopWatchStatePt StopWatch { get; }
        public RunningState(StopWatchStatePt stopWatch)
        {
            this.StopWatch = stopWatch;
        }
        public void Click()
        {
            StopWatch.CurrentState = new StoppedState(StopWatch);
            Console.WriteLine("Stopped");
        }
    }
}