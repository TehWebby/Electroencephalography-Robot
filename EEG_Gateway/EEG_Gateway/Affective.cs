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

        public void setShortExcitLvl(EmoState es)
        {
            this.shortExcitementLvl = es.AffectivGetExcitementShortTermScore();
        }
        public void setLongExcitLvl(EmoState es)
        {
            this.longExcitementLvl = es.AffectivGetExcitementLongTermScore();
        }
        public void setFrustLvl(EmoState es)
        {
            this.frustrationLvl = es.AffectivGetFrustrationScore();
        }
        public void setMeditLvl(EmoState es)
        {
            this.meditationLvl = es.AffectivGetMeditationScore();
        }

        //set valance + more


        public float getShortExcitLvl()
        {
            return shortExcitementLvl;
        }
        public float getLongExcitLvl()
        {
            return longExcitementLvl;
        }    
        public float getFrustLvl()
        {
            return frustrationLvl;
        }
        public float getMeditLvl()
        {
            return meditationLvl;
        }
        public float getValenceLvl()
        {
            return valenceLvl;
        }
        public float getEngagementBoredomLvl()
        {
            return engagementBoredomLvl;
        }
        public float getSmileLvl()
        {
            return smileLvl;
        }
        public bool getBusy()
        {
            return busy;
        }
        public EdkDll.EE_SignalStrength_t getSignalStrength()
        {
            return signalStrength;
        }
        public float getTimestamp()
        {
            return timestamp;
        }

    }
}
