using System.Text.Json;
namespace RobotControl.Data
{
    public static class RobotCommands
    {
        static HttpClient httpClient= new HttpClient();
        public static  void  SetDirection(string command)
        {
            Console.WriteLine(DateTime.Now);
             Console.WriteLine("command set to: "+command);
            var content=new  StringContent(command);
            httpClient.PutAsync($"https://localhost:44360/Robot/SetDirection?command={command}", content);
        }
        public static void SetTurn(string direction,int angle)
        {
            Dictionary<string,string> dict = new Dictionary<string,string>();
            dict.Add("command", direction);
            dict.Add("angle", angle.ToString());
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("command set to: " + angle);
            var content = new StringContent(JsonSerializer.Serialize(dict));
            //httpClient.PutAsync($"https://localhost:44360/Robot/SetTurn?command={content}", content);
            var xd=httpClient.PutAsync($"https://localhost:44360/Robot/SetTurn?direction={direction}&angle={angle}", content).Result;
            Console.WriteLine(xd);
        }


    }
}
