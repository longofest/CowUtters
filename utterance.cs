using System;
using System.Text.Json;


namespace CowUtters
{
    public class Utterance
    {
        public string? speaker;
        public string? text;
        public ulong timestampMs;
    }

    public class Utterances
    {
        public List<Utterance>? utterances;
    }

}

