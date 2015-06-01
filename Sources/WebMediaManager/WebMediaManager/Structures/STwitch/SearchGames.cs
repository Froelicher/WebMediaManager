/*
 * Author : JP. Froelicher
 * Description : Search games
 * Date : 16/04/2015
 */
using System.Runtime.Serialization;

namespace WebMediaManager.Structures.STwitch
{
    [DataContract]
    class SearchGames
    {
        [DataContract]
        public class SearchLinks
        {
            [DataMember]
            public string self { get; set; }

            [DataMember]
            public string next { get; set; }
        }

        [DataMember]
        public SearchLinks _links { get; set; }

        [DataMember]
        public Game[] games { get; set; }

    }
}
