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
        private readonly Dictionary<string, object> _members = new Dictionary<string, object>();
        private readonly T _processedObject;
        private readonly ILogger _logger;

        public static T CreateInstance(T processedObject)
        {
             return new LoggingProxy<T>(processedObject).ActLike(typeof(T));
        }

        private LoggingProxy(T processedObject)
        {
            _logger = new SimpleLogger();
            _processedObject = processedObject;
            MemberInfo[] members = typeof(T).GetMembers();
            foreach(var member in members)
            {
                if(!_members.TryGetValue(member.Name, out object value))
                    _members.Add(member.Name, member);
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _logger.Info(binder.Name);
            try
            {
                _members[binder.Name] = value;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            _logger.Info(binder.Name);
            result = null;
            try
            {
                if (_members.ContainsKey(binder.Name))
                {
                    result = _members[binder.Name];
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            _logger.Info(binder.Name);
            try
            {
                result = typeof(T).InvokeMember(binder.Name, BindingFlags.InvokeMethod, null, _processedObject, args);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        } 
    }
}
