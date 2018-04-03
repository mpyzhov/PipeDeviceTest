using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PipeTestClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipeTestClient
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.ForegroundColor = ConsoleColor.DarkGreen;

        //    LinkClient client = new LinkClient();
        //    client.Start();

        //    if (args.Count() == 0)
        //    {
        //        GetDevices(client);
        //    }
        //    else
        //    {
        //        var methodName = args[0];

        //        switch(methodName)
        //        {
        //            case "cl.device.get-list":
                        
        //                GetDevices(client);
        //                break;
        //            case "cl.device.get-device-sensors":
        //                if (args.Length > 1)
        //                {
        //                    GetDeviceSensors(client, args[1]);
        //                }
        //                else
        //                {
        //                    Error("Argument missing");
        //                }
        //                break;
        //            case "cl.sensor.get-last-values":
        //                if (args.Length > 1)
        //                {
        //                    GetSensorsValues(client, args[1]);
        //                }
        //                else
        //                {
        //                    Error("Argument missing");
        //                }
        //                break;
        //            case "cl.sensor.set-settings":
        //                if (args.Length > 2)
        //                {
        //                    SetSensorSettings(client, args[1], args[2]);
        //                }
        //                else
        //                {
        //                    Error("Argument(s) missing");
        //                }
        //                break;
        //            default:
        //                Error("Unknown method");
        //                break;
        //        }
        //    }

        //    Console.ForegroundColor = ConsoleColor.Gray;
        //}



        private static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        private static void InfiniteCheck(string deviceId)
        {
            LinkClient client = null;
            while (true)
            {
                bool isFirst = client == null;
                client = new LinkClient();
                try
                {
                    client.Start();

                    if(isFirst && deviceId == null)
                    {
                        GetDevices(client);
                        Console.WriteLine("Enter device id: ");
                        deviceId = Console.ReadLine().Trim();
                    }

                    
                    while (true)
                    {
                        if (!Console.KeyAvailable)
                        {
                            Console.Clear();
                            GetDevices(client);
                            Console.WriteLine();
                            Console.WriteLine("info for " + deviceId + ":");
                            GetDeviceSensors(client, deviceId);
                            Thread.Sleep(2000);
                        }
                        else
                        {
                           if(Console.ReadKey(true).Key == ConsoleKey.Escape)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter device id: ");
                                deviceId = Console.ReadLine().Trim();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        static void Main(string[] args)
        {
            //InfiniteCheck(null);// "vid<1b1c>pid<000c13>serial<4660;7289_2.0>index<0>");
            LinkClient client = new LinkClient();

            client.Start();

            //SaveToDevice(client);

            //TypeAndFun(client);

            //SetAsetekPumpPerfomance(client);
            //SetStarcoolerLedOn(client);
            //SetupDebugFolder(client);
            //SetupDebugServiceInteraction(client);

            //SetBarbudaFwUpdate(client);

            //SuppressNotification(client);

            //var res = client.ReadRequest().GetAwaiter().GetResult();

            //Console.WriteLine(res.ToString());

            //Console.ReadLine();

            //res = client.ReadRequest().GetAwaiter().GetResult();

            //Console.WriteLine(res.ToString());

            //Console.ReadLine();

            //TypeAndFun(client);

            //SetJotunDefaultLedStrip(client);
            //while (true)
            //{
            //    Console.Clear();
            //    Re(client);
            //    Thread.Sleep(1000);
            //}

            //Stopwatch sw = new Stopwatch();
            //double avgFps = 0;
            //double count = 0;

            //int r = 10;

            ////while (true)
            ////{
            ////    //sw.Restart();
            //GetDevices(client);

            UpdateFirmwareStarcooler(client);

            while (true)
            {
                var r = client.ReadRequest().GetAwaiter().GetResult();
                if (r != null)
                    Console.WriteLine(r.Params.ToString());
            }
            //SetBarbudaFanCustom(client, "vid<1b1c>pid<001d00>serial<179F35BC>index<0>senstype<Fan>sensindex<3>");
            //SetJotunTestMlFan(client);

            //TypeAndFun(client);

            //GetDeviceSensors(client, "vid<1b1c>pid<001d00>serial<179F35BC>index<0>");
            ////    GetDeviceSensors(client, "vid<1b1c>pid<000c0b>serial<12C37083>index<0>");
            ////    //sw.Stop();
            ////    //double fps = 1000.00 / (sw.ElapsedMilliseconds != 0 ? sw.ElapsedMilliseconds : 1);

            ////    //avgFps = (fps + (avgFps * count)) / (count + 1);
            ////    //count++;
            ////    //if (r-- == 0)
            ////    //{
            ////    //    r = 10;
            ////    //    Console.Clear();
            ////    //}
            ////    //Console.WriteLine("Time: " + sw.ElapsedMilliseconds);
            ////}

            //TypeAndFun(client);

            //SetAsetekLedOn(client);

            //SaveToDevice(client);
            //UpdateFirmwareAntigua(client);
            //GetDeviceSensors(client, "vid<1b1c>pid<001c11>serial<ar5w2>index<0>");

            //while (true)
            //{
            //SwitchToHardware(client);
            //SetStarcoolerLedOn(client);
            //SetTempNotification1(client);
            //while (true)
            //{

            //    SuppressNotification(client);
            //    Console.WriteLine("{0} Suppress", DateTime.Now.ToLongTimeString());

            //    client.ReadRequest().GetAwaiter().GetResult();
            //    Console.WriteLine("{0} Readed", DateTime.Now.ToLongTimeString());
            //}


            // Thread.Sleep(20000);
            //}

            //UpdateFirmwareBarbuda(client);



            //TypeAndFun(client);
            //SetPulseDram(client);
            //Console.WriteLine("Pulse. Press enter for next...");
            //Console.ReadLine();

            //SetShiftDram(client);
            //Console.WriteLine("Shift. Press enter for next...");
            //Console.ReadLine();

            //SetRainbowDram(client);
            //Console.WriteLine("Rainbow. Press enter for next...");
            //Console.ReadLine();
            //while (true)
            //{
            //    Console.Clear();
            //    GetDeviceSensors(client, "vid<1b1c>pid<000c10>serial<B373D412>index<0>");
            //    Thread.Sleep(500);
            //}

            //SetAxiFanMax(client);
            //Console.WriteLine("Max. Press enter");
            //Console.ReadLine();
            //SetAxiFanDefault(client);
            //Console.WriteLine("Default. Press enter");
            //Console.ReadLine();
            //SetAxiFanCustom(client);
            //Console.WriteLine("Custom. Press enter");
            //Console.ReadLine();



            //SetAxiFanCustom(client);
            //SetAxiOCPMode(client);
            //SetAxiFanDefault(client);


            //SetAxiOCPMode(client);
            //SetRainbowDram(client);

            //SetTempNotification1(client);

            //SetCoolitLedOn(client);
            //GetDeviceSensors(client, "vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2254C87F&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>");

            //SetAsetekFanQuiet(client);
            //SetAntiguaStripExternalFan(client);
            //SetCoolitLedTemp(client);

            //SetCoolitFanQuietExternal(client);
            //SetCoolitLedTemp(client);
            //SetAntiguaDirectLight(client);

            //SetTempNotification(client);

            //SetTempNotification1(client);
            //Console.ReadLine();

            //SetTempNotification2(client);
            //Console.ReadLine();

            //SuppressNotification(client);
            //Console.ReadLine();

            //while (true)
            //{
            //    Console.ReadLine();

            //    SuppressNotification(client);
            //}

            //var resp = client.ReadRequest().GetAwaiter().GetResult();

            //Console.WriteLine(resp.ToString());

            //GetDeviceSensors(client, "vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&F9B17DA&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>");
            //"vid<1b1c>pid<000002>serial<1>index<0>senstype<Temperature>sensindex<0>"

            //SetRainbowDram(client);


            //SetTempNotification(client);

            //SetTempNotificationOff(client);
            //SuppressNotification(client);


            //while (true)
            //{
            //    //SetTempNotification(client);
            //    //Thread.Sleep(1000);
            //    //
            //    Console.ReadLine();
            //    SetTempNotificationOff(client);
            //    SuppressNotification(client);
            //    //Thread.Sleep(1000);
            //}
            //SetH80Test2(client);

            //Thread.Sleep(5000);

            //SetH80Test(client);
            //GetDeviceSensors(client, "vid<1b1c>pid<001c00>serial<r5460267>index<0>");
            //SetRainbowDram(client);
            //SetDefaultDram(client);

            //Thread.Sleep(5000);
            //SetDefaultDram(client);

            //GetDeviceSensors(client, "vid<1b1c>pid<000004>serial<CMU16GX4M2C3000C15>index<0>");
            //GetDeviceSensors(client, "vid<1b1c>pid<000004>serial<CMK16GX4M4C3200C16>index<0>");
            //GetDeviceSensors(client, "vid<1b1c>pid<000004>serial<CMK16GX4M4C3200C16>index<1>");
            //GetDeviceSensors(client, "vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<0>");
            //GetDeviceSensors(client, "vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<1>");
            //GetDeviceSensors(client, "vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<2>");
            //GetDeviceSensors(client, "vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<3>");
            //GetDeviceSensors(client, "vid<1b1c>pid<000c10>serial<84F602E0>index<0>");
            //TypeAndFun(client);

            //Console.ReadLine();

            //SetAntiguaDefaultLedStrip(client);

            //GetSensorsValue(client, "vid<1b1c>pid<000001>serial<0>index<0>senstype<Fan>sensindex<1>");

            //GetDeviceSensors(client, "vid<1b1c>pid<000c10>serial<A9BB679F>index<0>");

            //"vid<1b1c>pid<000c10>serial<A9BB679F>index<0>"

            //var response = client.Send("cl.sensor.get-last-values", new[]
            //    {
            //        @"vid<1b1c>pid<000c10>serial<A9BB679F>index<0>senstype<Temperature>sensindex<1>"
            //    }).GetAwaiter().GetResult();

            //Console.WriteLine(response.Result.ToString());

            //DateTime start = DateTime.Now;
            //var limit = TimeSpan.FromMilliseconds(1000);

            //int count = 0;

            //while (DateTime.Now - start < limit)
            //{
            //    SetAntiguaDirectLight(client);
            //    count++;
            //}

            //Console.WriteLine(count);

            //GetDeviceSensors(client, "vid<1b1c>pid<000c10>serial<A6D9D5BE>index<0>");

            //SetTempNotification(client);
            //WaitEnter();
            //SuppressNotification(client);


            //SetBarbudaFanQuiet(client);
            //WaitEnter();
            //SetBarbudaFanMax(client);

            //SetBarbudaRainbowAllLedStrip(client);
            //WaitEnter();
            //SetBarbudaDefaultLedStrip(client);

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

        private static void SendEffect(LinkClient client)
        {

        }

        private static void TypeAndFun(LinkClient client)
        {
            colors = Enumerable.Repeat<string>("#000000", 96).ToList();

            //int count = 300;

            try
            {
                var v = Observable.Interval(TimeSpan.FromMilliseconds(1000 / 25), Scheduler.Immediate).Subscribe((s) =>
                {
                    lock (sendLocker)
                    {
                        SetAntiguaDirectLightType(client, "vid<1b1c>pid<001d00>serial<401C4D58>index<0>senstype<Led>sensindex<0>");
                        //SetAntiguaDirectLightType(client, "vid<1b1c>pid<000c10>serial<46CA42AB>index<0>senstype<Led>sensindex<0>");
                        //SetAntiguaDirectLightType(client, "vid<1b1c>pid<000c10>serial<FE0AB5FC>index<0>senstype<Led>sensindex<0>");

                        //SetAntiguaDirectLightType(client,
                        //    "vid<1b1c>pid<000c0b>serial<12C37083>index<0>senstype<Led>sensindex<0>",
                        //    "vid<1b1c>pid<000c10>serial<46CA42AB>index<0>senstype<Led>sensindex<0>",
                        //    "vid<1b1c>pid<000c10>serial<FE0AB5FC>index<0>senstype<Led>sensindex<0>");
                       // SetStarCoolerDirectLightType(client, "vid<1b1c>pid<000c13>serial<4660;7289_2.0>index<0>senstype<Led>sensindex<0>");
                    }
                });
            }
            catch(Exception ex)
            {

            }

            //bool isMax = false;
            //Observable.Interval(TimeSpan.FromMilliseconds(1488 * 3)).Subscribe((s) =>
            //{
            //    lock (sendLocker)
            //    {
            //        if (isMax)
            //        {
            //            SetBarbudaFanCustom(client,
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<0>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<1>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<2>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<3>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<4>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<5>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<1>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<2>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<3>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<4>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<5>");
            //        }
            //        else
            //        {
            //            SetBarbudaFanMax(client,
            //               "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<0>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<1>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<2>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<3>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<4>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<5>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<1>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<2>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<3>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<4>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<5>");
            //        }

            //        isMax = !isMax;
            //    }
            //});

            //Observable.Interval(TimeSpan.FromMilliseconds(1000)).Subscribe((s) =>
            //{
            //    lock (sendLocker)
            //    {
            //        Console.Clear();
            //        GetSensorsValue(client,
            //                   "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<0>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<1>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<2>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<3>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<4>",
            //                "vid<1b1c>pid<001d00>serial<33D09E04>index<0>senstype<Fan>sensindex<5>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<1>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<2>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<3>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<4>",
            //                "vid<1b1c>pid<000c10>serial<A453C125>index<0>senstype<Fan>sensindex<5>");
            //    }
            //});

            //while (true)
            //{
            //    Console.ReadKey();
            //    lock (locker)
            //    {
            //        colors[0] = "#ff0000";
            //    }
            //}
        }

        static object locker = new object();
        static List<string> colors = new List<string>();

        static int r = 0;
        static int g = 0;
        static int b = 0;
        static int step = 5;
        static bool isup = true;
        private static void Color(int rr, int gg, int bb)
        {
            colors.Insert(0, string.Format("#{0:x2}{1:x2}{2:x2}", rr, gg, bb));
        }

        private static void SetColor(int rr, int gg, int bb)
        {
            color = string.Format("#{0:x2}{1:x2}{2:x2}", rr, gg, bb);
        }

        private static void SetAntiguaDirectLightType(LinkClient client, params string[] ids)
        {
            try
            {
                lock (locker)
                {
                    colors.RemoveAt(colors.Count - 1);

                    if (r < 256)
                    {
                        Color(r, 0, 0);
                        r += step;
                    }
                    else if (g < 256)
                    {
                        Color(0, g, 0);
                        g += step;
                    }
                    else if (b < 256)
                    {
                        Color(0, 0, b);
                        b += step;
                    }
                    else
                    {
                        r = g = b = 0;
                        Color(0, 0, 0);

                        if (step == 5)
                        {
                            isup = true;
                        }
                        else if (step == 20)
                        {
                            isup = false;
                        }

                        step = step + (isup ? 1 : -1);
                    }
                }

                var param = new Dictionary<string, string>();

                var str2 = string.Format("'channel-one': {{'channel-type': 'hd-fan', 'colors': ['{0}']}}, 'channel-two': {{'channel-type': 'hd-fan', 'colors': ['{0}']}}", string.Join("', '", colors.ToArray()));

                foreach (var id in ids)
                {
                    param.Add(id, "{" + str2 + "}");
                }
                

                client.Send("cl.sensor.set-direct-light", param).GetAwaiter().GetResult();
            }
            catch(Exception ex)
            {

            }
        }

        static string color = "#000000";

        private static void SetStarCoolerDirectLightType(LinkClient client, params string[] ids)
        {
            try
            {
                lock (locker)
                {
                    if (r < 256)
                    {
                        SetColor(r, 0, 0);
                        r += step;
                    }
                    else if (g < 256)
                    {
                        SetColor(0, g, 0);
                        g += step;
                    }
                    else if (b < 256)
                    {
                        SetColor(0, 0, b);
                        b += step;
                    }
                    else
                    {
                        r = g = b = 0;
                        SetColor(0, 0, 0);

                        if (step == 5)
                        {
                            isup = true;
                        }
                        else if (step == 20)
                        {
                            isup = false;
                        }

                        step = step + (isup ? 1 : -1);
                    }
                }

                var param = new Dictionary<string, string>();

                var str2 = string.Format("'led-color': '{0}'", color);

                foreach (var id in ids)
                {
                    param.Add(id, "{" + str2 + "}");
                }


                client.Send("cl.sensor.set-direct-light", param).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {

            }
        }
        static object sendLocker = new object();

        private static void WaitEnter()
        {
            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }

        private static void GetDevices(LinkClient client)
        {
            var response = client.Send("cl.device.get-list", null).GetAwaiter().GetResult();

            Console.WriteLine(response.Result.ToString());
            //JArray resp = JArray.Parse(response.Result.ToString());

            //List<Tuple<string, string>> str = new List<Tuple<string, string>>();

            //int longest = 0;

            //foreach(var r in resp)
            //{
            //    string id = "";
            //    string name = "";
            //    foreach (dynamic p in r)
            //    {
            //        if (p.Name == "id")
            //        {
            //            id  = p.Value;
            //        }
            //        if (p.Name == "device-name")
            //        {
            //            name = p.Value;
            //        }
            //    }
            //    str.Add(new Tuple<string, string>(id, name));
            //}

            //var l = str.OrderBy(s => s.Item1.Length).LastOrDefault();
            //longest = l != null ? l.Item1.Length : 0;

            //str.OrderBy(s => s).ToList().ForEach(s =>
            //{
            //    Console.Write(s.Item1);
            //    Console.Write(string.Join("", Enumerable.Repeat(" ", longest - s.Item1.Length + 2)) + "=> ");
            //    Console.WriteLine(s.Item2);
            //});

            //dynamic dyn = JsonConvert.DeserializeObject(response.Result.ToString());
        }

        private static void GetDeviceSensors(LinkClient client, string sensorId)
        {
            var response = client.Send("cl.device.get-device-sensors", new List<string> { sensorId }).GetAwaiter().GetResult();

            Console.WriteLine(response.Result.ToString());

            JObject resp = JObject.Parse(response.Result.ToString());

            List<string> str = new List<string>();

            foreach (var d in resp)
            {
                
                foreach (dynamic a in d.Value)
                {
                    string res = "";
                    foreach (dynamic r in a)
                    {
                        if (r.Name == "sensor-type")
                        {
                            res += r.Value;
                            res += string.Join("", Enumerable.Repeat(" ", 17 - res.Length)) + "=> ";
                        }
                        if (r.Name == "value")
                        {
                            res += r.Value;
                        }
                    }
                    str.Add(res);
                }
                
            }

            str.ToList().ForEach(s => Console.WriteLine(s));
        }

        private static void GetSensorsValues(LinkClient client, params string[] sensorIds)
        {
            var response = client.Send("cl.sensor.get-last-values", sensorIds.ToList()).GetAwaiter().GetResult();

            Console.WriteLine(response);
        }

        private static void SetBarbudaFwUpdate(LinkClient client)
        {
            string param = "{ 'device-id': 'vid<1b1c>pid<000c10>serial<C6FFA3DB>index<0>', 'path':'D:\\\\ccc.txt' }";
            client.Send("cl.device.fw-update", param).GetAwaiter().GetResult();
        }

        private static void SetTempNotification1(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<001c11>serial<ar5w2>index<0>senstype<Temperature>sensindex<0>",//,
            "{'fans-action':{'active':true,'value':25},'file-action':{'active':false,'path':'C:\\\\Users\\\\maxym.pyzhov\\\\Desktop\\\\ff0000.docx','value':10},'leds-action':{'active':true,'color':'#00ff00','value':25},'shutdown-action':{'active':false,'timeout':0,'value':20}}");

            client.Send("cl.sensor.set-notifications", param).GetAwaiter().GetResult();
        }
        private static void SetTempNotification2(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Temperature>sensindex<0>",//,
            "{'fans-action':{'active':false,'value':21},'file-action':{'active':false,'path':'','value':21},'leds-action':{'active':false,'color':'#ff0000','value':21},'shutdown-action':{'active':false,'timeout':0,'value':21}}");

            client.Send("cl.sensor.set-notifications", param).GetAwaiter().GetResult();
        }

        private static void SetTempNotificationOff(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&F9B17DA&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",//"vid<1b1c>pid<000002>serial<1>index<0>senstype<Temperature>sensindex<0>",
            "{'max-value': 1000, 'action': 'none', 'led-color': '#ff0000'}");

            client.Send("cl.sensor.set-notifications", param).GetAwaiter().GetResult();
        }

        private static void SuppressNotification(LinkClient client)
        {
            client.Send("cl.notification.suppress", null).GetAwaiter().GetResult();
        }

        private static void SetBarbudaFanQuiet(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c10>serial<A6D9D5BE>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'fixed-percentage', 'percents': 0}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetBarbudaFanCustom(LinkClient client, params string[] ids)
        {
            var param = new Dictionary<string, string>();

            foreach (var id in ids)
            {
                param.Add(id, "{'mode': 'custom'}");

            }

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetBarbudaFanMax(LinkClient client, params string[] ids)
        {
            var param = new Dictionary<string, string>();

            foreach (var id in ids)
            {
                param.Add(id, "{'mode': 'max'}");
            }

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static byte value = 0;
        private static bool up = true;

        private static void SetAntiguaDirectLight(LinkClient client)
        {
            List<string> colors = Enumerable.Repeat<string>("#000000", 50).ToList();

            var start = value / 5 - 5;
            for (int i = start; i < start + 5; i++)
            {
                if (start >= 0)
                {
                    colors[i] = string.Format("#{0:x2}{1:x2}{2:x2}", value, (byte)(250 - value), 0);
                }
            }

            if (value == 250)
            {
                up = false;
            }
            else if (value == 0)
            {
                up = true;
            }

            if (up)
                value += 25;
            else
                value -= 25;


            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0b>serial<A8E17CE4>index<0>senstype<Led>sensindex<0>",
            "{ 'channel-one': ['" + string.Join("', '", colors) + 
            "'], 'channel-two': ['" + string.Join("', '", colors)+ "']}");

            client.Send("cl.sensor.set-direct-light", param).GetAwaiter().GetResult();
        }
        

        private static void SetJotunDefaultLedStrip(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<001d00>serial<29C71BA7>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'led-strip',
        'brightness': 100,
        'groups': [
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward',
                'group-type': 'logo-led'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward',
                'group-type': 'io-led'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
        ]
    },
'channel-two':
    {
        'channel-type': 'disconnected'
    }
}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }
        private static void SetBarbudaDefaultLedStrip(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0b>serial<A179A60>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'led-strip',
        'brightness': 100,
        'groups': [
            {
                'group-mode': 'rainbow-wave',
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

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetBarbudaRainbowAllLedStrip(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c10>serial<A6D9D5BE>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'led-strip',
        'brightness': 100,
        'groups': [
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
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
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'backward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'fast',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'backward'
            },
        ]
    }
}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetAntiguaDefaultLedStrip(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0b>serial<A8E17CE4>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'led-strip',
        'brightness': 100,
        'groups': [
            {
                'group-mode': 'rainbow-wave',
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

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
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
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
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
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'backward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'fast',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'backward'
            },
        ]
    }
}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
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
                'group-mode': 'rainbow-wave',
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

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
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
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
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
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'backward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'fast',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'backward'
            },
        ]
    }
}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetJotunTestMlFan(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<001d00>serial<401C4D58>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-two': 
    {
        'channel-type': 'ml-fan',
        'brightness': 100,
        'groups': [
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            }
        ]
    },
'channel-one':
    {
        'channel-type': 'ml-fan',
        'brightness': 100,Ty
        'groups': [
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward',
                'group-type': 'logo-led'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward',
                'group-type': 'io-led'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            }
        ]
    }
}");
            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
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
                'group-mode': 'rainbow-wave',
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

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
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
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
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
                'group-mode': 'rainbow-wave',
                'speed': 'middle',
                'direction': 'backward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'fast',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'forward'
            },
            {
                'group-mode': 'rainbow-wave',
                'speed': 'slow',
                'direction': 'backward'
            },
        ]
    }
}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitPumpQuiet(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Pump>sensindex<2>",
            "{'mode': 'quiet'}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitPumpPerfomance(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Pump>sensindex<2>",
            "{'mode': 'perfomance'}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFanQuiet(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'quiet'}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFanMax(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'max'}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFan500Rpm(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'fixed-rpm', 'rpm': 500}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFan100Pwm(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c0442>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2E489184&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'fixed-pwm', 'percents': 100}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        

        private static void SetAxiFanDefault(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<001c06>serial<\\\\.\\HID#VID_1B1C&PID_1C06#6&38396FF0&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'default'}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetAxiFanMax(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<001c06>serial<\\\\.\\HID#VID_1B1C&PID_1C06#6&38396FF0&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'max'}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetAxiOCPOff(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<001c02>serial<0001>index<0>senstype<CurrentItem12V>sensindex<5>",
            "{'ocp-enabled': 'false'}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetAxiOCPMode(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<001c0a>serial<\\\\.\\HID#VID_1B1C&PID_1C0A#6&29D75A95&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}>index<0>senstype<Current12V>sensindex<0>",
            "{'rail-mode': 'single-rail'}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetAxiOCPOn(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<001c02>serial<0001>index<0>senstype<CurrentItem12V>sensindex<5>",
            "{'ocp-enabled': 'true', 'ocp-limit': 27}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetAxiFanCustom(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<001c06>serial<\\\\.\\HID#VID_1B1C&PID_1C06#6&38396FF0&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'custom', 'external-temp': 'vid<1b1c>pid<001c06>serial<\\\\\\\\.\\\\HID#VID_1B1C&PID_1C06#6&38396FF0&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}>index<0>senstype<Temperature>sensindex<0>', 'points-percents': [40, 50, 60, 70, 80, 90], 'points-temperatures':[20, 30, 40, 50 60, 70]}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitLedOn(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2254C87F&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Led>sensindex<0>",
            "{'colors':['#1dff00','#0000ff'],'mode':'two-colors'}");

            client.Send("cl.sensor.set-settings",param).Wait();
        }

        private static void SetAsetekLedOn(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c0a>serial<2;7289_2.0>index<0>senstype<Led>sensindex<0>",
            "{'color': '#ff0000','warning-color': '#00ff00', 'temperature': 45}");

            client.Send("cl.sensor.set-settings", param).Wait();
        }

        private static void SetStarcoolerLedOn(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c13>serial<4660;7289_2.0>index<0>senstype<Led>sensindex<0>",
            "{'mode': 'rainbow', 'speed': 'slow', 'colors': ['#ff0000', '#00ff00']}");

            client.Send("cl.sensor.set-default-settings", param).Wait();
        }

        private static void SwitchToHardware(LinkClient client)
        {
            client.Send("cl.device.switch-hardware-light", null).Wait();
        }

        private static void SetAsetekLedOff(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Led>sensindex<0>",
            "{}");

            client.Send("cl.sensor.set-settings", param).Wait();
        }

        private static void SetAsetekPumpQuiet(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Pump>sensindex<0>",
            "{'mode': 'quiet'}");

            client.Send("cl.sensor.set-settings", param).Wait();
        }

        private static void SetAsetekPumpPerfomance(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c13>serial<4660;7289_2.0>index<0>senstype<Pump>sensindex<0>",
            "{'mode': 'balanced'}");

            client.Send("cl.sensor.set-settings", param).Wait();
        }

        private static void SetAsetekFanQuiet(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c13>serial<4660;7289_2.0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'balanced'}");

            client.Send("cl.sensor.set-settings", param).Wait();
        }

        private static void SetAntiguaStripExternalFan(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c10>serial<DBE636C4>index<0>senstype<Led>sensindex<0>",
            @"{
'channel-one': 
    {
        'channel-type': 'led-strip',
        'brightness': 100,
        'groups': [
            {
                'group-mode': 'temperature',
                'colors': [ '#00ff00', '#ffff00', '#ff0000' ],
                'temperatures': [20, 30, 40],
                'external-temp': 'vid<1b1c>pid<000c10>serial<DBE636C4>index<0>senstype<Temperature>sensindex<3>'
            },
            {
                'group-mode': 'temperature',
                'colors': [ '#00ff00', '#ffff00', '#ff0000' ],
                'temperatures': [20, 30, 40],
                'external-temp': 'vid<1b1c>pid<000c10>serial<DBE636C4>index<0>senstype<Temperature>sensindex<3>'
            }
        ]
    },
'channel-two':
    {
        'channel-type': 'led-strip',
        'brightness': 100,
        'groups': [
            {
                'group-mode': 'temperature',
                'colors': [ '#00ff00', '#ffff00', '#ff0000' ],
                'temperatures': [20, 30, 40],
                'external-temp': 'vid<1b1c>pid<000c10>serial<DBE636C4>index<0>senstype<Temperature>sensindex<3>'
            },
            {
                'group-mode': 'temperature',
                'colors': [ '#00ff00', '#ffff00', '#ff0000' ],
                'temperatures': [20, 30, 40],
                'external-temp': 'vid<1b1c>pid<000c10>serial<DBE636C4>index<0>senstype<Temperature>sensindex<3>'
            }
        ]
    }
}");

            param.Add("vid<1b1c>pid<000c10>serial<DBE636C4>index<0>senstype<Fan>sensindex<5>",
                @"{ 'mode': 'quiet', 'external-temp': 'vid<1b1c>pid<000c10>serial<DBE636C4>index<0>senstype<Temperature>sensindex<3>'}");
            
            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitFanQuietExternal(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2254C87F&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'quiet', 'external-temp': 'vid<1b1c>pid<0c043b>serial<\\\\\\\\.\\\\HID#VID_1B1C&PID_0C04#6&2254C87F&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Temperature>sensindex<0>'}");
            param.Add("vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2254C87F&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<1>",
            "{'mode': 'quiet', 'external-temp': 'vid<1b1c>pid<0c043b>serial<\\\\\\\\.\\\\HID#VID_1B1C&PID_0C04#6&2254C87F&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Temperature>sensindex<0>'}");


            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetCoolitLedTemp(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&2254C87F&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Led>sensindex<0>",
                "{'mode': 'temperature','colors': ['#00ff00', '#ffff00', '#ff0000'], 'temperatures': [20, 30, 40], 'external-temp': 'vid<1b1c>pid<0c043b>serial<\\\\\\\\.\\\\HID#VID_1B1C&PID_0C04#6&2254C87F&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Temperature>sensindex<0>'}");

            client.Send("cl.sensor.set-settings", param).Wait();
        }

        private static void SetAsetekFanMax(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'quiet'}");

            client.Send("cl.sensor.set-settings", param).Wait();
        }

        private static void SetAsetekFanFixed(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'fixed', 'percents': 40}");

            client.Send("cl.sensor.set-settings", param).Wait();
        }

        private static void SetAsetekFanCustom(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000c07>serial<1;7289_1.0>index<0>senstype<Fan>sensindex<0>",
            "{'mode': 'custom', 'points-percents': [40, 50, 60, 70, 80, 90], 'points-temperatures': [30, 40, 50, 60, 70, 80]}");

            client.Send("cl.sensor.set-settings", param).Wait();
        }

        private static void SetH80Test2(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&F9B17DA&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Led>sensindex<0>",
            "{'colors': ['#00ff00'],'mode':'static'}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetH80Test(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<0c043b>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&F9B17DA&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Led>sensindex<0>",
            "{'colors': ['#ff0000', '#ffff00', '#00ff00', '#0000ff'],'mode':'four-colors'}");
           
            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetStaticDram(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<0>senstype<Led>sensindex<0>",
            "{'mode': 'static', 'colors': ['#ff0000']}");
            param.Add("vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<1>senstype<Led>sensindex<0>",
            "{'mode': 'static', 'colors': ['#00ff00']}");
            param.Add("vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<2>senstype<Led>sensindex<0>",
            "{'mode': 'static', 'colors': ['#0000ff']}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetPulseDram(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<0>senstype<Led>sensindex<0>",
            "{'mode': 'color-pulse', 'speed': '10', 'sync-modules': [0, 1, 2, 3],'sync-delay':'none','sync-direction':'left-to-right', 'colors':['#ff0000']}");
            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetSensorSettings(LinkClient client, string sensorId, string settingsPath)
        {
            try
            {
                var settings = File.ReadAllText(settingsPath);

                var param = new Dictionary<string, string>();

                param.Add(sensorId, settings);
                client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
            }
            catch(Exception ex)
            {
                Error(ex.Message);
            }
        }

        private static void SetShiftDram(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<0>senstype<Led>sensindex<0>",
            "{'mode': 'color-shift', 'speed': '10', 'sync-modules': [0, 1, 2, 3],'sync-delay':'none','sync-direction':'left-to-right', 'colors':['#ff0000', '#00ff00']}");
            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetRainbowDram(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<0>senstype<Led>sensindex<0>",
            "{'mode': 'rainbow', 'speed': '10', 'sync-modules': [0, 1, 2, 3],'sync-delay':'none','sync-direction':'left-to-right'}");
            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void SetDefaultDram(LinkClient client)
        {
            var param = new Dictionary<string, string>();

            param.Add("vid<1b1c>pid<000004>serial<CMU16GX4M2C3000C15>index<0>senstype<Led>sensindex<0>",
            "{'mode': 'default', 'speed': '5', 'sync-modules': [0, 1, 2, 3], 'sync-delay': 'long '}");
            //param.Add("vid<1b1c>pid<000004>serial<CMR32GX4M4C3466C16>index<1>senstype<Led>sensindex<0>",
            //"{'mode': 'rainbow', 'speed': '30', 'sync-modules': [1, 3]}");

            client.Send("cl.sensor.set-settings", param).GetAwaiter().GetResult();
        }

        private static void UpdateFirmwareBarbuda(LinkClient client)
        {
            //var param = "{'device-id': 'vid<1b1c>pid<000c10>serial<B373D412>index<0>', 'path': 'D:\\\\CommanderPRO 0.5.182.cyacd'}";
            var param = "{'device-id': 'vid<1b1c>pid<001d04>serial<90CF9267>index<0>', 'path': 'D:\\\\SpecOmega 0.6.116.bin'}";
            
            client.Send("cl.device.fw-update", param).Wait();
        }

        private static void UpdateFirmwareAntigua(LinkClient client)
        {
            //var param = "{'device-id': 'vid<1b1c>pid<000c10>serial<B373D412>index<0>', 'path': 'D:\\\\CommanderPRO 0.5.182.cyacd'}";
            var param = "{'device-id': 'vid<1b1c>pid<001d00>serial<179F35BC>index<0>', 'path': 'D:\\\\1000D 0.8.210.cyacd'}";

            client.Send("cl.device.fw-update", param).Wait(); 
        }

        private static void UpdateFirmwareStarcooler(LinkClient client)
        {
            //var param = "{'device-id': 'vid<1b1c>pid<000c10>serial<B373D412>index<0>', 'path': 'D:\\\\CommanderPRO 0.5.182.cyacd'}";
            var param = "{'device-id': 'vid<1b1c>pid<000c12>serial<4660;7289_2.0>index<0>', 'path': 'D:\\\\Corsair_1_0_3_0_h150i.efm8'}";

            client.Send("cl.device.fw-update", param).Wait();
        }

        private static void SetupDebugFolder(LinkClient client)
        {
            var param = "{'enabled': 'true', 'log-folder': 'C:\\\\ProgramData\\\\CLinkTest\\\\Logs\\\\L'}";

            client.Send("cl.debug-logging.setup", param).Wait();
        }

        private static void SetupDebugServiceInteraction(LinkClient client)
        {
            var param = "{'ingoing-messages': 'true', 'outgoing-messages': 'true', 'short-version': 'false', 'format-output': 'true'}";

            client.Send("cl.debug-logging.setup-service-interaction", param).Wait();
        }

        private static void SaveToDevice(LinkClient client)
        {
            var param = "vid<1b1c>pid<000c13>serial<4660;7289_2.0>index<0>";

            client.Send("cl.device.save-to-device", param).Wait();
        }
    }
}
