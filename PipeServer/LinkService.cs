using Newtonsoft.Json;
using PipeServer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    public class LinkService
    {
        private PipeServer server;
        private DeviceCache deviceCache = new DeviceCache();

        public LinkService()
        {

        }

        public void Start()
        {
            if (server == null)
            {
                server = new PipeServer();
                server.OnMessage.Subscribe(OnMessageArrived);
                server.Start();
            }
        }

        private void OnMessageArrived(Message message)
        {
            if (message.Connection.IsConnected)
            {
                dynamic value = JsonConvert.DeserializeObject<dynamic>(message.Data);

                //[TODO] add value.method == null && value.number == null & send error
                string method = value.method ?? string.Empty;
                int number = value.number ?? 0;

                switch (GetMethodType(method))
                {
                    case MethodType.GetDevices:
                        GetDevices(message.Connection, number);
                        break;
                    case MethodType.GetSensors:
                        GetSensors(message.Connection, number, ExtractIds(value));
                        break;
                    case MethodType.GetSensorValues:
                        GetSensorValues(message.Connection, number, ExtractIds(value));
                        break;
                    case MethodType.GetLastSensorValues:
                        GetLastSensorValues(message.Connection, number, ExtractIds(value));
                        break;
                    default:
                        UnknownMethod(message.Connection, number);
                        break;
                }
            }
        }

        private List<string> ExtractIds(dynamic value)
        {
            List<string> ids = new List<string>();
            foreach (var param in value.parameters)
            {
                ids.Add(param.ToString());
            }

            return ids;
        }

        private MethodType GetMethodType(string methodName)
        {
            switch (methodName)
            {
                case "cl.device.get-list":
                    return MethodType.GetDevices;
                case "cl.device.get-device-sensors":
                    return MethodType.GetSensors;
                case "cl.sensor.get-values":
                    return MethodType.GetSensorValues;
                case "cl.sensor.get-last-values":
                    return MethodType.GetLastSensorValues;
                default:
                    return MethodType.Unknown;
            }
        }

        private void GetDevices(Connection connection, int requestNumber)
        {
            GetDeviceResponse response = new GetDeviceResponse(requestNumber)
            {
                Error = null,
                Result = deviceCache.GetDevices()
            };

            connection.Send(PrepareJson(response));
        }

        private void GetSensors(Connection connection, int requestNumber, List<string> deviceIds)
        {
            var result = new Dictionary<string, List<SensorBase>>();
            
            foreach(var deviceId in deviceIds)
            {
                result.Add(deviceId, deviceCache.GetSensors(deviceId));
            }

            GetSensorsResponse response = new GetSensorsResponse(requestNumber)
            {
                Error = null,
                Result = result
            };

            connection.Send(PrepareJson(response));
        }

        private void GetSensorValues(Connection connection, int requestNumber, List<string> sensorIds)
        {
            var result = new Dictionary<string, object>();

            foreach (var sensorId in sensorIds)
            {
                result.Add(sensorId, deviceCache.GetSensorValue(sensorId));
            }

            GetSensorValuesResponse response = new GetSensorValuesResponse(requestNumber)
            {
                Error = null,
                Result = result
            };

            connection.Send(PrepareJson(response));
        }

        private void GetLastSensorValues(Connection connection, int requestNumber, List<string> sensorIds)
        {
            var result = new Dictionary<string, List<object>>();

            foreach (var sensorId in sensorIds)
            {
                result.Add(sensorId, deviceCache.GetLastSensorValue(sensorId));
            }

            GetLastSensorValuesResponse response = new GetLastSensorValuesResponse(requestNumber)
            {
                Error = null,
                Result = result
            };

            connection.Send(PrepareJson(response));
        }

        private void UnknownMethod(Connection connection, int requestNumber)
        {
            UnknownResponse response = new UnknownResponse(requestNumber);

            connection.Send(PrepareJson(response));
        }

        private string PrepareJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
