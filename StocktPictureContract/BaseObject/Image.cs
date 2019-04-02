using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseObject
{
    //这里也要标记为序列化
    [Serializable]
    public class Image
    { 
        public byte [] image { get; set; }
        public Image(byte []  stream)
        {
            this.image = stream;
        }
    }
}
