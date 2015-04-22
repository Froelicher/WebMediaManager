using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Structures.SYoutube
{
    [DataContract]
    class Videos
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
            public DateTime publisedAt { get; set; }

            [DataMember]
            public string channelId { get; set; }

            [DataMember]
            public string title { get; set; }

            [DataMember]
            public string description { get; set; }

            [DataMember]
            public Thumbnails thumbnails { get; set; }

            [DataMember]
            public string channelTitle { get; set; }

            [DataMember]
            public string[] tags { get; set; }

            [DataMember]
            public string categoryId { get; set; }

            [DataMember]
            public string liveBroadcastContent { get; set; }
        }

        [DataMember]
        public Snippet snippet { get; set; }

        [DataContract]
        public class ContentDetails
        {
            [DataMember]
            public string duration { get; set; }

            [DataMember]
            public string dimension { get; set; }

            [DataMember]
            public string definition { get; set; }

            [DataMember]
            public string caption { get; set; }

            [DataMember]
            public bool licensedContent { get; set; }

            [DataContract]
            public class RegionRestriction
            {
                [DataMember]
                public string[] allowed { get; set; }

                [DataMember]
                public string[] blocked { get; set; }
            }

            [DataMember]
            public RegionRestriction regionRestriction { get; set; }
        }

        [DataMember]
        public ContentDetails contentDetails { get; set; }
        
        [DataContract]
        public class Status
        {
            [DataMember]
            public string uploadStatus { get; set; }

            [DataMember]
            public string failureReason { get; set; }

            [DataMember]
            public string rejectionReason { get; set; }

            [DataMember]
            public string privacyStatus { get; set; }

            [DataMember]
            public DateTime publishedAt { get; set; }

            [DataMember]
            public string license { get; set; }

            [DataMember]
            public bool embeddable { get; set; }

            [DataMember]
            public bool publicStatsViewable { get; set; }
        }

        [DataMember]
        public Status status { get; set; }
        
        [DataContract]
        public class Statistics
        {
            [DataMember]
            public long viewCount { get; set; }

            [DataMember]
            public long likeCount { get; set; }

            [DataMember]
            public long dislikeCount { get; set; }

            [DataMember]
            public long favoriteCount { get; set; }

            [DataMember]
            public long commentCount { get; set; }
        }

        [DataMember]
        public Statistics statistics { get; set; }

        [DataContract]
        public class Player
        {
            [DataMember]
            public string embedHtml { get; set; }
        }

        [DataMember]
        public Player player { get; set; }

        [DataContract]
        public class TopicDetails
        {
            [DataMember]
            public string[] topicIds { get; set; }

            [DataMember]
            public string[] relevantTopicIds { get; set; }
        }

        [DataMember]
        public TopicDetails topicDetails { get; set; }

        [DataContract]
        public class RecordingDetails
        {
            [DataMember]
            public string locationDescription { get; set; }

            [DataContract]
            public class Location
            {
                [DataMember]
                public double latitude { get; set; }

                [DataMember]
                public double longitude { get; set; }

                [DataMember]
                public double altitude { get; set; }
            }

            [DataMember]
            public Location location { get; set; }

            [DataMember]
            public DateTime recordingDate { get; set; }
        }

        [DataContract]
        public class FileDetails
        {
            [DataMember]
            public string fileName { get; set; }

            [DataMember]
            public string fileSize { get; set; }

            [DataMember]
            public string fileType { get; set; }

            [DataMember]
            public string container { get; set; }

            [DataContract]
            public class VideoStreams
            {
                [DataMember]
                public int widthPixels { get; set; }

                [DataMember]
                public int heightPixels { get; set; }

                [DataMember]
                public double frameRateFps { get; set; }

                [DataMember]
                public double aspectRatio { get; set; }

                [DataMember]
                public string codec { get; set; }

                [DataMember]
                public long bitrateBps { get; set; }

                [DataMember]
                public string rotation { get; set; }

                [DataMember]
                public string vendor { get; set; }
            }

            [DataMember]
            public VideoStreams[] videoStreams { get; set; }

            [DataContract]
            public class AudioStreams
            {
                [DataMember]
                public int channelCount { get; set; }

                [DataMember]
                public string codec { get; set; }

                [DataMember]
                public long bitrateBps { get; set; }

                [DataMember]
                public string vendor { get; set; }
            }

            [DataMember]
            public AudioStreams audioStreams { get; set; }

            [DataMember]
            public long durationMs { get; set; }

            [DataMember]
            public long bitrateBps { get; set; }

            [DataContract]
            public class Location
            {
                [DataMember]
                public double latitude { get; set; }

                [DataMember]
                public double longitude { get; set; }

                [DataMember]
                public double altitude { get; set; }
            }

            [DataMember]
            public Location recordingLocation { get; set; }

            [DataMember]
            public string creationTime { get; set; }
        }

        [DataMember]
        public FileDetails fileDetails { get; set; }

        [DataContract]
        public class ProcessingDetails
        {
            [DataMember]
            public string processingStatus { get; set; }

            [DataContract]
            public class ProcessingProgress
            {
                [DataMember]
                public long partsTotal { get; set; }

                [DataMember]
                public long partsProcessed { get; set; }

                [DataMember]
                public long timeLeftMs { get; set; }
            }

            [DataMember]
            public ProcessingProgress processingProgress { get; set; }

            [DataMember]
            public string processingFailureReason { get; set; }

            [DataMember]
            public string fileDetailsAvailability { get; set; }

            [DataMember]
            public string processingIssueAvailability { get; set; }

            [DataMember]
            public string tagSuggestionsAvailability { get; set; }

            [DataMember]
            public string editorSuggestionsAvailability { get; set; }

            [DataMember]
            public string thumbnailsAvailability { get; set; }
        }

        [DataMember]
        public ProcessingDetails processingDetails { get; set; }

        [DataContract]
        public class Suggestions
        {
            [DataMember]
            public string[] processingErrors { get; set; }

            [DataMember]
            public string[] processingWarnings { get; set; }

            [DataMember]
            public string[] processingHints { get; set; }

            [DataContract]
            public class TagSuggestions
            {
                [DataMember]
                public string tag { get; set; }

                [DataMember]
                public string[] categoryRestricts { get; set; }
            }

            [DataMember]
            public TagSuggestions[] tagSuggestions { get; set; }

            [DataMember]
            public string[] editorSuggestions { get; set; }
        }

        [DataMember]
        public Suggestions suggestions { get; set; }

        [DataContract]
        public class LiveStreamingDetails
        {
            [DataMember]
            public DateTime actuelStartTime { get; set; }

            [DataMember]
            public DateTime actualEndTime { get; set; }

            [DataMember]
            public DateTime scheduledStartTime { get; set; }

            [DataMember]
            public DateTime scheduledEndTime { get; set; }

            [DataMember]
            public long concurrentViewers { get; set; }
        }

        [DataMember]
        public LiveStreamingDetails liveStreamingDetails { get; set; }
    }
}
