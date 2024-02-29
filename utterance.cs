using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CowUtters
{
    public class Utterance
    {
        //public int group_id;

        //public string? endTime;

        //public string? meetingId;

        //public string? offsetSeconds;

        public string? speaker { get; set; }

        //public string? startTime;
        public string? text { get; set; }
        public ulong timestampMs { get; set; }
    }

    public class Utterances
    {
        public List<Utterance>? utterances;
    }

}

