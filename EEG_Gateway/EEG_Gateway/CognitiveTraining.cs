using System;
using System.Windows.Forms;
using Emotiv;
using System.Linq;

namespace EEG_Gateway
{
    public class CognitiveTraining : Form
    {
        uint userId = 0;
        bool neutral = true;
        bool push = false;
        bool pull = false;
        bool left = false;
        bool right = false;

        bool write = false;
        int numOfActions = 0;
        int totalActions = 0;
        Profile userProfile = new Profile();
        string profileName;
        bool[] action = new bool[4]; //used to determine how many actions to activate
        bool[] notComplete = new bool[4];

        //Total possible Cognitive actions using EPOC SDK
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
        private TextBox profileNameTxt;
        private Label newProfileLbl;
        private Label trainActionsLbl;
        private Button startTrainBtn;
        private CheckBox trainBox4;
        private CheckBox trainBox3;
        private CheckBox trainBox2;
        private CheckBox trainBox1;
        private Timer trainingTimer;
        private System.ComponentModel.IContainer components;
        

        public void Initialize()
        {
            InitializeComponent();
            Show();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CognitiveTraining));
            this.profileNameTxt = new System.Windows.Forms.TextBox();
            this.newProfileLbl = new System.Windows.Forms.Label();
            this.trainActionsLbl = new System.Windows.Forms.Label();
            this.startTrainBtn = new System.Windows.Forms.Button();
            this.trainBox4 = new System.Windows.Forms.CheckBox();
            this.trainBox3 = new System.Windows.Forms.CheckBox();
            this.trainBox2 = new System.Windows.Forms.CheckBox();
            this.trainBox1 = new System.Windows.Forms.CheckBox();
            this.trainingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // profileNameTxt
            // 
            this.profileNameTxt.Location = new System.Drawing.Point(121, 77);
            this.profileNameTxt.Name = "profileNameTxt";
            this.profileNameTxt.Size = new System.Drawing.Size(165, 22);
            this.profileNameTxt.TabIndex = 0;
            // 
            // newProfileLbl
            // 
            this.newProfileLbl.AutoSize = true;
            this.newProfileLbl.Location = new System.Drawing.Point(121, 54);
            this.newProfileLbl.Name = "newProfileLbl";
            this.newProfileLbl.Size = new System.Drawing.Size(118, 17);
            this.newProfileLbl.TabIndex = 1;
            this.newProfileLbl.Text = "New Profile name";
            // 
            // trainActionsLbl
            // 
            this.trainActionsLbl.AutoSize = true;
            this.trainActionsLbl.Location = new System.Drawing.Point(108, 139);
            this.trainActionsLbl.Name = "trainActionsLbl";
            this.trainActionsLbl.Size = new System.Drawing.Size(183, 17);
            this.trainActionsLbl.TabIndex = 9;
            this.trainActionsLbl.Text = "Select which actions to train";
            // 
            // startTrainBtn
            // 
            this.startTrainBtn.Location = new System.Drawing.Point(124, 323);
            this.startTrainBtn.Name = "startTrainBtn";
            this.startTrainBtn.Size = new System.Drawing.Size(148, 39);
            this.startTrainBtn.TabIndex = 10;
            this.startTrainBtn.Text = "Start Training";
            this.startTrainBtn.UseVisualStyleBackColor = true;
            this.startTrainBtn.Click += new System.EventHandler(this.startTrainBtn_Click);
            // 
            // trainBox4
            // 
            this.trainBox4.AutoSize = true;
            this.trainBox4.Location = new System.Drawing.Point(231, 206);
            this.trainBox4.Name = "trainBox4";
            this.trainBox4.Size = new System.Drawing.Size(73, 21);
            this.trainBox4.TabIndex = 11;
            this.trainBox4.Text = "RIGHT";
            this.trainBox4.UseVisualStyleBackColor = true;
            // 
            // trainBox3
            // 
            this.trainBox3.AutoSize = true;
            this.trainBox3.Location = new System.Drawing.Point(111, 206);
            this.trainBox3.Name = "trainBox3";
            this.trainBox3.Size = new System.Drawing.Size(64, 21);
            this.trainBox3.TabIndex = 12;
            this.trainBox3.Text = "LEFT";
            this.trainBox3.UseVisualStyleBackColor = true;
            // 
            // trainBox2
            // 
            this.trainBox2.AutoSize = true;
            this.trainBox2.Location = new System.Drawing.Point(231, 179);
            this.trainBox2.Name = "trainBox2";
            this.trainBox2.Size = new System.Drawing.Size(74, 21);
            this.trainBox2.TabIndex = 13;
            this.trainBox2.Text = "DOWN";
            this.trainBox2.UseVisualStyleBackColor = true;
            // 
            // trainBox1
            // 
            this.trainBox1.AutoSize = true;
            this.trainBox1.Location = new System.Drawing.Point(111, 179);
            this.trainBox1.Name = "trainBox1";
            this.trainBox1.Size = new System.Drawing.Size(49, 21);
            this.trainBox1.TabIndex = 14;
            this.trainBox1.Text = "UP";
            this.trainBox1.UseVisualStyleBackColor = true;
            // 
            // trainingTimer
            // 
            this.trainingTimer.Tick += new System.EventHandler(this.trainingTimer_Tick);
            // 
            // CognitiveTraining
            // 
            this.ClientSize = new System.Drawing.Size(414, 403);
            this.Controls.Add(this.trainBox1);
            this.Controls.Add(this.trainBox2);
            this.Controls.Add(this.trainBox3);
            this.Controls.Add(this.trainBox4);
            this.Controls.Add(this.startTrainBtn);
            this.Controls.Add(this.trainActionsLbl);
            this.Controls.Add(this.newProfileLbl);
            this.Controls.Add(this.profileNameTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CognitiveTraining";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        private void startTrainBtn_Click(object sender, EventArgs e)
        {
            profileName = profileNameTxt.Text;
            profileName = "_" + profileName + ".emu";

            for (int i = 0; i < notComplete.Length; i++)
                notComplete[i] = true;
            
            action = checkBoxTrainingCalc(action);

            for (int i = 0; i < action.Length; i++)
            {
                if (action[i])
                    totalActions++;
            }
            /*
            action[0] == UP
            action[1] == DOWN
            action[2] == LEFT
            action[3] == RIGHT
            */
            //then use the action bool array to only allow certain cognitive actions to be trained
            MessageBox.Show(profileName);

            trainingTimer.Enabled = true;
            EmoEngine.Instance.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(Instance_EmoStateUpdated);
            EmoEngine.Instance.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(Instance_CognitivEmoStateUpdated);
            EmoEngine.Instance.CognitivTrainingStarted += new EmoEngine.CognitivTrainingStartedEventEventHandler(Instance_CognitivTrainingStarted);
            EmoEngine.Instance.CognitivTrainingSucceeded += new EmoEngine.CognitivTrainingSucceededEventHandler(Instance_CognitivTrainingSucceeded);
            EmoEngine.Instance.CognitivTrainingCompleted += new EmoEngine.CognitivTrainingCompletedEventHandler(Instance_CognitivTrainingCompleted);

            EmoEngine.Instance.Connect();
        }

        private bool[] checkBoxTrainingCalc(bool[] action)
        {
            //Go through each checkbox and set bool array to true
            int i = 0;
            foreach (Control c in Controls)
            {
                if ((c is CheckBox) && ((CheckBox)c).Checked)
                    action[i] = true;
                i++;
            }
            return action;
        }


        void StartCognitivTraining(EdkDll.EE_CognitivAction_t cognitivAction)
        {
            if (cognitivAction == EdkDll.EE_CognitivAction_t.COG_NEUTRAL)
            {
                Console.WriteLine("Neutral Training");
                //    EmoEngine.Instance.CognitivSetActiveActions((uint)userId, 0x0000);
            }
            else if ((cognitivAction == EdkDll.EE_CognitivAction_t.COG_PUSH) && (action[0]))
            {
                Console.WriteLine("Push Training");
                //    EmoEngine.Instance.CognitivSetActiveActions((uint)userId, 0x0002);
            }
            else if ((cognitivAction == EdkDll.EE_CognitivAction_t.COG_PULL) && (action[1]))
            {
                Console.WriteLine("Pull Training");
                //    EmoEngine.Instance.CognitivSetActiveActions((uint)userId, 0x0004);
            }
            else if ((cognitivAction == EdkDll.EE_CognitivAction_t.COG_LEFT) && (action[2]))
            {
                Console.WriteLine("Left Training");
                //EmoEngine.Instance.CognitivSetActiveActions((uint)userId, 0x0010);
            }
            else if ((cognitivAction == EdkDll.EE_CognitivAction_t.COG_RIGHT) && (action[3]))
            {
                Console.WriteLine("Right Training");
                //    EmoEngine.Instance.CognitivSetActiveActions((uint)userId, 0x0012);
            }

            EmoEngine.Instance.CognitivSetTrainingAction(userId, cognitivAction);
            EmoEngine.Instance.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
        }

        void SetActiveActions()
        {
            uint cognitivActions = 0x0000;
            for (int i = 1; i < cognitivActionList.Length; i++)
            {
                cognitivActions = cognitivActions | (uint)cognitivActionList[i];
            }
            //EmoEngine.Instance.CognitivSetActiveActions(userId, cognitivActions);
        }

        void Instance_CognitivTrainingCompleted(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("Cognitiv Training completed");
            if ((notComplete[0]) && (action[0]))
                push = true;
            else if ((notComplete[1]) && (action[1]))
                pull = true;
            else if ((notComplete[2]) && (action[2]))
                left = true;
            else if ((notComplete[3]) && (action[3]))
                right = true;
            //else
                //write = false;
            
            if (write)
                EmoEngine.Instance.EE_SaveUserProfile((uint)userId, "Profiles\\" + profileName);
        }

        void Instance_CognitivTrainingSucceeded(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("Cognitiv Training Succeeded");
            EmoEngine.Instance.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ACCEPT);
        }

        void Instance_CognitivTrainingStarted(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("Cognitiv Training started");
        }

        void Instance_CognitivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            /*
            if (numOfActions >= totalActions)//total of action[] that is true
            {
                Console.WriteLine("Cognitiv EmoState Updated...");
                EmoState es = e.emoState;
                EdkDll.EE_CognitivAction_t currentAction = es.CognitivGetCurrentAction();
                if (currentAction == EdkDll.EE_CognitivAction_t.COG_NEUTRAL)
                    Console.WriteLine("Current Action is COG_NEUTRAL");
                if (currentAction == EdkDll.EE_CognitivAction_t.COG_PUSH)
                    Console.WriteLine("Current Action is COG_PUSH");
                if (currentAction == EdkDll.EE_CognitivAction_t.COG_PULL)
                    Console.WriteLine("Current Action is COG_PULL");
                if (currentAction == EdkDll.EE_CognitivAction_t.COG_LEFT)
                    Console.WriteLine("Current Action is COG_LEFT");
                if (currentAction == EdkDll.EE_CognitivAction_t.COG_RIGHT)
                    Console.WriteLine("Current Action is COG_RIGHT");
                float power = es.CognitivGetCurrentActionPower();
                Console.WriteLine("Current action power {0}: " + power);
            }
            */
        }

        void Instance_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            //Console.WriteLine("EmoState Updated..."); 

            if (neutral)
            {
                //7 highest sensitivity
                EmoEngine.Instance.CognitivSetActivationLevel(0, 4);

                EdkDll.EE_CognitivAction_t actions =
                EdkDll.EE_CognitivAction_t.COG_PULL
                | EdkDll.EE_CognitivAction_t.COG_PUSH
                | EdkDll.EE_CognitivAction_t.COG_LEFT
                | EdkDll.EE_CognitivAction_t.COG_RIGHT;

                EmoEngine.Instance.CognitivSetActiveActions((uint)userId, (UInt32)actions);

                //EmoEngine.Instance.CognitivSetActiveActions((uint)userId, 0x0000 | 0x0002 | 0x0004 | 0x0010 | 0x0012);
                StartCognitivTraining(EdkDll.EE_CognitivAction_t.COG_NEUTRAL);
                neutral = false;
                numOfActions++;
            }
            if (push)
            {
                StartCognitivTraining(EdkDll.EE_CognitivAction_t.COG_PUSH);
                push = false;
                write = true;
                numOfActions++;
                notComplete[0] = false;
            }
            else if (pull)
            {
                StartCognitivTraining(EdkDll.EE_CognitivAction_t.COG_PULL);
                pull = false;
                write = true;
                numOfActions++;
                notComplete[1] = false;
            }
            else if (left)
            {
                StartCognitivTraining(EdkDll.EE_CognitivAction_t.COG_LEFT);
                write = true;
                left = false;
                numOfActions++;
                notComplete[2] = false;
            }
            else if (right)
            {
                StartCognitivTraining(EdkDll.EE_CognitivAction_t.COG_RIGHT);
                write = true;
                right = false;
                numOfActions++;
                notComplete[3] = false;
            }



            //write is the save bool. Use this in the last training step (or each)
        }

        private void trainingTimer_Tick(object sender, EventArgs e)
        {
            EmoEngine.Instance.ProcessEvents();
        }
    }
}
