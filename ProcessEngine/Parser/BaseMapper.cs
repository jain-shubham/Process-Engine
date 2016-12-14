using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Parser
{
    class BaseMapper<T>
    {
        protected Dictionary<string, string> mapperDictionary;
        protected Dictionary<object, object> deserializedYaml;

        public BaseMapper()
        {
            mapperDictionary = new Dictionary<string, string>();
        }

        protected void setNormalProperty(T obj, int index)
        {
            string propName;
            PropertyInfo propInfo;
            Type type = Type.GetType(obj.ToString());
            try
            {
                propName = mapperDictionary.ElementAt(index).Value;
                propInfo = type.GetProperty(propName);
                Type propTargetType = propInfo.PropertyType;
                var value = Convert.ChangeType(deserializedYaml[mapperDictionary.ElementAt(index).Key], propTargetType);
                propInfo.SetValue(obj, value, null);
            }
            catch (Exception e)
            {
                return;
            }
        }

        protected void setNestedListProperty<T1>(T obj, int index)
        {
            string propName;
            PropertyInfo propInfo;
            Type type = Type.GetType(obj.ToString());
            try
            {
                propName = mapperDictionary.ElementAt(index).Value;
                propInfo = type.GetProperty(propName);
                Type propTargetType = propInfo.PropertyType.GetGenericArguments().Single();

                List<object> yamlList = (List<object>)deserializedYaml[mapperDictionary.ElementAt(index).Key];
                List<T1> valueList = new List<T1>();
                foreach (Dictionary<object, object> listItem in yamlList)
                {
                    BaseMapper<T1> innerMapper = (BaseMapper<T1>)Assembly.GetExecutingAssembly().CreateInstance("Engine.Parser." + propTargetType.Name + "Mapper");
                    valueList.Add((T1)innerMapper.mapperMethod(listItem));
                }
                //var value = Convert.ChangeType(variables, propTargetType);
                propInfo.SetValue(obj, valueList, null);
            }
            catch (Exception e)
            {
                return;
            }
        }

        protected void setListProperty<T1>(T obj, int index)
        {
            string propName;
            PropertyInfo propInfo;
            Type type = Type.GetType(obj.ToString());
            try
            {
                propName = mapperDictionary.ElementAt(index).Value;
                propInfo = type.GetProperty(propName);
                Type propTargetType = propInfo.PropertyType.GetGenericArguments().Single();

                List<object> yamlList = (List<object>)deserializedYaml[mapperDictionary.ElementAt(index).Key];
                List<T1> valueList = new List<T1>();
                foreach (object listItem in yamlList)
                {
                    BaseMapper<T1> innerMapper = (BaseMapper<T1>)Assembly.GetExecutingAssembly().CreateInstance("Engine.Parser." + propTargetType.Name + "Mapper");
                    valueList.Add((T1)innerMapper.mapperMethod(listItem));
                }
                propInfo.SetValue(obj, valueList, null);
            }
            catch (Exception e)
            {
                return;
            }
        }

        public virtual T mapperMethod(Object obj)
        {
            T ob = (T)Assembly.GetExecutingAssembly().CreateInstance(this.mapperDictionary.ElementAt(0).Value);
            return ob;
        }



    }
}
