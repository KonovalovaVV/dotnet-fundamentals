using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using LoggingProxy.Logger;

namespace LoggingProxy
{
    public class LoggingProxy<T> : DynamicObject
    {
        public readonly Dictionary<string, object> Members = new Dictionary<string, object>();

        public LoggingProxy()
        {
            MemberInfo[] members = typeof(T).GetMembers();
            foreach(var member in members)
            {
                if(!Members.TryGetValue(member.Name, out object value))
                    Members.Add(member.Name, member);
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Members[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (Members.ContainsKey(binder.Name))
            {
                result = Members[binder.Name];
                return true;
            }
            result = null;
            return false;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            SimpleLogger logger = new SimpleLogger();
            logger.Logger.Warning(binder.Name);
            
            dynamic method = Members[binder.Name];
            
            result = method((int)args[0]);
            return true;
        } 
    }
}
