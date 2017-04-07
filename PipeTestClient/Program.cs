using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipeTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkClient client = new LinkClient();

            client.Start();

            GetDevices(client);

            //GetDeviceSensors(client, "vid<1b1c>pid<000c0b>serial<454CA1A8>index<0>");

            //SetAntiguaRainbowAllLedStrip(client);
            //WaitEnter();
            //SetAntiguaDefaultLedStrip(client);

            //SetAntiguaRainbowAllHdFan(client);
            //WaitEnter();
            //SetAntiguaDefaultHdFan(client);

            //SetAntiguaRainbowAllSpFan(client);
            //WaitEnter();
            //SetAntiguaDefaultSpFan(client);

            //"vid<1b1c>pid<000c0b>serial<454CA1A8>index<0>"

            //SetCoolitFanQuiet(client);
            ////WaitEnter();
            //SetCoolitFanMax(client);
            ////WaitEnter();
            //SetCoolitFan500Rpm(client);
            ////WaitEnter();
            //SetCoolitFan100Pwm(client);
            ////WaitEnter();
            //SetCoolitFanCustom(client);
            //WaitEnter();
            //new GetDevicesTest().RunTest(client);

            //new GetDeviceSensorsTest().RunTest(client);

            //new GetSensorValuesTest().RunTest(client);

            //new GetSensorLastValues().RunTest(client);
            //GetDevices(client);

            //GetDeviceSensors(client, "vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>");

            //SetCoolitPumpQuiet(client);
            //WaitEnter();
            //SetCoolitPumpPerfomance(client);
            //WaitEnter();
            //SetCoolitLedOn(client, "#ff0000");


            //GetSensors(client, "vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>");

            ////SetAsetekLedOn(client);
            ////Console.ReadKey();
            ////SetAsetekLedOff(client);

            ////SetAsetekPumpQuiet(client);
            ////Console.ReadKey();
            ////SetAsetekPumpPerfomance(client);


            //SetAsetekFanQuiet(client);
            //Console.ReadKey();
            //SetAsetekFanMax(client);
            //Console.ReadKey();
            //SetAsetekFanFixed(client);
            //Console.ReadKey();
            //SetAsetekFanCustom(client);


            //client.Send(new Request
            //{
            //    MethodName = "cl.device.get-device-sensors",
            //    Number = 2,
            //    Params = new[]
            //    {
            //        //"vid<1b1c>pid<000c10>serial<503311A8>index<0>"
            //       //"vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&F9B17DA&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>"
            //       //"vid<1b1c>pid<001c06>serial<\\\\.\\HID#VID_1B1C&PID_1C06#6&186B1056&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}>index<0>"
            //       //"vid<1b1c>pid<001c0b>serial<\\\\.\\HID#VID_1B1C&PID_1C0B#6&3A9DC741&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}>index<0>"
            //       //"vid<1b1c>pid<000002>serial<1>index<0>"
            //       //"vid<1b1c>pid<000001>serial<0>index<0>"
            //    }
            //});

            //Thread.Sleep(2000);

            //client.Send(new Request
            //{
            //    MethodName = "cl.sensor.get-values",
            //    Number = 3,
            //    Params = new[]
            //    {

            //        @"vid<1b1c>pid<0c043b>serial<\\.\HID#VID_1B1C&PID_0C04#6&F9B17DA&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<1>"
            //}
            //});

            //while (true)
            //{
            //    Console.WriteLine("Press key:");
            //    Console.ReadKey();
            //    NewMethod(client, "#ff0000");
            //    Console.WriteLine("Press key:");
            //    Console.ReadKey();
            //    NewMethod(client, "#00ff00");
            //    Console.WriteLine("Press key:");
            //    Console.ReadKey();
            //    NewMethod(client, "#0000ff");
            //}

            //Thread.Sleep(2000);

            //client.Send(new Request
            //{
            //    MethodName = "cl.sensor.get-last-values",
            //    Number = 3,
            //    Params = new[]
            //    {
            //        @"vid<1b1c>pid<c043b>serial<\\.\HID#VID_1B1C&PID_0C04#6&F9B17DA&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<1>"
            //    }
            //});

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }

        private static void WaitEnter()
        {
            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }

        private static void GetDevices(LinkClient client)
        {
            var response = client.Send("cl.device.get-list", null).GetAwaiter().GetResult();

            Console.WriteLine(response.Result.ToString());
        }

        private static void GetDeviceSensors(LinkClient client, string sensorId)
        {
            var response = client.Send("cl.device.get-device-sensors", new List<string> { sensorId }).GetAwaiter().GetResult();

            Console.WriteLine(response.Result.ToString());
        }

        private static void SetAntiguaDefaultLedStrip(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0b>serial<454CA1A8>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'led-strip',
        'brightness': 100,
        'groups': [
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            }
        ]
    },
'channel-two':
    {
        'channel-type': 'disconnected'
    }
}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetAntiguaRainbowAllLedStrip(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0b>serial<454CA1A8>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'led-strip',
        'brightness': 100,
        'groups': [
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
        ]
    },
'channel-two':
    {
        'channel-type': 'led-strip',
        'brightness': 33,
        'groups': [
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'backward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'fast',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'backward'
            },
        ]
    }
}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetAntiguaDefaultHdFan(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0b>serial<454CA1A8>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'hd-fan',
        'brightness': 100,
        'groups': [
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            }
        ]
    },
'channel-two':
    {
        'channel-type': 'disconnected'
    }
}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetAntiguaRainbowAllHdFan(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0b>serial<454CA1A8>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'hd-fan',
        'brightness': 100,
        'groups': [
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
        ]
    },
'channel-two':
    {
        'channel-type': 'hd-fan',
        'brightness': 33,
        'groups': [
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'backward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'fast',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'backward'
            },
        ]
    }
}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetAntiguaDefaultSpFan(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0b>serial<454CA1A8>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'sp-fan',
        'brightness': 100,
        'groups': [
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            }
        ]
    },
'channel-two':
    {
        'channel-type': 'disconnected'
    }
}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetAntiguaRainbowAllSpFan(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0b>serial<454CA1A8>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'sp-fan',
        'brightness': 100,
        'groups': [
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
        ]
    },
'channel-two':
    {
        'channel-type': 'sp-fan',
        'brightness': 33,
        'groups': [
            {
                'group-type': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'backward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'fast',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'forward'
            },
            {
                'group-type': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'backward'
            },
        ]
    }
}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitPumpQuiet(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Pump>sensindex<2>",
            "{'mode': 'quiet'}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitPumpPerfomance(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Pump>sensindex<2>",
            "{'mode': 'perfomance'}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFanQuiet(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'quiet'}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFanMax(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'max'}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFan500Rpm(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'fixed-rpm', 'rpm': 500}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFan100Pwm(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'fixed-pwm', 'percents': 100}");

            client.Send("cl.sensor.set-values", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFanCustom(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'custom', 'points-rpms': [1000, 1100, 1200, 1300, 1400], 'points-temperatures': [30, 40, 50, 60, 70]}");

            client.Send("cl.sensor.set-values", param).Wait();
        }

        private static void SetCoolitLedOn(LinkClient client, string color)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Led>sensindex<0>",
            "{'mode': 'static','colors': ['" + color + "']}");

            client.Send("cl.sensor.set-values",param).Wait();
        }

        private static void SetAsetekLedOn(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Led>sensindex<0>",
            "{'color': '#ff0000','warning-color': '#00ff00', 'temperature': 40}");

            client.Send("cl.sensor.set-values", param).Wait();
        }

        private static void SetAsetekLedOff(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Led>sensindex<0>",
            "{}");

            client.Send("cl.sensor.set-values", param).Wait();
        }

        private static void SetAsetekPumpQuiet(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Pump>sensindex<0>",
            "{'mode': 'quiet'}");

            client.Send("cl.sensor.set-values", param).Wait();
        }

        private static void SetAsetekPumpPerfomance(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Pump>sensindex<0>",
            "{'mode': 'perfomance'}");

            client.Send("cl.sensor.set-values", param).Wait();
        }

        private static void SetAsetekFanQuiet(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'quiet'}");

            client.Send("cl.sensor.set-values", param).Wait();
        }

        private static void SetAsetekFanMax(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'max'}");

            client.Send("cl.sensor.set-values", param).Wait();
        }

        private static void SetAsetekFanFixed(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'fixed', 'percents': 40}");

            client.Send("cl.sensor.set-values", param).Wait();
        }

        private static void SetAsetekFanCustom(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'custom', 'points-percents': [40, 50, 60, 70, 80, 90], 'points-temperatures': [30, 40, 50, 60, 70, 80]}");

            client.Send("cl.sensor.set-values", param).Wait();
        }
    }
}
