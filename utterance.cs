﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CowUtters
{

    //Attribution Note: documentation of this class has been autogenerated by my good friend github copilot
    public class Utterance
    {
        /// <summary>
        /// Gets or sets the speaker of the utterance.
        /// </summary>
        public string? speaker { get; set; }

        /// <summary>
        /// Gets or sets the text of the utterance.
        /// </summary>
        public string? text { get; set; }

        /// <summary>
        /// Gets or sets the timestamp in milliseconds of the utterance.
        /// </summary>
        public ulong timestampMs { get; set; }

        /// <summary>
        /// Compares the speaker value of the current Utterance object with the input Utterance object.
        /// </summary>
        /// <param name="inval">The Utterance object to compare with.</param>
        /// <returns>True if both objects have valid speakers (non-null) and are the same speaker, otherwise false.</returns>
        public bool sameSpeaker(Utterance? inval)
        {
            if (inval != null && !string.IsNullOrEmpty(this.speaker))
            {
                return this.speaker == inval.speaker;
            }
            return false;
        }

        /// <summary>
        /// Checks if the text of the utterance was a complete sentence (ended in punctuation).
        /// </summary>
        /// <returns>True if the text ends with '.', '!', or '?', otherwise false.</returns>
        public bool endsInPunctuation()
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return indexOfLastPunctuation() == (text.Length - 1);
        }

        /// <summary>
        /// Returns the index of the last punctuation character in the text.
        /// </summary>
        /// <returns>The index of the last punctuation character, or -1 if the text is null or empty.</returns>
        public int indexOfLastPunctuation()
        {
            if (string.IsNullOrEmpty(text))
            {
                return -1;
            }
            return this.text.LastIndexOfAny(".!?".ToCharArray());
        }

        /// <summary>
        /// Returns the index of the first punctuation character in the text.
        /// </summary>
        /// <returns>
        /// The index of the first punctuation character, or -1 if the text is null or empty.
        /// </returns>
        public int indexOfFirstPunctuation()
        {
            if (string.IsNullOrEmpty(text))
            {
                return -1;
            }
            return this.text.IndexOfAny(".!?".ToCharArray());
        }
    }

    /// <summary>
    /// Represents a collection of utterances.
    /// </summary>
    public class Utterances
    {
        /// <summary>
        /// Gets or sets the list of utterances.
        /// </summary>
        public List<Utterance> utterances { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Utterances"/> class.
        /// </summary>
        public Utterances()
        {
            utterances = new List<Utterance>();
        }
    }

}

