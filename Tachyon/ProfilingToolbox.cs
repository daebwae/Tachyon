using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tachyon
{
    public static class ProfilingToolbox
    {
        public static long SizeOf(object o)
        {
            long size = 0;

            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                // this may fail for large data sizes 
                formatter.Serialize(s, o);
                size = s.Length;
            }

            return size;
        }
    }
}
