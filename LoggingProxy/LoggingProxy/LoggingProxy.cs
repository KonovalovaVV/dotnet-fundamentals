using System;
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
        private ILogger logger;
        public static T CreateInstance(T processedObject)
        {
             return new LoggingProxy<T>(processedObject).ActLike(typeof(T));
        }

        private LoggingProxy(T processedObject)
        {
            logger = new SimpleLogger();
            _processedObject = processedObject;
            MemberInfo[] members = typeof(T).GetMembers();
            foreach(var member in members)
            {
                if(!Members.TryGetValue(member.Name, out object value))
                    Members.Add(member.Name, member);
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            logger.Info(binder.Name);
            try
            {
                Members[binder.Name] = value;
                return true;
            }
            catch (Exception e)
            {
                if (e.InnerException != null && e.InnerException.GetType() !=
                    typeof(ArgumentOutOfRangeException))
                    throw;
                return false;
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            logger.Info(binder.Name);
            result = null;
            try
            {
                if (Members.ContainsKey(binder.Name))
                {
                    result = Members[binder.Name];
                }
                return true;
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException != null && e.InnerException.GetType() !=
                    typeof(ArgumentOutOfRangeException))
                    throw;
                return false;
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            logger.Info(binder.Name);
            try
            {
                result = typeof(T).InvokeMember(binder.Name, BindingFlags.InvokeMethod, null, _processedObject, args);
                return true;
            }
            catch (TargetInvocationException e)
            {
                result = null;
                if (e.InnerException != null && e.InnerException.GetType() !=
                    typeof(ArgumentOutOfRangeException))
                    throw;
                return false;
            }
        } 
    }
}
