using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace RobotControl.Data
{
    public static class RobotSteering

    {
        private static Dictionary<string, string> DataPackage = new Dictionary<string, string>() { { "mode", "idle" }, { "command", "stop" }, { "angle", "0" }, { "step", "0" } };

        private static HttpClient httpClient = new HttpClient()
        {

        };
        public static async void SendCommands()
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(DataPackage), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync("https://localhost:44360/Robot/SetCommands", content);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
        public static void SetMode(string mode)
        {
            DataPackage["mode"] = mode;
            SendCommands();

        }
        public static void SetDirectionGrid(string direction, string distance)
        {
           // DataPackage["mode"] = "movestep";
            DataPackage["command"] = direction;
            DataPackage["step"] = distance;
            SendCommands();
        }

        public static void SetMoveSmooth(string direction)
        {
           // DataPackage["mode"] = "movesmooth";
            DataPackage["command"] = direction;
            SendCommands();
        }

        public static void RadarScan()
        {
            DataPackage["mode"] = "radarscan";
        }

        public static void MoveAvoidObstacles()
        {
            DataPackage["mode"] = "avoidobstacles";
        }
        public static void MoveStop()
        {
            DataPackage["command"] = "stop";
            SendCommands();
        }


        //44360

    }
}
