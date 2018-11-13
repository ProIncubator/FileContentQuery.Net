using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FileContentQuery.Core
{
    public class ParameterHandler
    {
        private Object ConvertArgValue(String arg)
        {
            if (int.TryParse(arg, out int intVal))
                return intVal;
            if (decimal.TryParse(arg, out decimal decimalVal))
                return decimalVal;
            return arg;
        }
        private (bool IsValidParaName, String ParaNameValue) GetParaName(String arg)
        {
            if (arg.Substring(0, 2) == "--")
                return (true, arg.Substring(2, arg.Length - 2));

            if (arg.Substring(0, 1) == "-")
                return (true, arg.Substring(1, arg.Length - 1));

            return (false, String.Empty);
        }
        public IDictionary<String, Object> ToDictionary(String[] args)
        {
            IDictionary<String, Object> parameters = new Dictionary<String, Object>();
            if (args == null || args.Length <= 0)
                return parameters;

            for (var index = 0; index < args.Length; index++)
            {
                String arg = args[index];
                (bool isValid, String paraName) = this.GetParaName(arg);
                if (!isValid) continue;

                Object paraValue = null;
                if (args.Length > index + 1 && !this.GetParaName(args[index + 1]).IsValidParaName)
                {
                    paraValue = this.ConvertArgValue(args[index + 1]);
                    index++;
                }
                else
                {
                    paraValue = true;
                }

                if (String.IsNullOrWhiteSpace(paraName))
                    continue;
                parameters[paraName] = paraValue;
            }
            return parameters;
        }
        public T ToModel<T>(String args) where T : class
        {
            return this.ToModel<T>(args.Split(" "));
        }
        public T ToModel<T>(String[] args) where T : class
        {
            var parameters = this.ToDictionary(args);
            String json = JsonConvert.SerializeObject(parameters);
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }
    }


}