using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using ImpromptuInterface;
using Logger;

namespace LoggingProxy
{
    public class LoggingProxy<T> : DynamicObject where T : class
    {
        public readonly Dictionary<string, object> Members = new Dictionary<string, object>();
        private static T _processedObject;

        public static T CreateInstance(T processedObject)
        {
             return new LoggingProxy<T>(processedObject).ActLike(typeof(T));
        }

        private LoggingProxy(T processedObject)
        {
            _processedObject = processedObject;
            MemberInfo[] members = typeof(T).GetMembers();
            foreach(var member in members)
            {
                if(!Members.TryGetValue(member.Name, out object value))
                    Members.Add(member.Name, member);
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            SimpleLogger logger = new SimpleLogger();
            logger.Logger.Warning(binder.Name);

            result = typeof(T).InvokeMember(binder.Name, BindingFlags.InvokeMethod, null, _processedObject, args);
            return true;
        } 
    }
}
