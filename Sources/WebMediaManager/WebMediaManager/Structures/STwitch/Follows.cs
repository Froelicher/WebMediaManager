/*
 * Author : JP. Froelicher
 * Description : Follows
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class Follows
    {
        [DataMember]
        public Follow[] follows { get; set; }
    }
}
