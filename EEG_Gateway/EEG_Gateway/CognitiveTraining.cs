using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emotiv;
namespace EEG_Gateway
{
    public partial class CognitiveTraining //: Form
    {
        uint userId = 0;
        bool neutral = true;
        bool push = false;
        bool pull = false;
        bool left = false;
        bool right = false;

        bool write = false;
        int numOfActions = 0;
        Profile userProfile = new Profile();

        public static EdkDll.EE_CognitivAction_t[] cognitivActionList = {
                                                                     EdkDll.EE_CognitivAction_t.COG_NEUTRAL,
                                                                     EdkDll.EE_CognitivAction_t.COG_PUSH,
                                                                     EdkDll.EE_CognitivAction_t.COG_PULL,
                                                                     EdkDll.EE_CognitivAction_t.COG_LIFT,
                                                                     EdkDll.EE_CognitivAction_t.COG_DROP,
                                                                     EdkDll.EE_CognitivAction_t.COG_LEFT,
                                                                     EdkDll.EE_CognitivAction_t.COG_RIGHT,
                                                                     EdkDll.EE_CognitivAction_t.COG_ROTATE_LEFT,
                                                                     EdkDll.EE_CognitivAction_t.COG_ROTATE_RIGHT,
                                                                     EdkDll.EE_CognitivAction_t.COG_ROTATE_CLOCKWISE,
                                                                     EdkDll.EE_CognitivAction_t.COG_ROTATE_COUNTER_CLOCKWISE,
                                                                     EdkDll.EE_CognitivAction_t.COG_ROTATE_FORWARDS,
                                                                     EdkDll.EE_CognitivAction_t.COG_ROTATE_REVERSE,
                                                                     EdkDll.EE_CognitivAction_t.COG_DISAPPEAR
                                                                 };
        string profileName;
        

        public void Initialize()
        {
            Console.Write("Enter Profile Name: ");
            /*Console.Write("Enter Profile Name: ");
            profileName = Console.ReadLine();
            profileName = "_" + profileName + ".emu";
            Console.WriteLine(profileName);


            EmoEngine.Instance.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(Instance_EmoStateUpdated);
            EmoEngine.Instance.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(Instance_CognitivEmoStateUpdated);
            EmoEngine.Instance.CognitivTrainingStarted += new EmoEngine.CognitivTrainingStartedEventEventHandler(Instance_CognitivTrainingStarted);
            EmoEngine.Instance.CognitivTrainingSucceeded += new EmoEngine.CognitivTrainingSucceededEventHandler(Instance_CognitivTrainingSucceeded);
            EmoEngine.Instance.CognitivTrainingCompleted += new EmoEngine.CognitivTrainingCompletedEventHandler(Instance_CognitivTrainingCompleted);

            EmoEngine.Instance.Connect();*/
        }
    }
}
