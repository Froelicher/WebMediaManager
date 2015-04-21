using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class Channels
    {
        [DataMember]
        public string kind { get; set; }

        [DataMember]
        public string etag { get; set; }

        [DataMember]
        public string id { get; set; }

        [DataContract]
        public class Snippet
        {
            [DataMember]
            public string title { get; set; }

            [DataMember]
            public string description { get; set; }

            [DataMember]
            public DateTime publishedAt { get; set; }

            [DataMember]
            public Thumbnails thumbnails { get; set; }
        }

        [DataMember]
        public Snippet snippet { get; set; }

        [DataContract]
        public class ContentDetails
        {
            [DataContract]
            public class RelatedPlaylists
            {
                [DataMember]
                public string likes { get; set; }

                [DataMember]
                public string favorites { get; set; }

                [DataMember]
                public string uploads { get; set; }

                [DataMember]
                public string watchHistory { get; set; }

                [DataMember]
                public string watchLater { get; set; }
            }

            [DataMember]
            public RelatedPlaylists relatedPlaylists { get; set; }

            [DataMember]
            public string googlePlusUserId { get; set; }
        }

        [DataMember]
        public ContentDetails contentDetails { get; set; }

        [DataContract]
        public class Statistics
        {
            [DataMember]
            public long viewCount { get; set; }

            [DataMember]
            public long commentCount { get; set; }

            [DataMember]
            public long subscriberCount { get; set; }

            [DataMember]
            public bool hiddenSubscriberCount { get; set; }

            [DataMember]
            public long videoCount { get; set; }
        }

        [DataMember]
        public Statistics statistics { get; set; }

        [DataContract]
        public class TopicDetails
        {
            [DataMember]
            public string[] topicIds { get; set; }
        }

        [DataMember]
        public TopicDetails topicDetails { get; set; }

        [DataContract]
        public class Status
        {
            [DataMember]
            public string privacyStatus { get; set; }

            [DataMember]
            public bool isLinked { get; set; }

            [DataMember]
            public string longUploadsStatus { get; set; }
        }

        [DataMember]
        public Status status { get; set; }

        [DataContract]
        public class BrandingSettings
        {
            [DataContract]
            public class Channel
            {
                [DataMember]
                public string title { get; set; }

                [DataMember]
                public string description { get; set; }

                [DataMember]
                public string keywords { get; set; }

                [DataMember]
                public string defaultTab { get; set; }

                [DataMember]
                public string trackingAnalyticsAccountId { get; set; }

                [DataMember]
                public bool moderateComments { get; set; }

                [DataMember]
                public bool showRelatedChannels { get; set; }

                [DataMember]
                public bool showBrowseView { get; set; }

                [DataMember]
                public string featuredChannelsTitle { get; set; }

                [DataMember]
                public string[] featuredChannelsUrls { get; set; }

                [DataMember]
                public string unsubscribedTrailer { get; set; }

                [DataMember]
                public string profileColor { get; set; }
            }

            [DataMember]
            public Channel channel { get; set; }


            [DataContract]
            public class Watch
            {
                [DataMember]
                public string textColor { get; set; }

                [DataMember]
                public string backgroundColor { get; set; }

                [DataMember]
                public string featuredPlaylistId { get; set; }
            }

            [DataMember]
            public Watch watch { get; set; }

            [DataContract]
            public class Image
            {
                [DataMember]
                public string bannerImageUrl { get; set; }

                [DataMember]
                public string bannerMobileImageUrl { get; set; }

                [DataMember]
                public string watchIconImageUrl { get; set; }

                [DataMember]
                public string trackingImageUrl { get; set; }

                [DataMember]
                public string bannerTableLowImageUrl { get; set; }

                [DataMember]
                public string bannerTableImageUrl { get; set; }

                [DataMember]
                public string bannerTableHdImageUrl { get; set; }

                [DataMember]
                public string bannerTableExtraHdImageUrl { get; set; }

                [DataMember]
                public string bannerMobileLowImageUrl { get; set; }

                [DataMember]
                public string bannerMobileMediumHdImageUrl { get; set; }

                [DataMember]
                public string bannerMobileHdImageUrl { get; set; }

                [DataMember]
                public string bannerMobileExtraHdImageUrl { get; set; }

                [DataMember]
                public string bannerTvImageUrl { get; set; }

                [DataMember]
                public string bannerTvLowImageUrl { get; set; }

                [DataMember]
                public string bannerTvMediumImageUrl { get; set; }

                [DataMember]
                public string bannerTvHighImageUrl { get; set; }

                [DataMember]
                public string bannerExternalUrl { get; set; }
            }

            [DataMember]
            public Image image { get; set; }

            [DataContract]
            public class Hints
            {
                [DataMember]
                public string property { get; set; }

                [DataMember]
                public string value { get; set; }
            }

            [DataMember]
            public Hints[] hints { get; set; }

        }

        [DataContract]
        public class InvideoPromotion
        {
            [DataContract]
            public class DefaultTiming
            {
                [DataMember]
                public string type { get; set; }

                [DataMember]
                public long offsetMs { get; set; }

                [DataMember]
                public long durationMs { get; set; }
            }

            [DataMember]
            public DefaultTiming defaultTiming { get; set; }

            [DataContract]
            public class Position
            {
                [DataMember]
                public string type { get; set; }

                [DataMember]
                public string cornerPosition { get; set; }
            }

            [DataMember]
            public Position position { get; set; }

            [DataContract]
            public class Items
            {
               [DataContract]
               public class Id
               {
                  [DataMember]
                  public string type { get; set; }

                  [DataMember]
                  public string videoId { get; set; }

                  [DataMember]
                  public string websiteUrl { get; set; }

                  [DataMember]
                  public string recentlyUploadedBy { get; set; }
                }

               [DataMember]
               public Id id { get; set; }

               [DataContract]
               public class Timing
               {
                   [DataMember]
                   public string type { get; set; }

                   [DataMember]
                   public long offsetMs { get; set; }

                   [DataMember]
                   public long durationMs { get; set; }
               }

               [DataMember]
               public Timing timing { get; set; }

               [DataMember]
               public string customMessage { get; set; }

               [DataMember]
               public bool promotedByContentOwner { get; set; }

            }

            [DataMember]
            public Items[] items { get; set; }

            [DataMember]
            public bool useSmartTiming { get; set; }
        }
        
        [DataContract]
        public class AuditDetails
        {
            [DataMember]
            public bool overallGoodStanding { get; set; }

            [DataMember]
            public bool communityGuidelinesGoodStanding { get; set; }

            [DataMember]
            public bool copyrightStrikesGoodStanding { get; set; }

            [DataMember]
            public bool contentIdClaimsGoodStanding { get; set; }
        }

        [DataMember]
        public AuditDetails auditDetails { get; set; }

        [DataContract]
        public class ContentOwnerDetails
        {
            [DataMember]
            public string contentOwner { get; set; }

            [DataMember]
            public DateTime timeLinked { get; set; }
        }

        [DataMember]
        public ContentOwnerDetails contentOwnerDetails { get; set; }
    }
}
