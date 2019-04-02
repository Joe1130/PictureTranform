using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseObject
{
    [Serializable]
  public  class PicInfo
    {
        public Image Picture { get; set; }
        public string Information { get; set; }

        public PicInfo() { }
        public PicInfo(Image image, string info)
        {
            this.Picture = image;
            this.Information = info;
        }
    }
}
