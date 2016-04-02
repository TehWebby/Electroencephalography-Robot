//-----------------------------------------------------------------------
//  Author: Shaun Webb
//  University: Sheffield Hallam University
//  Website: shaunwebb.co.uk
//  Github: TehWebby
//-----------------------------------------------------------------------

using System;
using System.Windows.Forms;
using Emotiv;
using System.Linq;

namespace EEG_Gateway
{
    /// <summary>
    /// Train a users cognitive actions based on EEG
    /// </summary>
    public class CognitiveTraining : Form
    {        
        public uint userId = 0; ///< EPOC trainer ID
        public bool neutral = true; ///< Cognitive action neutral
        public bool push = false; ///< Cognitive action push/forward
        public bool pull = false; ///< Cognitive action pull/backwards
        public bool left = false; ///< Cognitive action left
        public bool right = false; ///< Cognitive action right

        bool write = false;
        int numOfActions = 0;
        int totalActions = 0;
        int finalAction = 0;
        public Profile userProfile = new Profile(); ///< Creates a new user Profile
        public string profileName; ///< User Profile Name
        bool[] action = new bool[4]; //used to determine how many actions to activate
        bool[] notComplete = new bool[4];

        /// <summary>
        /// Total possible Cognitive actions using EPOC SDK
        /// </summary>
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
        private Label newProfileHeaderLbl;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Initializes training form
        /// </summary>
        public void Initialize()
        {
            InitializeComponent();
            Show();
        }

        /// <summary>
        /// Initializes training form components
        /// </summary>
        public void InitializeComponent()
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
            this.newProfileHeaderLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // profileNameTxt
            // 
            this.profileNameTxt.Location = new System.Drawing.Point(131, 72);
            this.profileNameTxt.Name = "profileNameTxt";
            this.profileNameTxt.Size = new System.Drawing.Size(165, 22);
            this.profileNameTxt.TabIndex = 0;
            // 
            // newProfileLbl
            // 
            this.newProfileLbl.AutoSize = true;
            this.newProfileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newProfileLbl.Location = new System.Drawing.Point(146, 51);
            this.newProfileLbl.Name = "newProfileLbl";
            this.newProfileLbl.Size = new System.Drawing.Size(125, 18);
            this.newProfileLbl.TabIndex = 1;
            this.newProfileLbl.Text = "New Profile name";
            // 
            // trainActionsLbl
            // 
            this.trainActionsLbl.AutoSize = true;
            this.trainActionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainActionsLbl.Location = new System.Drawing.Point(129, 113);
            this.trainActionsLbl.Name = "trainActionsLbl";
            this.trainActionsLbl.Size = new System.Drawing.Size(192, 18);
            this.trainActionsLbl.TabIndex = 9;
            this.trainActionsLbl.Text = "Select which actions to train";
            // 
            // startTrainBtn
            // 
            this.startTrainBtn.Location = new System.Drawing.Point(132, 225);
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
            this.trainBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainBox4.Location = new System.Drawing.Point(223, 180);
            this.trainBox4.Name = "trainBox4";
            this.trainBox4.Size = new System.Drawing.Size(83, 24);
            this.trainBox4.TabIndex = 11;
            this.trainBox4.Text = "RIGHT";
            this.trainBox4.UseVisualStyleBackColor = true;
            // 
            // trainBox3
            // 
            this.trainBox3.AutoSize = true;
            this.trainBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainBox3.Location = new System.Drawing.Point(132, 180);
            this.trainBox3.Name = "trainBox3";
            this.trainBox3.Size = new System.Drawing.Size(72, 24);
            this.trainBox3.TabIndex = 12;
            this.trainBox3.Text = "LEFT";
            this.trainBox3.UseVisualStyleBackColor = true;
            // 
            // trainBox2
            // 
            this.trainBox2.AutoSize = true;
            this.trainBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainBox2.Location = new System.Drawing.Point(223, 153);
            this.trainBox2.Name = "trainBox2";
            this.trainBox2.Size = new System.Drawing.Size(85, 24);
            this.trainBox2.TabIndex = 13;
            this.trainBox2.Text = "DOWN";
            this.trainBox2.UseVisualStyleBackColor = true;
            // 
            // trainBox1
            // 
            this.trainBox1.AutoSize = true;
            this.trainBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainBox1.Location = new System.Drawing.Point(132, 153);
            this.trainBox1.Name = "trainBox1";
            this.trainBox1.Size = new System.Drawing.Size(54, 24);
            this.trainBox1.TabIndex = 14;
            this.trainBox1.Text = "UP";
            this.trainBox1.UseVisualStyleBackColor = true;
            // 
            // trainingTimer
            // 
            this.trainingTimer.Tick += new System.EventHandler(this.trainingTimer_Tick);
            // 
            // newProfileHeaderLbl
            // 
            this.newProfileHeaderLbl.AutoSize = true;
            this.newProfileHeaderLbl.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newProfileHeaderLbl.Location = new System.Drawing.Point(40, 9);
            this.newProfileHeaderLbl.Name = "newProfileHeaderLbl";
            this.newProfileHeaderLbl.Size = new System.Drawing.Size(390, 37);
            this.newProfileHeaderLbl.TabIndex = 15;
            this.newProfileHeaderLbl.Text = "Create a new EPOC EEG Profile";
            // 
            // CognitiveTraining
            // 
            this.ClientSize = new System.Drawing.Size(429, 293);
            this.Controls.Add(this.newProfileHeaderLbl);
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

        /// <summary>
        /// Start Training button event
        /// </summary>
        public void startTrainBtn_Click(object sender, EventArgs e)
        {
            profileName = profileNameTxt.Text;
            profileName = "_" + profileName + ".emu";

            for (int i = 0; i < notComplete.Length; i++)
                notComplete[i] = true;
            
            action = checkBoxTrainingCalc(action);

            for (int i = 0; i < action.Length; i++)
            {
                if (action[i])
                {
                    totalActions++;
                    finalAction = i;
                }
                    
            }
            /*
            Action reminder
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

        /// <summary>
        /// Check box components checker
        /// </summary>
        public bool[] checkBoxTrainingCalc(bool[] action)
        {
            //Go through each checkbox and set bool array to true
            int i = 0; /** \brief interator */
            foreach (Control c in Controls)
            {
                if ((c is CheckBox) && ((CheckBox)c).Checked)
                    action[i-1] = true;
                i++;
            }
            return action;
        }

        /// <summary>
        /// Starts cognitive training
        /// </summary>
        public void StartCognitivTraining(EdkDll.EE_CognitivAction_t cognitivAction)
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
            /*else if ((cognitivAction == EdkDll.EE_CognitivAction_t.COG_LEFT) && (action[2]))
            {
                Console.WriteLine("Left Training");
                //EmoEngine.Instance.CognitivSetActiveActions((uint)userId, 0x0010);
            }
            else if ((cognitivAction == EdkDll.EE_CognitivAction_t.COG_RIGHT) && (action[3]))
            {
                Console.WriteLine("Right Training");
                //    EmoEngine.Instance.CognitivSetActiveActions((uint)userId, 0x0012);
            }*/

            EmoEngine.Instance.CognitivSetTrainingAction(userId, cognitivAction);
            EmoEngine.Instance.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_START);
        }

        /// <summary>
        /// Sets the allowed/restricted cognitive actions
        /// </summary>
        public void SetActiveActions()
        {
            uint cognitivActions = 0x0000;
            for (int i = 1; i < cognitivActionList.Length; i++)
            {
                cognitivActions = cognitivActions | (uint)cognitivActionList[i];
            }
            //EmoEngine.Instance.CognitivSetActiveActions(userId, cognitivActions);
        }

        /// <summary>
        /// Training completed
        /// </summary>
        public void Instance_CognitivTrainingCompleted(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("Cognitiv Training completed");
            if ((notComplete[0]) && (action[0]))
                push = true;
            else if ((notComplete[1]) && (action[1]))
                pull = true;
            /*else if ((notComplete[2]) && (action[2]))
                left = true;
            else if ((notComplete[3]) && (action[3]))
                right = true;*/
            //else
                //write = false;
            
            if (write)
                EmoEngine.Instance.EE_SaveUserProfile((uint)userId, "Profiles\\" + profileName);

            if (notComplete[finalAction] == false)
            {
                //EmoEngine.Instance.Disconnect();
                trainingTimer.Enabled = false;
                Dispose();
                Close();
            }
        }

        /// <summary>
        /// Cognitive Training Succeeded
        /// </summary>
        public void Instance_CognitivTrainingSucceeded(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("Cognitiv Training Succeeded");
            EmoEngine.Instance.CognitivSetTrainingControl(userId, EdkDll.EE_CognitivTrainingControl_t.COG_ACCEPT);
        }

        /// <summary>
        /// Cognitive Training Started
        /// </summary>
        public void Instance_CognitivTrainingStarted(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("Cognitiv Training started");
        }

        /// <summary>
        /// Update and move to next Cognitive action
        /// </summary>
        public void Instance_CognitivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
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
                /*if (currentAction == EdkDll.EE_CognitivAction_t.COG_LEFT)
                    Console.WriteLine("Current Action is COG_LEFT");
                if (currentAction == EdkDll.EE_CognitivAction_t.COG_RIGHT)
                    Console.WriteLine("Current Action is COG_RIGHT");*/
                float power = es.CognitivGetCurrentActionPower();
                Console.WriteLine("Current action power {0}: " + power);
            }
            
        }

        /// <summary>
        /// Cognitive Action updated
        /// </summary>
        public void Instance_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            //Console.WriteLine("EmoState Updated..."); 

            if (neutral)
            {
                //7 highest sensitivity
                EmoEngine.Instance.CognitivSetActivationLevel(0, 7);

                EdkDll.EE_CognitivAction_t actions =
                EdkDll.EE_CognitivAction_t.COG_PUSH
                | EdkDll.EE_CognitivAction_t.COG_PULL;
                /*| EdkDll.EE_CognitivAction_t.COG_LEFT
                | EdkDll.EE_CognitivAction_t.COG_RIGHT;*/

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
            /*else if (left)
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
            }*/

            

            //write is the save bool. Use this in the last training step (or each)
        }

        /// <summary>
        /// Process training timer
        /// </summary>
        public void trainingTimer_Tick(object sender, EventArgs e)
        {
            EmoEngine.Instance.ProcessEvents();
        }
    }
}
