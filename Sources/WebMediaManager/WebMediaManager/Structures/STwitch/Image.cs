/*
 * Author : JP. Froelicher
 * Description : Image
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    public class Image
    {
      [DataMember]
      public string large { get; set; }

      [DataMember]
      public string medium { get; set; }

      [DataMember]
      public string small { get; set; }

      [DataMember]
      public string template { get; set; }

    }
}
