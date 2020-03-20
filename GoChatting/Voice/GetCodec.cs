using System;
using System.Collections.Generic;
using System.Linq;

namespace GoChatting.Voice
{
    public class GetCodec
    {
        public static IEnumerable<T> GetCodecs<T>()
        {
            //return ReflectionHelper.CreateAllInstancesOf<T>();
            List<INetworkChatCodec> temp = new List<INetworkChatCodec>();
            temp.Add(new WideBandSpeexCodec());
            return (IEnumerable<T>)temp;
        }

    }
    public static class ReflectionHelper
    {
        public static IEnumerable<T> CreateAllInstancesOf<T>()
        {
            return typeof(ReflectionHelper).Assembly.GetTypes()
                .Where(t => typeof(T).IsAssignableFrom(t))
                .Where(t => !t.IsAbstract && t.IsClass)
                .Select(t => (T)Activator.CreateInstance(t));
        }
    }

    public class CodecItem
    {
        public string Text { get; set; }
        public INetworkChatCodec Codec { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
