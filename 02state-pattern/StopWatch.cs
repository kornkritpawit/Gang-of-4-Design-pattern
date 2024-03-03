using System;

namespace pattern_state
{
    public class StopWatch
    {
        public StopWatchState CurrentState { get; set; }
        public StopWatch()
        {
            CurrentState = new RunningState(this);
        }
        public void Click()
        {
            CurrentState.Click();
        }
    }
}