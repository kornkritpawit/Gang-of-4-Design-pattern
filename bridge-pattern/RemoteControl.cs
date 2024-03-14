namespace pattern_bridge
{
    // Remote Control (TurnOn, TurnOff)
       // SonyRemoteControl
       // SamsungRemoteControl
    // Advanced Remote Control (SetChannel)
       // SonyAdvanceRemoteControl
       // SamsungAdvanceRemoteControl
    // Movie Remote Control (Play, Pause, Rewind)   
       // SonyMovieRemoteControl
       // SamsungMovieRemoteControl

    // 1 brand --> add 3 classes Samsung =>RemoteCtrl,AdvanceRemoteCtrl,MovieRemoteCtrl
    //เพิ่ม 10 brands --> add 30 classes
    public abstract class RemoteControl
    {
        public abstract void TurnOn();
        public abstract void TurnOff();
    }
}