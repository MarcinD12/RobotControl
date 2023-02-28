namespace RobotControl.Data
{
    public static class RobotCommands
    {
        static HttpClient httpClient= new HttpClient();
        public static  void  SendCommand(string command)
        {
             Console.WriteLine("command set to: "+command);
            var content=new  StringContent(command);
            httpClient.PutAsync($"https://localhost:44360/Robot/SetCommand?command={command}", content);

        }


    }
}
