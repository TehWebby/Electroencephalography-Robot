//-----------------------------------------------------------------------
//  Author: Shaun Webb
//  University: Sheffield Hallam University
//  Website: shaunwebb.co.uk
//  Github: TehWebby
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emotiv;

/// <summary>
/// Main EEG_Gateway Project
/// </summary>
namespace EEG_Gateway
{
    /// <summary>
    /// Affective Details to store
    /// </summary>
    public class Affective
    {
        private float shortExcitementLvl; //short term Excitement level
        private float longExcitementLvl;
        private float frustrationLvl;
        private float meditationLvl;
        private float valenceLvl;
        private float engagementBoredomLvl;
        private float smileLvl;
        private bool busy;
        EdkDll.EE_SignalStrength_t signalStrength;
        //maybe change to datetime?
        private float timestamp;

        /// <summary>
        /// Constructs an Affective using an EmoState
        /// </summary>
        public Affective(EmoState es)
        {
            shortExcitementLvl = es.AffectivGetExcitementShortTermScore();
            longExcitementLvl = es.AffectivGetExcitementLongTermScore();
            frustrationLvl = es.AffectivGetFrustrationScore();
            meditationLvl = es.AffectivGetMeditationScore();
            valenceLvl = es.AffectivGetValenceScore();
            engagementBoredomLvl = es.AffectivGetEngagementBoredomScore();
            smileLvl = es.ExpressivGetSmileExtent();
            busy = !es.CognitivIsActive();//inverted bool, as to check if busy seems more appropriate
            signalStrength = es.GetWirelessSignalStatus();
            timestamp = es.GetTimeFromStart();
        }

        /// <summary>
        /// Short Term Excitement Getter and Setter
        /// </summary>
        public float ShortExcitementLevel
        {
            get{return shortExcitementLvl;}
            set{shortExcitementLvl = value;}
        }

        /// <summary>
        /// Long Term Excitement Getter and Setter
        /// </summary>
        public float LongExcitementLevel
        {
            get{return longExcitementLvl;}
            set{longExcitementLvl = value;}
        }

        /// <summary>
        /// Frustration Getter and Setter
        /// </summary>
        public float FrustrationLevel
        {
            get{return frustrationLvl;}
            set{frustrationLvl = value;}
        }

        /// <summary>
        /// Meditation Getter and Setter
        /// </summary>
        public float MeditationLevel
        {
            get{return meditationLvl;}
            set{meditationLvl = value;}
        }

        /// <summary>
        /// Valence Getter and Setter
        /// </summary>
        public float ValenceLevel
        {
            get{ return valenceLvl; }            
            set{ valenceLvl = value; }
        }

        /// <summary>
        /// Engagement/Boredom Getter and Setter
        /// </summary>
        public float EngagementBoredomLevel
        {
            get{ return engagementBoredomLvl; }
            set{ engagementBoredomLvl = value; }
        }

        /// <summary>
        /// Smile Getter and Setter
        /// </summary>
        public float SmileLevel
        {
            get{ return smileLvl; }
            set{ smileLvl = value; }
        }

        /// <summary>
        /// Checks if the state is busy
        /// </summary>
        public bool Busy
        {
            get { return busy; }
        }

        /// <summary>
        /// Gets EPOC headset signal strength
        /// </summary>
        public EdkDll.EE_SignalStrength_t SignalStrength
        {
            get{ return signalStrength; }            
        }

        /// <summary>
        /// Gets a timestamp
        /// </summary>
        public float Timestamp
        {
            get { return timestamp; }
        }

    }
}
