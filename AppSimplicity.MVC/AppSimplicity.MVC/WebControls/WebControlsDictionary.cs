using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AppSimplicity.MVC.WebControls
{
    [Serializable]
    public class WebControlsDictionary : Dictionary<string, FormControl>
    {
        /// <summary>
        /// Tests if a given key is present in dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            return this.ContainsKey(key);
        }

        public override string ToString()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, this);
            memoryStream.Flush();
            memoryStream.Position = 0;
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public WebControlsDictionary()
        {
            // no constructor required, very useful when deserializing ;)
        }

        public WebControlsDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // no constructor required, very useful when deserializing ;)
        }

        public static WebControlsDictionary DeserializeFromString(string serializedData)
        {
            WebControlsDictionary result = null;

            byte[] bytes = Convert.FromBase64String(serializedData);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                BinaryFormatter bf = new BinaryFormatter();
                result = bf.Deserialize(stream) as WebControlsDictionary;
            }

            return result;
        }
    }
}
