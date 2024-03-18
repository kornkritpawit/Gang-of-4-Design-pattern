using System;

namespace pattern_state
{
    public class StopWatchStatePt
    {
        public StopWatchState CurrentState { get; set; }
        public StopWatchStatePt()
        {
            CurrentState = new StoppedState(this);
        }
        public void Click()
        {
            CurrentState.Click();
        }
    }
}