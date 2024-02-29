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

        //compares the speaker value of the object and the input value.
        //true of both are valid objects (non-null speakers) and are the
        //same speaker
        public bool sameSpeaker(Utterance? inval)
        {
            if(inval != null && !string.IsNullOrEmpty(this.speaker))
            {
                return this.speaker == inval.speaker;
            }
            return false;
        }

        public bool endsInFragment()
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new InvalidDataException("text is null or empty");
            }
            return this.text.LastIndexOfAny(".!?".ToCharArray()) != this.text.Length;
        }

    }

    public class Utterances
    {

        public List<Utterance> utterances { get; set; }
        public Utterances()
        {
            utterances = new List<Utterance>();
    }
}

}

