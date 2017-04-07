using PipeServer.DeviceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    internal class DeviceCache
    {
        private List<Device> devices = new List<Device>();

        internal DeviceCache()
        {
            var device1 = new Device
            {
                Id = "Id1",
                Pid = 0x0c0b,
                Vid = 0x1b1c,
                FirmwareVersion = "1.1.0.0"
            };

            var fan11 = new FanSensor("1");
            fan11.SetCurrentValue(1000);
            fan11.SetCurrentValue(1100);
            fan11.SetCurrentValue(1200);
            fan11.SetCurrentValue(1300);
            var pump1 = new PumpSensor("2");
            pump1.SetCurrentValue(2000);
            pump1.SetCurrentValue(2100);
            pump1.SetCurrentValue(2200);
            pump1.SetCurrentValue(2300);

            device1.Sensors.Add(fan11);
            device1.Sensors.Add(pump1);

            var device2 = new Device
            {
                Id = "Id2",
                Pid = 0x0c0c,
                Vid = 0x1b1c,
                FirmwareVersion = "1.1.2.0"
            };

            var fan2 = new FanSensor("11");
            fan2.SetCurrentValue(3000);
            fan2.SetCurrentValue(3100);
            fan2.SetCurrentValue(3200);
            fan2.SetCurrentValue(3300);
            var pump2 = new PumpSensor("22");
            pump2.SetCurrentValue(4000);
            pump2.SetCurrentValue(4100);
            pump2.SetCurrentValue(4200);
            pump2.SetCurrentValue(4300);

            device2.Sensors.Add(fan2);
            device2.Sensors.Add(pump2);

            devices.Add(device1);
            devices.Add(device2);
        }

        internal List<Device> GetDevices()
        {
            return devices;
        }

        internal List<SensorBase> GetSensors(string deviceId)
        {
            var device = devices.FirstOrDefault(d => d.Id == deviceId);

            if (device == null)
                return new List<SensorBase>();

            return device.Sensors;
        }

        internal object GetSensorValue(string sensorId)
        {
            foreach (var device in devices)
            {
                var sensor = device.Sensors.FirstOrDefault(s => s.Id == sensorId) as ISensorValue;

                if (sensor != null)
                {
                    return sensor.GetSensorValue();
                }
            }
            return null;
        }

        internal List<object> GetLastSensorValue(string sensorId)
        {
            foreach (var device in devices)
            {
                var sensor = device.Sensors.FirstOrDefault(s => s.Id == sensorId) as ISensorValue;

                if (sensor != null)
                {
                    return sensor.GetLastSensorValues();
                }
            }
            return null;
        }
    }
}
