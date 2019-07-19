using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MouseKeyboardLibrary;
using System.Threading;
using System.Speech.Recognition;
using System.IO;
using System.Xml.Serialization;

namespace GlobalMacroRecorder
{
    public partial class MacroForm : Form
    {
        #region ATTRIBUTES
        /****************** ATTRIBUTES ******************/
        private List<List<MacroEvent>> m_listevents;
        private List<MacroEvent> m_events;
        private int m_lastTimeRecorded;
        private int m_numberID;
        private bool m_speechRecognitionActivate;
        private List<System.Windows.Forms.RadioButton> m_listOfRadioButton;
        private ASR m_ASR;

        private MouseHook m_mouseHook;
        private KeyboardHook m_keyboardHook;

        private List<List<MacroEventSerializable>> m_listeventsSerializable;
        private List<MacroEventSerializable> m_eventsSerializable;
        #endregion


        #region CONSTRUCTOR
        /****************** CONSTRUCTOR ******************/
        public MacroForm()
        {
            InitializeComponent();//Initialize the Form

            #region Initialize attributes

            #region Initialize primitive attributes
            //Initialize attributes
            m_listevents = new List<List<MacroEvent>>();
            m_events = new List<MacroEvent>();
            m_lastTimeRecorded = 0;
            m_numberID = 0;
            m_speechRecognitionActivate = false;
            m_listOfRadioButton = new List<System.Windows.Forms.RadioButton>();

            m_listeventsSerializable = new List<List<MacroEventSerializable>>();
            m_eventsSerializable = new List<MacroEventSerializable>();
            #endregion

            #region Initialize member objects attributes
            //Initialize member objects attributes
            m_mouseHook = new MouseHook();
            m_keyboardHook = new KeyboardHook();
            m_ASR = new ASR(this);
            #endregion

            #endregion

            #region Initialize listener to record mouse action
            //Listener to record mouse action
            m_mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);//Record the movement of mouse
            m_mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);//Record the clic down of mouse (press)
            m_mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);//Record the clic up of mouse (release)
            #endregion

            #region Initialize listener to record keyboard action
            //Listener to record keyboard action
            m_keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);//Record the keyboard key down
            m_keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);//Record the keyboard key up
            #endregion

            #region Disable unused button
            recordStopButton.Enabled = false;//Disable the button to stop the record
            playBackMacroButton.Enabled = false;//Disable the button to playBack the record
            #endregion
        }
        #endregion


        #region GETTER
        /****************** GETTER ******************/
        //Get the attribute m_listOfRadioButton
        public List<System.Windows.Forms.RadioButton> getm_listOfRadioButton()
        {
            return m_listOfRadioButton;
        }

        //Get the RadioButton by its id
        public System.Windows.Forms.RadioButton getRadioButtonByEventId(int idOfEvent)
        {
            #region try to get the radio button of event idOfEvent
            //try to get the radio button of event idOfEvent
            try
            {
                return m_listOfRadioButton[idOfEvent--];
            }
            //Otherwise, try to get the radio button of event 1
            catch
            {
                try
                {
                    return m_listOfRadioButton[1];
                }
                //Otherwise, return null
                catch
                {
                    return null;
                }
            }
            #endregion
        }
        #endregion


        #region METHODS
        /****************** METHODS ******************/

        #region Methods to manage the record of user actions

        //Record the movement of mouse
        private void mouseHook_MouseMove(object sender, MouseEventArgs e)
        {
            int TimeSinceLastEvent = Environment.TickCount - m_lastTimeRecorded;
            m_events.Add(new MacroEvent(MacroEventType.MouseMove, e, TimeSinceLastEvent));
            m_lastTimeRecorded = Environment.TickCount;
            MouseEventArgsSerializable eSerializable = new MouseEventArgsSerializable(e.Button, e.Clicks, e.X, e.Y, e.Delta);
            m_eventsSerializable.Add(new MacroEventSerializable(MacroEventType.MouseMove, eSerializable, TimeSinceLastEvent));
        }

        //Record the clic down of mouse (press)
        private void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            int TimeSinceLastEvent = Environment.TickCount - m_lastTimeRecorded;
            m_events.Add(new MacroEvent(MacroEventType.MouseDown, e, TimeSinceLastEvent));
            m_lastTimeRecorded = Environment.TickCount;
            MouseEventArgsSerializable eSerializable = new MouseEventArgsSerializable(e.Button, e.Clicks, e.X, e.Y, e.Delta);
            m_eventsSerializable.Add(new MacroEventSerializable(MacroEventType.MouseDown, eSerializable, TimeSinceLastEvent));
        }

        //Record the clic up of mouse (release)
        private void mouseHook_MouseUp(object sender, MouseEventArgs e)
        {
            int TimeSinceLastEvent = Environment.TickCount - m_lastTimeRecorded;
            m_events.Add(new MacroEvent(MacroEventType.MouseUp, e, TimeSinceLastEvent));
            m_lastTimeRecorded = Environment.TickCount;
            MouseEventArgsSerializable eSerializable = new MouseEventArgsSerializable(e.Button, e.Clicks, e.X, e.Y, e.Delta);
            m_eventsSerializable.Add(new MacroEventSerializable(MacroEventType.MouseUp, eSerializable, TimeSinceLastEvent));
        }


        //Record the keyboard key down
        private void keyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            int TimeSinceLastEvent = Environment.TickCount - m_lastTimeRecorded;
            m_events.Add(new MacroEvent(MacroEventType.KeyDown, e, TimeSinceLastEvent));
            m_lastTimeRecorded = Environment.TickCount;
            KeysEventArgsSerializable eSerializable = new KeysEventArgsSerializable(e.KeyData);
            m_eventsSerializable.Add(new MacroEventSerializable(MacroEventType.KeyDown, eSerializable, TimeSinceLastEvent));
        }


        //Record the keyboard key up
        private void keyboardHook_KeyUp(object sender, KeyEventArgs e)
        {
            int TimeSinceLastEvent = Environment.TickCount - m_lastTimeRecorded;
            m_events.Add(new MacroEvent(MacroEventType.KeyUp, e, TimeSinceLastEvent));
            m_lastTimeRecorded = Environment.TickCount;
            KeysEventArgsSerializable eSerializable = new KeysEventArgsSerializable(e.KeyData);
            m_eventsSerializable.Add(new MacroEventSerializable(MacroEventType.KeyUp, eSerializable, TimeSinceLastEvent));
        }

        #endregion


        #region Methods to manage the enable state of buttons

        //Enable used button when we Start Record
        private void enableUsedButtonWhenStartRecord()
        {
            #region Enable recordStopButton Button
            recordStopButton.Enabled = true;//Enable recordStopButton Button
            #endregion
        }

        //Disable unused button when we Start Record
        private void disableUnusedButtonWhenStartRecord()
        {
            #region Disable recordStartButton Button
            recordStartButton.Enabled = false;//Disable recordStartButton Button
            #endregion

            #region Disable playBackMacroButton Button
            playBackMacroButton.Enabled = false;//Disable playBackMacroButton Button
            #endregion

            #region For each RadioButton component in ScrollPanel of FormModePersonalize Form, disable RadioButton
            //For each component in ScrollPanel of FormModePersonalize Form
            foreach (System.Windows.Forms.RadioButton o in ScrollPanel.Controls)
            {
                    o.Enabled = false;//Disable RadioButton
            }
            #endregion
        }

        //Enable used button when we Stop Record
        private void enableUsedButtonWhenStopRecord()
        {
            #region Enable recordStartButton Button
            recordStartButton.Enabled = true;//Enable recordStartButton Button
            #endregion

            #region Enable playBackMacroButton Button
            playBackMacroButton.Enabled = true;//Enable playBackMacroButton Button
            #endregion

            #region For each RadioButton component in ScrollPanel of FormModePersonalize Form, enable RadioButton
            //For each component in ScrollPanel of FormModePersonalize Form
            foreach (System.Windows.Forms.RadioButton o in ScrollPanel.Controls)
            {
                o.Enabled = true;//Enable RadioButton
            }
            #endregion
        }

        //Disable unused button when we Stop Record
        private void disableUnusedButtonWhenStopRecord()
        {
            #region Disable recordStopButton Button
            recordStopButton.Enabled = false;//Disable recordStopButton Button
            #endregion
        }

        //Enable used button when we Playback Record Stop
        private void enableUsedButtonWhenPlaybackRecordStop()
        {
            #region Enable recordStartButton Button and update attribute m_isEnableRecordStartButton
            recordStartButton.Enabled = true;//Enable recordStartButton Button
            #endregion

            #region Enable recordStopButton Button and update attribute m_isEnableRecordStopButton
            recordStopButton.Enabled = false;//Enable recordStopButton Button
            #endregion

            #region Enable playBackMacroButton Button and update attribute m_isEnablePlayBackMacroButton
            playBackMacroButton.Enabled = true;//Enable playBackMacroButton Button
            #endregion

            #region For each RadioButton component in ScrollPanel of FormModePersonalize Form, enable RadioButton
            //For each component in ScrollPanel of FormModePersonalize Form
            foreach (System.Windows.Forms.RadioButton o in ScrollPanel.Controls)
            {
                o.Enabled = true;//Enable RadioButton
            }
            #endregion
        }

        //Disable unused button when we Playback Record
        private void disableUnusedButtonWhenPlaybackRecord()
        {
            #region Disable recordStartButton Button
            recordStartButton.Enabled = false;//Disable recordStartButton Button
            #endregion

            #region Disable recordStopButton Button
            recordStopButton.Enabled = false;//Disable recordStopButton Button
            #endregion

            #region Disable playBackMacroButton Button
            playBackMacroButton.Enabled = false;//Disable playBackMacroButton Button
            #endregion

            #region For each RadioButton component in ScrollPanel of FormModePersonalize Form, disable RadioButton
            //For each RadioButton component in ScrollPanel of FormModePersonalize Form
            foreach (System.Windows.Forms.RadioButton o in ScrollPanel.Controls)
            {
                o.Enabled = false;//Disable RadioButton
            }
            #endregion
        }

        #endregion


        #region Methods to manage the click on main buttons

        //Event when the user click on the Start button
        public void recordStartButton_Click(object sender, EventArgs e)
        {
            #region Enable/Disable used/unused button when we Start Record
            //Enable/Disable used/unused button when we Start Record
            disableUnusedButtonWhenStartRecord();//Disable unused button when we Start Record
            enableUsedButtonWhenStartRecord();//Enable used button when we Start Record
            #endregion

            #region Create new RadioButton dynamically for the event that we start to record

            #region Create new RadioButton variable, set it is name dynamically and update variable
            //Create new RadioButton dynamically for the event that we start to record
            m_numberID++;//Increment the number of event
            System.Windows.Forms.RadioButton radb = new System.Windows.Forms.RadioButton();//Create a RadioButton
            radb.Text = "Event" + m_numberID;//Set the text of RadioButton with the name Event following by the number of events
            Point lastLocationRadioButton=new System.Drawing.Point(0, 0);//Create a variable of type Point
            #endregion

            #region Uncheck all Radio button and check the last Radio button that we want to add dynamically
            //For each component in ScrollPanel of FormModePersonalize Form, we uncheck all Radio button
            foreach (object o in ScrollPanel.Controls)
            {
                //If the component is a RadioButton (i.e: If the type of component is a RadioButton).
                if (o is System.Windows.Forms.RadioButton)
                {
                    System.Windows.Forms.RadioButton currentRadioButton = (System.Windows.Forms.RadioButton)o;//Stock the component (which is a RadioButton) on a variable called currentRadioButton.
                    lastLocationRadioButton = currentRadioButton.Location;//Set the variable lastLocationRadioButton with the location of the current RadioButton.
                    //If the current RadioButton is checked
                    if (currentRadioButton.Checked == true)
                    {
                        currentRadioButton.Checked = false;//Uncheck all Radio button exept the last one.
                    }
                }
            }
            radb.Checked = true;//Check the last Radio button
            #endregion

            #region Set the position of the new Radio button
            //If it is the first record
            if (m_numberID == 1)
            {
                radb.Location = new System.Drawing.Point(10, 0);//Set the position of RadioButton in the FormModePersonalize Form
            }
            //If it is not the first record
            else
            {
                radb.Location = new System.Drawing.Point(10, lastLocationRadioButton.Y + 30);//Set the position of RadioButton in the FormModePersonalize Form
            }
            #endregion

            #region Add the new Radio button to the ScrollPanel
            ScrollPanel.Controls.Add(radb);//Add RadioButton in panel called ScrollPanel in FormModePersonalize Form
            #endregion

            #region Add the new Radio button to the list m_listOfRadioButton
            m_listOfRadioButton.Add(radb);//Add the new Radio button to the list m_listOfRadioButton
            #endregion

            #endregion

            #region Clear the list dedicated to store the action of user (MacroEvent) and start the TickCount
            m_events.Clear();
            m_lastTimeRecorded = Environment.TickCount;
            #endregion

            #region By default there are 10 items recognize in the grammar. So, if the user create more than 10 events, we start to add dynamically the number of event in the grammar
            //By default there are 10 items recognize in the grammar. So, if the user create more than 10 events, we start to add dynamically the number of event in the grammar
            if (m_numberID > 10)
            {
                m_ASR.addItemInGrammarAndReloadEngine("numbers", 0, m_numberID.ToString());
            }
            #endregion

            #region Start the record of keyboard and mouse action
            m_keyboardHook.Start();
            m_mouseHook.Start();
            #endregion
        }


        //Event when the user click on the Stop button
        public void recordStopButton_Click(object sender, EventArgs e)
        {
            #region Enable/Disable used/unused button when we Stop Record
            disableUnusedButtonWhenStopRecord();//Disable unused button when we Stop Record
            enableUsedButtonWhenStopRecord();//Enable used button when we Stop Record
            #endregion

            #region Stop the record
            m_keyboardHook.Stop();//Stop to record the keyboard input
            m_mouseHook.Stop();//Stop to record the mouse input
            #endregion

            #region Add the last record to the list of events
            //Add the last record to the m_listevents which contains the all lists of events.
            List<MacroEvent> testEvents = new List<MacroEvent>(m_events);//Make a copy of list m_events called testEvents. So now, m_events=testEvents.
            m_listevents.Add(testEvents);//Add the list testEvents which is a copy of m_events and which contains the last record. We do a copy because otherwise, it is added by reference.
            #endregion

            #region Add the last record to the list of events serializable
            //Add the last record to the m_listeventsSerializable which contains the all lists of events.
            List<MacroEventSerializable> testEventsSerializable = new List<MacroEventSerializable>(m_eventsSerializable);//Make a copy of list m_events called testEvents. So now, m_events=testEvents.
            m_listeventsSerializable.Add(testEventsSerializable);//Add the list testEvents which is a copy of m_events and which contains the last record. We do a copy because otherwise, it is added by reference.
            m_eventsSerializable.Clear();
            #endregion
        }


        //Event when the user click on the playBack button
        public void playBackMacroButton_Click(object sender, EventArgs e)
        {
            #region Disable unused button when we Playback a Record
            disableUnusedButtonWhenPlaybackRecord();//Disable unused button when we Playback Record
            #endregion

            #region Parse the radio buttons to know which one is checked and therefore which event playback
            int numberIDSelected = 0;
            //For each component in ScrollPanel of FormModePersonalize Form
            foreach (object o in ScrollPanel.Controls)
            {
                //If the component is a RadioButton (i.e: If the type of component is a RadioButton).
                if (o is System.Windows.Forms.RadioButton)
                {
                    System.Windows.Forms.RadioButton currentRadioButton = (System.Windows.Forms.RadioButton)o;//Stock the component (which is a RadioButton) on a variable called currentRadioButton.
                    //If the current RadioButton is checked
                    if (currentRadioButton.Checked == true)
                    {
                        break;
                    }
                    else
                    {
                        numberIDSelected++;
                    }
                }
            }
            #endregion

            #region Playback the event that the user has chosen
            //Playback the event that the user has chosen
            foreach (MacroEvent macroEvent in m_listevents[numberIDSelected])
            {
                Thread.Sleep(macroEvent.TimeSinceLastEvent);//Stop the timer until that the macroEvent stop

                //Switch the type of MacroEvent read in the m_listevents[numberIDSelected]
                switch (macroEvent.MacroEventType)
                {
                    //If the MacroEvent read in the m_listevents[numberIDSelected] is of type MouseMove, then simulate the same movement of mouse.
                    case MacroEventType.MouseMove:
                        {
                            MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;
                            MouseSimulator.X = mouseArgs.X;
                            MouseSimulator.Y = mouseArgs.Y;
                        }
                        break;

                    //If the MacroEvent read in the m_listevents[numberIDSelected] is of type MouseDown, then simulate the same clic of mouse.
                    case MacroEventType.MouseDown:
                        {
                            MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;
                            MouseSimulator.MouseDown(mouseArgs.Button);
                        }
                        break;

                    //If the MacroEvent read in the m_listevents[numberIDSelected] is of type MouseUp, then simulate the same action of mouse.
                    case MacroEventType.MouseUp:
                        {
                            MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;
                            MouseSimulator.MouseUp(mouseArgs.Button);
                        }
                        break;

                    //If the MacroEvent read in the m_listevents[numberIDSelected] is of type KeyDown, then simulate the same action of keyboard.
                    case MacroEventType.KeyDown:
                        {
                            KeyEventArgs keyArgs = (KeyEventArgs)macroEvent.EventArgs;
                            KeyboardSimulator.KeyDown(keyArgs.KeyCode);
                        }
                        break;

                    //If the MacroEvent read in the m_listevents[numberIDSelected] is of type KeyUp, then simulate the same action of keyboad.
                    case MacroEventType.KeyUp:
                        {
                            KeyEventArgs keyArgs = (KeyEventArgs)macroEvent.EventArgs;
                            KeyboardSimulator.KeyUp(keyArgs.KeyCode);
                        }
                        break;
                    
                    //Otherwise, break.
                    default:
                        break;
                }
            }
            #endregion

            #region Enable used button when we Playback Record Stop
            enableUsedButtonWhenPlaybackRecordStop();//Enable used button when we Playback Record Stop
            #endregion
        }

        //Event when the user click on the recognition button
        public void speechButton_Click(object sender, EventArgs e)
        {
            #region if the speech recognition is not activate, try to activate the speech recognition in continious mode
            //if the speech recognition is not activate
            if (!m_speechRecognitionActivate)
            {
                //try to activate the speech recognition in continious mode
                try
                {
                    m_ASR.getm_ASR().RecognizeAsync(RecognizeMode.Multiple);//Activate the speech recognition in continious mode
                    m_speechRecognitionActivate = true;//Update the attribute which store if the speech recognition is activate or not
                    speechButton.Image = Properties.Resources.FreeSpeechRecognitionIcon;//Update button image to show that the speech recognition is activate
                }
                catch { }
            }
            #endregion

            #region if the speech recognition is activate, try to desactivate the speech recognition
            //if the speech recognition is not activate
            else if (m_speechRecognitionActivate)
            {
                //try to activate the speech recognition in continious mode
                try
                {
                    m_ASR.getm_ASR().RecognizeAsyncStop();//Desactivate the speech recognition in continious mode
                    m_speechRecognitionActivate = false;//Update the attribute which store if the speech recognition is activate or not
                    speechButton.Image = Properties.Resources.FreeNoSpeechRecognitionIcon;//Update button image to show that the speech recognition is not activate
                }
                catch { }
            }
            #endregion
        }

        #endregion

        #region Methods to Import/Export Several Events

        #region Methods to Import Several Events
        private void ImportSeveralEventsButton_Click(object sender, EventArgs e)
        {
            Stream streamToDeserializeEvents;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((streamToDeserializeEvents = openFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    XmlSerializer eventSerialisation = new XmlSerializer(typeof(List<List<MacroEventSerializable>>));
                    List<List<MacroEventSerializable>> listEventsImported = (List<List<MacroEventSerializable>>) eventSerialisation.Deserialize(streamToDeserializeEvents);

                    for(int i=0; i<listEventsImported.Count; i++)
                    {
                        List<MacroEvent> listMacroEventRecreated = new List<MacroEvent>();
                        for (int j = 0; j < listEventsImported[i].Count; j++)
                        {
                            EventArgs currentMacroEvent;
                            //if the Event is a Mouse action
                            if(listEventsImported[i][j].MacroEventType != MacroEventType.KeyDown && listEventsImported[i][j].MacroEventType != MacroEventType.KeyUp)
                            {
                                currentMacroEvent = new MouseEventArgs(listEventsImported[i][j].m_button, listEventsImported[i][j].m_clicks, listEventsImported[i][j].m_x, listEventsImported[i][j].m_y, listEventsImported[i][j].m_delta);
                            }
                            //if the Event is a Keyboard action
                            else
                            {
                                currentMacroEvent = new KeyEventArgs(listEventsImported[i][j].m_KeyData);
                            }
                            MacroEvent currentEvent = new MacroEvent(listEventsImported[i][j].MacroEventType, currentMacroEvent, listEventsImported[i][j].TimeSinceLastEvent);
                            listMacroEventRecreated.Add(currentEvent);
                        }
                        m_listevents.Add(listMacroEventRecreated);
                    }

                    #region For each Event imported, create a new RadioButton dynamically
                    if (m_numberID == 0)
                    {
                        #region Enable playBackMacroButton Button
                        playBackMacroButton.Enabled = true;//Enable playBackMacroButton Button
                        #endregion
                    }
                    //For each Event imported, create a new RadioButton dynamically
                    for (int i = 0; i<listEventsImported.Count; i++)
                    {
                        #region Create new RadioButton dynamically for the event that we import

                        #region Create new RadioButton variable, set it is name dynamically and update variable
                        //Create new RadioButton dynamically for the event that we import
                        m_numberID++;//Increment the number of event
                        System.Windows.Forms.RadioButton radb = new System.Windows.Forms.RadioButton();//Create a RadioButton
                        radb.Text = "Event" + m_numberID;//Set the text of RadioButton with the name Event following by the number of events
                        Point lastLocationRadioButton = new System.Drawing.Point(0, 0);//Create a variable of type Point
                        #endregion

                        #region Uncheck all Radio button and check the last Radio button that we want to add dynamically
                        //For each component in ScrollPanel of FormModePersonalize Form, we uncheck all Radio button
                        foreach (object o in ScrollPanel.Controls)
                        {
                            //If the component is a RadioButton (i.e: If the type of component is a RadioButton).
                            if (o is System.Windows.Forms.RadioButton)
                            {
                                System.Windows.Forms.RadioButton currentRadioButton = (System.Windows.Forms.RadioButton)o;//Stock the component (which is a RadioButton) on a variable called currentRadioButton.
                                lastLocationRadioButton = currentRadioButton.Location;//Set the variable lastLocationRadioButton with the location of the current RadioButton.
                                                                                      //If the current RadioButton is checked
                                if (currentRadioButton.Checked == true)
                                {
                                    currentRadioButton.Checked = false;//Uncheck all Radio button exept the last one.
                                }
                            }
                        }
                        radb.Checked = true;//Check the last Radio button
                        #endregion

                        #region Set the position of the new Radio button
                        //If it is the first record
                        if (m_numberID == 1)
                        {
                            radb.Location = new System.Drawing.Point(10, 0);//Set the position of RadioButton in the FormModePersonalize Form
                        }
                        //If it is not the first record
                        else
                        {
                            radb.Location = new System.Drawing.Point(10, lastLocationRadioButton.Y + 30);//Set the position of RadioButton in the FormModePersonalize Form
                        }
                        #endregion

                        #region Add the new Radio button to the ScrollPanel
                        ScrollPanel.Controls.Add(radb);//Add RadioButton in panel called ScrollPanel in FormModePersonalize Form
                        #endregion

                        #region Add the new Radio button to the list m_listOfRadioButton
                        m_listOfRadioButton.Add(radb);//Add the new Radio button to the list m_listOfRadioButton
                        #endregion

                        #endregion
                    }
                    #endregion

                    streamToDeserializeEvents.Close();

                    /********* TEST/DEBUG SECTION **********/
                    List<List<MacroEvent>> listEventsTest = new List<List<MacroEvent>>();
                    listEventsTest.Equals(m_listevents);
                    listEventsImported.Equals(m_listeventsSerializable);
                    /***************************************/
                }
            }
        }
        #endregion

        #region Methods to Export Several Events
        private void ExportSeveralEventsButton_Click(object sender, EventArgs e)
        {
            //if there are no events that have been created yet, we cannot export events. So, we create a error message box.
            if (m_listevents.Count() == 0)
            {
                // Configure the message box to be displayed
                string messageBoxText = "Cannot export events because there are no events that have been created yet. Create at least one event to be able to export events!";
                string caption = "Action";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(messageBoxText, caption, button, icon);//Show message box error to inform user that the metod playBackMacroButton_Click fail
            }
            else
            {
                Stream streamToSerializeEvents;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((streamToSerializeEvents = saveFileDialog1.OpenFile()) != null)
                    {
                        Console.WriteLine(m_listeventsSerializable);
                        // Code to write the stream goes here.
                        XmlSerializer eventSerialisation = new XmlSerializer(typeof(List<List<MacroEventSerializable>>));
                        eventSerialisation.Serialize(streamToSerializeEvents, m_listeventsSerializable);
                       
                        streamToSerializeEvents.Close();
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Methods to check/uncheck a RadioButton by its event id

        #region Methods to check a RadioButton by its event id
        //Check a RadioButton by its event id
        public void checkRadioButtonByItsEventId(int idOfEvent)
        {
            #region Parse the radio buttons to know which one is checked and therefore which event playback
            int currentIdRadioButton = 1;
            //For each component in ScrollPanel of FormModePersonalize Form
            foreach (object o in ScrollPanel.Controls)
            {
                //If the component is a RadioButton (i.e: If the type of component is a RadioButton).
                if (o is System.Windows.Forms.RadioButton)
                {
                    System.Windows.Forms.RadioButton currentRadioButton = (System.Windows.Forms.RadioButton)o;//Stock the component (which is a RadioButton) on a variable called currentRadioButton.

                    if (currentIdRadioButton != idOfEvent)
                    {
                        //If the current RadioButton is checked
                        if (currentRadioButton.Checked == true)
                        {
                            currentRadioButton.Checked = false;
                            currentIdRadioButton++;
                        }
                        else
                        {
                            currentIdRadioButton++;
                        }
                    }
                    else
                    {
                        //If the current RadioButton is checked
                        if (currentRadioButton.Checked == false)
                        {
                            currentRadioButton.Checked = true;
                            currentIdRadioButton++;
                        }
                        else
                        {
                            currentIdRadioButton++;
                        }
                    }
                }
            }
            #endregion
        }
        #endregion

        #region Methods to uncheck a RadioButton by its event id
        //Uncheck a RadioButton by its event id
        public void UncheckRadioButtonByItsEventId(int idOfEvent)
        {
            getRadioButtonByEventId(idOfEvent).Checked = false;
        }
        #endregion

        #endregion

        #endregion
    }
}
