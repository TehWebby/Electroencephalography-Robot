using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emotiv;

namespace EEG_Gateway
{
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

        //setters added but likely wont need to modify the object
        public float ShortExcitementLevel
        {
            //shortExcitementLvl = es.AffectivGetExcitementShortTermScore();
            get{
                return shortExcitementLvl;
            }
            set{
                shortExcitementLvl = value;
            }
        }
      
        public float LongExcitementLevel
        {
            //longExcitementLvl = es.AffectivGetExcitementLongTermScore();
            get{
                return longExcitementLvl;
            }
            set{
                longExcitementLvl = value;
            }
        }
        public float FrustrationLevel
        {
            //frustrationLvl = es.AffectivGetFrustrationScore();
            get{ 
                return frustrationLvl;
            }
            set
            {
                frustrationLvl = value;
            }
        }
        public float MeditationLevel
        {
            get{
                return meditationLvl;
            }
            set
            {
                //meditationLvl = es.AffectivGetMeditationScore();
                meditationLvl = value;
            }
            
        }
        public float ValenceLevel
        {
            //valenceLvl = es.AffectivGetValenceScore();
            get{ return valenceLvl; }            
            set{ valenceLvl = value; }
        }
        public float EngagementBoredomLevel
        {
            //engagementBoredomLvl = es.AffectivGetEngagementBoredomScore();
            get{ return engagementBoredomLvl; }
            set{ engagementBoredomLvl = value; }
        }
        public float SmileLevel
        {
            //smileLvl = es.ExpressivGetSmileExtent();
            get{ return smileLvl; }
            set{ smileLvl = value; }
        }
        
        public bool Busy
        {
            get { return busy; }
        }
        public EdkDll.EE_SignalStrength_t SignalStrength
        {
            get{ return signalStrength; }            
        }
        public float Timestamp
        {
            get { return timestamp; }
        }

    }
}
